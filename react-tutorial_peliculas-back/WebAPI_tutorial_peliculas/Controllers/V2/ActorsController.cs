using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI_tutorial_peliculas.DTOs;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;
using WebAPI_tutorial_peliculas.Services;
using WebAPI_tutorial_peliculas.Utilities;

namespace WebAPI_tutorial_peliculas.Controllers.V2
{
    [ApiController]
    [HasHeader("x-version", "2")] // Agregar header: "x-version": "1"
    [Route("api/actors")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActorsController : CustomBaseController<Actor>
    {
        private readonly IActorRepository _actorRepository; // Servicio que contiene la lógica principal de negocio para Actors.
        private readonly IFileStorage _fileStorage;
        private readonly string _container = "actors";

        public ActorsController(ILogger<ActorsController> logger, IMapper mapper, IActorRepository actorRepository, IFileStorage fileStorage)
        : base(mapper, logger, actorRepository)
        {
            _response = new();
            _actorRepository = actorRepository;
            _fileStorage = fileStorage;
        }

        #region Endpoints genéricos

        [HttpGet(Name = "GetActor")] // url completa: https://localhost:7003/api/Actors/
        public async Task<ActionResult<APIResponse>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Actor>>
            {
                // películas
                new ThenIncludePropertyConfiguration<Actor>
                {
                    IncludeExpression = b => b.ActorMovieList,
                    ThenIncludeExpression = ab => ((ActorMovie)ab).Movie
                }
            };
            return await Get<Actor, ActorDTO>(paginationDTO: paginationDTO, orderBy: x => x.Name, thenIncludes: thenIncludes);
        }

        [HttpGet("{id:int}", Name = "GetActorById")] // url completa: https://localhost:7003/api/Actors/1
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Actor>>
            {
                // películas
                new ThenIncludePropertyConfiguration<Actor>
                {
                    IncludeExpression = b => b.ActorMovieList,
                    ThenIncludeExpression = ab => ((ActorMovie)ab).Movie
                }
            };
            return await GetById<Actor, ActorDTO>(id, thenIncludes: thenIncludes);
        }

        [HttpDelete("{id:int}", Name = "DeleteActor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Delete([FromRoute] int id)
        {
            return await Delete<Actor>(id);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialActor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Patch(int id, [FromBody] JsonPatchDocument<ActorPatchDTO> patchDto)
        {
            return await Patch<Actor, ActorPatchDTO>(id, patchDto);
        }

        #endregion

        #region Endpoints específicos

        /// <summary>
        /// [FromForm]: Subir archivos, Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/19983788#notes
        /// </summary>
        /// <param name="actorCreateDTO"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateActor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Post([FromForm] ActorCreateDTO actorCreateDTO) // Importante desde front mandar esto en el POST: "Content-Type": "multipart/form-data"
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
                if (await _actorRepository.Get(v => v.Name.ToLower() == actorCreateDTO.Name.ToLower()) != null)
                {
                    _logger.LogError($"El nombre {actorCreateDTO.Name} ya existe en el sistema");
                    _response.ErrorMessages = new List<string> { $"El nombre {actorCreateDTO.Name} ya existe en el sistema." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    ModelState.AddModelError("NameAlreadyExists", $"El nombre {actorCreateDTO.Name} ya existe en el sistema.");
                    return BadRequest(ModelState);
                }

                Actor modelo = _mapper.Map<Actor>(actorCreateDTO);
                modelo.Creation = DateTime.Now;
                modelo.Update = DateTime.Now;

                if (actorCreateDTO.Photo != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await actorCreateDTO.Photo.CopyToAsync(stream);
                        var content = stream.ToArray();
                        var extension = Path.GetExtension(actorCreateDTO.Photo.FileName);
                        modelo.PhotoURL = await _fileStorage.SaveFile(content, extension, _container, actorCreateDTO.Photo.ContentType);
                    }
                }

                await _actorRepository.Create(modelo);
                _logger.LogInformation($"Se creó correctamente el actor Id:{modelo.Id}.");

                _response.Result = _mapper.Map<ActorDTO>(modelo); // Siempre retorna el DTO genérico: ActorDTO
                _response.StatusCode = HttpStatusCode.Created;

                // CreatedAtRoute -> Nombre de la ruta (del método): GetActorById
                // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/13816172#notes
                return CreatedAtRoute("GetActorById", new { id = modelo.Id }, _response); // objeto que devuelve (el que creó). 
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

        [HttpPut("{id:int}", Name = "UpdateActor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromForm] ActorCreateDTO actorCreateDTO)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogError($"Datos de entrada inválidos.");
                    _response.ErrorMessages = new List<string> { $"Datos de entrada inválidos." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var actor = await _actorRepository.Get(v => v.Id == id, tracked: false);
                if (actor == null)
                {
                    _logger.LogError($"Actor no encontrado ID = {id}.");
                    _response.ErrorMessages = new List<string> { $"Actor no encontrado ID = {id}" };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                actor = _mapper.Map(actorCreateDTO, actor);
                actor.Id = id;

                if (actorCreateDTO.Photo != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await actorCreateDTO.Photo.CopyToAsync(stream);
                        var content = stream.ToArray();
                        var extension = Path.GetExtension(actorCreateDTO.Photo.FileName);
                        actor.PhotoURL = await _fileStorage.EditFile(content, extension, _container, actor.PhotoURL, actorCreateDTO.Photo.ContentType);
                    }
                }

                var updatedActor = await _actorRepository.Update(actor);

                _logger.LogInformation($"Se actualizó correctamente el actor Id:{id}.");
                _response.Result = _mapper.Map<ActorDTO>(updatedActor);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
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