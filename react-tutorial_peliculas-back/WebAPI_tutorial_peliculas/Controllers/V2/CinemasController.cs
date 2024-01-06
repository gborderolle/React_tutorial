using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Net;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.DTOs;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;
using WebAPI_tutorial_peliculas.Utilities;

namespace WebAPI_tutorial_peliculas.Controllers.V2
{
    [ApiController]
    [HasHeader("x-version", "2")] // Agregar header: "x-version": "1"
    [Route("api/cinemas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CinemasController : CustomBaseController<Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository; // Servicio que contiene la lógica principal de negocio para Cinemas.
        private readonly GeometryFactory _geometryFactory;
        private readonly ContextDB _dbContext;

        public CinemasController(ILogger<CinemasController> logger, IMapper mapper, ICinemaRepository cinemaRepository, GeometryFactory geometryFactory, ContextDB dbContext)
        : base(mapper, logger, cinemaRepository)
        {
            _response = new();
            _cinemaRepository = cinemaRepository;
            _geometryFactory = geometryFactory;
            _dbContext = dbContext;
        }

        #region Endpoints genéricos

        [HttpGet(Name = "GetCinema")] // url completa: https://localhost:7003/api/Cinemas/
        public async Task<ActionResult<APIResponse>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Cinema>>
            {
                    // películas
                    new ThenIncludePropertyConfiguration<Cinema>
                    {
                        IncludeExpression = b => b.MovieCinemaList,
                        ThenIncludeExpression = ab => ((MovieCinema)ab).Movie
                    }
                };
            return await Get<Cinema, CinemaDTO>(paginationDTO: paginationDTO, orderBy: x => x.Name, thenIncludes: thenIncludes);
        }

        [HttpGet("{id:int}", Name = "GetCinemaById")] // url completa: https://localhost:7003/api/Cinemas/1
        public async Task<ActionResult<APIResponse>> Get([FromRoute] int id)
        {
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Cinema>>
            {
                    // películas
                    new ThenIncludePropertyConfiguration<Cinema>
                    {
                        IncludeExpression = b => b.MovieCinemaList,
                        ThenIncludeExpression = ab => ((MovieCinema)ab).Movie
                    }
                };
            return await GetById<Cinema, CinemaDTO>(id, thenIncludes: thenIncludes);
        }

        /// <summary>
        /// FromQuery(param en url)  
        /// FromBody(valor en el body)
        /// FromHeader(valor en el header)
        /// FromRoute o Si no se indica nada, como este caso => se toma directo en la URL así: api/movies/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeleteCinema")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Delete([FromRoute] int id)
        {
            return await Delete<Cinema>(id);
        }

        [HttpPut("{id:int}", Name = "UpdateCinema")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromBody] CinemaCreateDTO cinemaCreateDTO)
        {
            return await Put<CinemaCreateDTO, CinemaDTO, Cinema>(id, cinemaCreateDTO);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialCinema")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Patch(int id, [FromBody] JsonPatchDocument<CinemaPatchDTO> patchDto)
        {
            return await Patch<Cinema, CinemaPatchDTO>(id, patchDto);
        }

        #endregion

        #region Endpoints específicos

        [HttpPost(Name = "CreateCinema")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Post([FromBody] CinemaCreateDTO cinemaCreateDto)
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
                if (await _cinemaRepository.Get(v => v.Name.ToLower() == cinemaCreateDto.Name.ToLower()) != null)
                {
                    _logger.LogError($"El nombre {cinemaCreateDto.Name} ya existe en el sistema");
                    _response.ErrorMessages = new List<string> { $"El nombre {cinemaCreateDto.Name} ya existe en el sistema." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    ModelState.AddModelError("NameAlreadyExists", $"El nombre {cinemaCreateDto.Name} ya existe en el sistema.");
                    return BadRequest(ModelState);
                }

                Cinema modelo = _mapper.Map<Cinema>(cinemaCreateDto);
                modelo.Creation = DateTime.Now;
                modelo.Update = DateTime.Now;

                await _cinemaRepository.Create(modelo);
                _logger.LogInformation($"Se creó correctamente el cine Id:{modelo.Id}.");

                _response.Result = _mapper.Map<CinemaDTO>(modelo); // Siempre retorna el DTO genérico: CinemaDTO
                _response.StatusCode = HttpStatusCode.Created;

                // CreatedAtRoute -> Nombre de la ruta (del método): GetCinemaById
                // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/13816172#notes
                return CreatedAtRoute("GetCinemaByIdv1", new { id = modelo.Id }, _response); // objeto que devuelve (el que creó). 
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

        /// <summary>
        /// No funciona
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("Near")]
        public async Task<ActionResult<APIResponse>> Near1([FromQuery] CinemaNearFilterDTO filter)
        {
            var userLocation = _geometryFactory.CreatePoint(new Coordinate(filter.Longitude, filter.Latitude));
            return await Get<Cinema, CinemaNearDTO>
                (
                    orderBy: x => x.Location.Distance(userLocation),
                    where: x => x.Location.IsWithinDistance(userLocation, filter.DistanceKms * 1000)
                //select: query => query.Select(x => new CinemaNearDTO
                //{
                //    Id = x.Id,
                //    DistanceMts = Math.Round(x.Location.Distance(userLocation))
                //})

                );
        }

        /// <summary>
        /// Sí funciona
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("Near2")]
        public async Task<ActionResult<APIResponse>> Near2([FromQuery] CinemaNearFilterDTO filter)
        {
            var userLocation = _geometryFactory.CreatePoint(new Coordinate(filter.Longitude, filter.Latitude));
            var cinemaList = await _dbContext.Cinema
                .OrderBy(x => x.Location.Distance(userLocation))
                .Where(x => x.Location.IsWithinDistance(userLocation, filter.DistanceKms * 1000))
                .Include(x => x.MovieCinemaList).ThenInclude(y => y.Movie)
                .Select(x => new CinemaNearDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Latitude = x.Location.Y,
                    Longitude = x.Location.X,
                    MovieCinemaList = _mapper.Map<List<MovieCinemaDTO>>(x.MovieCinemaList),
                    DistanceMts = Math.Round(x.Location.Distance(userLocation))
                })
                .ToListAsync();

            _response.Result = cinemaList;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        #endregion

        #region Private methods

        #endregion
    }
}