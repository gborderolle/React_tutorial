using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI_tutorial_peliculas.DTOs;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;
using WebAPI_tutorial_peliculas.Utilities;

namespace WebAPI_tutorial_peliculas.Controllers.V2
{
    [ApiController]
    [HasHeader("x-version", "2")] // Agregar header: "x-version": "1"
    [Route("api/genres")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenresController : CustomBaseController<Genre> // Notice <Genre> here
    {
        private readonly IGenreRepository _genreRepository; // Servicio que contiene la lógica principal de negocio para Genres.

        public GenresController(ILogger<GenresController> logger, IMapper mapper, IGenreRepository genreRepository)
        : base(mapper, logger, genreRepository)
        {
            _response = new();
            _genreRepository = genreRepository;
        }

        #region Endpoints genéricos

        [HttpGet(Name = "GetGenre")]
        public async Task<ActionResult<APIResponse>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            return await Get<Genre, GenreDTO>(paginationDTO: paginationDTO);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<ActionResult<APIResponse>> All()
        {
            var genres = await _genreRepository.GetAll();
            _response.Result = _mapper.Map<List<GenreDTO>>(genres);
            _response.StatusCode = HttpStatusCode.OK;
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetGenreById")] // url completa: https://localhost:7003/api/Genres/1
        public async Task<ActionResult<APIResponse>> Get([FromRoute] int id)
        {
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Genre>>
            {
                    // géneros
                    new ThenIncludePropertyConfiguration<Genre>
                    {
                        IncludeExpression = b => b.MovieGenreList,
                        ThenIncludeExpression = ab => ((MovieGenre)ab).Movie
                    }
                };
            return await GetById<Genre, GenreDTO>(id, thenIncludes: thenIncludes);
        }

        [HttpDelete("{id:int}", Name = "DeleteGenre")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Delete([FromRoute] int id)
        {
            return await Delete<Genre>(id);
        }

        [HttpPut("{id:int}", Name = "UpdateGenre")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromBody] GenreCreateDTO genreCreateDTO)
        {
            return await Put<GenreCreateDTO, GenreDTO, Genre>(id, genreCreateDTO);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialGenre")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Patch(int id, [FromBody] JsonPatchDocument<GenrePatchDTO> patchDto)
        {
            return await Patch<Genre, GenrePatchDTO>(id, patchDto);
        }

        #endregion

        #region Endpoints específicos

        [HttpPost(Name = "CreateGenre")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Post([FromBody] GenreCreateDTO genreCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Ocurrió un error en el servidor.");
                    _response.ErrorMessages = new List<string> { $"Ocurrió un error en el servidor." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(ModelState);
                }
                if (await _genreRepository.Get(v => v.Name.ToLower() == genreCreateDto.Name.ToLower()) != null)
                {
                    _logger.LogError($"El nombre {genreCreateDto.Name} ya existe en el sistema");
                    _response.ErrorMessages = new List<string> { $"El nombre {genreCreateDto.Name} ya existe en el sistema." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    ModelState.AddModelError("NameAlreadyExists", $"El nombre {genreCreateDto.Name} ya existe en el sistema.");
                    return BadRequest(ModelState);
                    //return BadRequest(_response);
                }

                Genre modelo = _mapper.Map<Genre>(genreCreateDto);
                modelo.Creation = DateTime.Now;
                modelo.Update = DateTime.Now;

                await _genreRepository.Create(modelo);
                _logger.LogInformation($"Se creó correctamente el género Id:{modelo.Id}.");

                _response.Result = _mapper.Map<GenreDTO>(modelo);
                _response.StatusCode = HttpStatusCode.Created;

                // CreatedAtRoute -> Nombre de la ruta (del método): GetGenreById
                // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/13816172#notes
                return CreatedAtRoute("GetGenreByIdv1", new { id = modelo.Id }, _response); // objeto que devuelve (el que creó). 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        #endregion

        #region Private methods

        #endregion

    }
}

