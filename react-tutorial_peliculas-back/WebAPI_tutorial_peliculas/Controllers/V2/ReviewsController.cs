using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI_tutorial_peliculas.DTOs;
using WebAPI_tutorial_peliculas.Filters;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;
using WebAPI_tutorial_peliculas.Utilities;

namespace WebAPI_tutorial_peliculas.Controllers.V2
{
    /// <summary>
    /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660150#announcements
    /// </summary>
    [ApiController]
    [HasHeader("x-version", "2")] // Agregar header: "x-version": "1"
    [Route("api/movies/{movieId:int}/reviews")] // No existen reviews sin películas --> api/movies/{movieId:int}/review
    [ServiceFilter(typeof(MovieExistsAttribute))]
    public class ReviewsController : CustomBaseController<Review>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewsController(ILogger<ReviewsController> logger, IMapper mapper, IReviewRepository reviewRepository, UserManager<IdentityUser> userManager)
        : base(mapper, logger, reviewRepository)
        {
            _response = new();
            _reviewRepository = reviewRepository;
            _userManager = userManager;
        }

        #region Endpoints genéricos

        [HttpGet(Name = "GetReview")] // url completa: https://localhost:7003/api/Reviews/
        public async Task<ActionResult<APIResponse>> Get(int movieId, [FromQuery] PaginationDTO paginationDTO) // La paginación solo se aplica al Get general (porque es el que trae más resultados)
        {
            // n..1
            var includes = new List<IncludePropertyConfiguration<Review>>
            {
                    new IncludePropertyConfiguration<Review>
                    {
                        IncludeExpression = b => b.Movie
                    },
                    new IncludePropertyConfiguration<Review>
                    {
                        IncludeExpression = b => b.User
                    }
                };
            return await Get<Review, ReviewDTO>(paginationDTO: paginationDTO, includes: includes, where: x => x.MovieId == movieId);
        }

        [HttpGet("{id:int}", Name = "GetReviewById")] // url completa: https://localhost:7003/api/Reviews/1
        public async Task<ActionResult<APIResponse>> Get(int movieId, [FromRoute] int id)
        {
            // n..1
            var includes = new List<IncludePropertyConfiguration<Review>>
            {
                    new IncludePropertyConfiguration<Review>
                    {
                        IncludeExpression = b => b.Movie
                    },
                    new IncludePropertyConfiguration<Review>
                    {
                        IncludeExpression = b => b.User
                    }
                };
            return await GetById<Review, ReviewDTO>(id: id, includes: includes);
        }

        #endregion

        #region Endpoints específicos

        /// <summary>
        /// Sólo usuarios autenticados pueden escribir reviews de las películas --> [Authorize]
        /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660150#notes
        /// </summary>
        /// <param name="reviewCreateDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateReview")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Post(int movieId, [FromBody] ReviewCreateDTO reviewCreateDto)
        {
            try
            {
                var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        var userId = user.Id;
                        var reviewExists = await _reviewRepository.Get(x => x.MovieId == movieId && x.UserId == userId);
                        if (reviewExists != null)
                        {
                            _logger.LogError($"El usuario ya ha escrito una review.");
                            _response.ErrorMessages = new List<string> { $"El usuario ya ha escrito una review." };
                            _response.IsSuccess = false;
                            _response.StatusCode = HttpStatusCode.BadRequest;
                            return BadRequest($"El usuario ya ha escrito una review.");
                        }

                        Review modelo = _mapper.Map<Review>(reviewCreateDto);
                        modelo.Creation = DateTime.Now;
                        modelo.Update = DateTime.Now;
                        modelo.UserId = userId;
                        modelo.MovieId = movieId;

                        await _reviewRepository.Create(modelo);
                        _logger.LogInformation($"Se creó correctamente el review Id:{modelo.Id}.");

                        _response.Result = _mapper.Map<ReviewDTO>(modelo); // Siempre retorna el DTO genérico: ReviewDTO
                        _response.StatusCode = HttpStatusCode.Created;

                        // CreatedAtRoute -> Nombre de la ruta (del método): GetReviewById
                        // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/13816172#notes
                        return CreatedAtRoute("GetReviewById", new { movieId = modelo.MovieId, id = modelo.Id }, _response);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPut("{id:int}", Name = "UpdateReview")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Put(int movieId, int id, [FromBody] ReviewCreateDTO reviewCreateDTO)
        {
            try
            {
                var review = await _reviewRepository.Get(x => x.Id == id, tracked: true);
                if (review == null)
                {
                    _logger.LogError($"Review no encontrado ID = {id}.");
                    _response.ErrorMessages = new List<string> { $"Review no encontrado ID = {id}." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound($"Review no encontrado ID = {id}.");
                }

                var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        var userId = user.Id;
                        if (userId != review.UserId)
                        {
                            // El usuario logueado NO es el usuario que escribió el review => entonces NO puede modificar el review.
                            _logger.LogError($"El usuario no fue el autor original del review.");
                            _response.ErrorMessages = new List<string> { $"El usuario no fue el autor original del review." };
                            _response.IsSuccess = false;
                            _response.StatusCode = HttpStatusCode.Forbidden;
                            return Forbid($"El usuario no fue el autor original del review.");
                        }

                        review = _mapper.Map(reviewCreateDTO, review);
                        await _reviewRepository.Update(review);
                        _logger.LogInformation($"Se modificó correctamente el review Id:{id}.");

                        _response.Result = _mapper.Map<ReviewDTO>(review);
                        _response.StatusCode = HttpStatusCode.OK;
                        return Ok(_response);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialReview")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Patch(int id, [FromBody] JsonPatchDocument<ReviewPatchDTO> patchDto)
        {
            return await Patch<Review, ReviewPatchDTO>(id, patchDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteReview")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Delete(int movieId, [FromRoute] int id)
        {
            try
            {
                var review = await _reviewRepository.Get(x => x.Id == id, tracked: true);
                if (review == null)
                {
                    _logger.LogError($"Review no encontrado ID = {id}.");
                    _response.ErrorMessages = new List<string> { $"Review no encontrado ID = {id}." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound($"Review no encontrado ID = {id}.");
                }
                var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        var userId = user.Id;

                        if (userId != review.UserId)
                        {
                            // El usuario logueado NO es el usuario que escribió el review => entonces NO puede modificar el review.
                            _logger.LogError($"El usuario no fue el autor original del review.");
                            _response.ErrorMessages = new List<string> { $"El usuario no fue el autor original del review." };
                            _response.IsSuccess = false;
                            _response.StatusCode = HttpStatusCode.Forbidden;
                            return Forbid($"El usuario no fue el autor original del review.");
                        }

                        await _reviewRepository.Remove(review);
                        _logger.LogInformation($"Se eliminó correctamente el review Id:{id}.");
                        _response.StatusCode = HttpStatusCode.NoContent;
                        return Ok(_response);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return BadRequest(_response);
        }

        #endregion

        #region Private methods

        #endregion
    }
}