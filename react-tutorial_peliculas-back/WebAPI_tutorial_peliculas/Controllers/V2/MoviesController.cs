using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.DTOs;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;
using WebAPI_tutorial_peliculas.Services;
using WebAPI_tutorial_peliculas.Utilities;

namespace WebAPI_tutorial_peliculas.Controllers.V2
{
    [ApiController]
    [HasHeader("x-version", "2")] // Agregar header: "x-version": "1"
    [Route("api/movies")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MoviesController : CustomBaseController<Movie>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IFileStorage _fileStorage;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string _container = "actors";

        private readonly ContextDB _contextDB;

        public MoviesController(ILogger<MoviesController> logger, IMapper mapper, IMovieRepository movieRepository, IActorRepository actorRepository, IGenreRepository genreRepository, ICinemaRepository cinemaRepository, IFileStorage fileStorage, ContextDB contextDB, UserManager<IdentityUser> userManager)
        : base(mapper, logger, movieRepository)
        {
            _response = new();
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
            _cinemaRepository = cinemaRepository;
            _fileStorage = fileStorage;
            _contextDB = contextDB;
            _userManager = userManager;
        }

        #region Endpoints genéricos

        [HttpGet(Name = "GetMovie")] // url completa: https://localhost:7003/api/Movies/
        [AllowAnonymous]
        public async Task<ActionResult<APIResponse>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            // 1..n
            var includes = new List<IncludePropertyConfiguration<Movie>>
            {
                    new IncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ReviewList
                    }
                };
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Movie>>
            {
                    // actores
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ActorMovieList,
                        ThenIncludeExpression = ab => ((ActorMovie)ab).Actor
                    },
                    // géneros
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieGenreList,
                        ThenIncludeExpression = ab => ((MovieGenre)ab).Genre
                    },
                    // cines
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieCinemaList,
                        ThenIncludeExpression = ab => ((MovieCinema)ab).Cinema
                    }
                };
            return await Get<Movie, MovieDTO>(paginationDTO: paginationDTO, orderBy: x => x.Id, includes: includes, thenIncludes: thenIncludes);
        }

        /// <summary>
        /// FromQuery(param en url)  
        /// FromBody(valor en el body)
        /// FromHeader(valor en el header)
        /// FromRoute o Si no se indica nada, como este caso => se toma directo en la URL así: api/movies/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeleteMovie")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Delete([FromRoute] int id)
        {
            return await Delete<Movie>(id);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialMovie")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Patch(int id, [FromBody] JsonPatchDocument<MoviePatchDTO> patchDto)
        {
            return await Patch<Movie, MoviePatchDTO>(id, patchDto);
        }

        #endregion

        #region Endpoints específicos

        [HttpPost(Name = "CreateMovie")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Post([FromForm] MovieCreateDTO movieCreateDto)
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

                // check actores
                if (movieCreateDto.Actors == null || movieCreateDto.Actors.Count == 0)
                {
                    _logger.LogError("No se puede crear una película sin actores.");
                    _response.ErrorMessages = new List<string> { $"No se puede crear una película sin actores." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                foreach (var actor in movieCreateDto.Actors)
                {
                    var actor_ret = await _actorRepository.Get(v => v.Id == actor.Id);
                    if (actor_ret == null)
                    {
                        _logger.LogError($"No existe el actor ID = {actor.Id}.");
                        _response.ErrorMessages = new List<string> { $"No existe el actor ID = {actor.Id}." };
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        return BadRequest(_response);
                    }
                }
                // end check ------------------

                // check géneros
                if (movieCreateDto.GenreIds == null || movieCreateDto.GenreIds.Count == 0)
                {
                    _logger.LogError("No se puede crear una película sin géneros.");
                    _response.ErrorMessages = new List<string> { $"No se puede crear una película sin géneros." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                foreach (var genreId in movieCreateDto.GenreIds)
                {
                    var genre_ret = await _genreRepository.Get(v => v.Id == genreId);
                    if (genre_ret == null)
                    {
                        _logger.LogError($"No existe el género ID = {genreId}.");
                        _response.ErrorMessages = new List<string> { $"No existe el género ID = {genreId}." };
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        return BadRequest(_response);
                    }
                }
                // end check ------------------

                // check cines
                if (movieCreateDto.CinemaIds != null && movieCreateDto.CinemaIds.Count > 0)
                {
                    foreach (var cinemaId in movieCreateDto.CinemaIds)
                    {
                        var cinema_ret = await _cinemaRepository.Get(v => v.Id == cinemaId);
                        if (cinema_ret == null)
                        {
                            _logger.LogError($"No existe el cine ID = {cinemaId}.");
                            _response.ErrorMessages = new List<string> { $"No existe el cine ID = {cinemaId}." };
                            _response.IsSuccess = false;
                            _response.StatusCode = HttpStatusCode.NotFound;
                            return BadRequest(_response);
                        }
                    }
                }
                // end check ------------------

                if (await _movieRepository.Get(v => v.Title.ToLower() == movieCreateDto.Title.ToLower()) != null)
                {
                    _logger.LogError($"El nombre {movieCreateDto.Title} ya existe en el sistema");
                    _response.ErrorMessages = new List<string> { $"El nombre {movieCreateDto.Title} ya existe en el sistema." };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Movie modelo = _mapper.Map<Movie>(movieCreateDto);
                modelo.Creation = DateTime.Now;
                modelo.Update = DateTime.Now;

                if (movieCreateDto.Poster != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await movieCreateDto.Poster.CopyToAsync(stream);
                        var content = stream.ToArray();
                        var extension = Path.GetExtension(movieCreateDto.Poster.FileName);
                        modelo.PosterURL = await _fileStorage.SaveFile(content, extension, _container, movieCreateDto.Poster.ContentType);
                    }
                }

                await _movieRepository.Create(modelo);
                _logger.LogInformation($"Se creó correctamente la película Id:{modelo.Id}.");

                _response.Result = _mapper.Map<MovieDTO>(modelo); // Siempre retorna el DTO genérico: MovieDTO
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
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
        /// ToDo?? 
        // Clase 142: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26092084#notes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieCreateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}", Name = "UpdateMovie")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromForm] MovieCreateDTO movieCreateDTO)
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

                // 1..n
                var includes = new List<IncludePropertyConfiguration<Movie>>
            {
                    new IncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ReviewList
                    }
                };
                // n..n
                var thenIncludes = new List<ThenIncludePropertyConfiguration<Movie>>
            {
                    // actores
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ActorMovieList,
                        ThenIncludeExpression = ab => ((ActorMovie)ab).Actor
                    },
                    // géneros
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieGenreList,
                        ThenIncludeExpression = ab => ((MovieGenre)ab).Genre
                    },
                    // cines
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieCinemaList,
                        ThenIncludeExpression = ab => ((MovieCinema)ab).Cinema
                    }
                };

                var movie = await _movieRepository.Get(v => v.Id == id, includes: includes, thenIncludes: thenIncludes);
                if (movie == null)
                {
                    _logger.LogError($"Película no encontrada ID = {id}.");
                    _response.ErrorMessages = new List<string> { $"Película no encontrada ID = {id}" };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                movie = _mapper.Map(movieCreateDTO, movie);

                // MapActorsMovies
                if (movieCreateDTO.Actors != null)
                {
                    var result = new List<ActorMovie>();
                    foreach (var actorCreate in movieCreateDTO.Actors)
                    {
                        var actorBD = await _actorRepository.Get(v => v.Id == actorCreate.Id);
                        if (actorBD != null)
                        {
                            result.Add(new ActorMovie() { ActorId = actorCreate.Id, Character = actorCreate.Character, Movie = movie, MovieId = movie.Id, Actor = actorBD });
                        }
                    }
                    movie.ActorMovieList = result;
                }

                // MapGenresMovies
                if (movieCreateDTO.GenreIds != null)
                {
                    var result = new List<MovieGenre>();
                    foreach (var genreId in movieCreateDTO.GenreIds)
                    {
                        var genreDB = await _genreRepository.Get(v => v.Id == genreId);
                        if (genreDB != null)
                        {
                            result.Add(new MovieGenre() { Movie = movie, MovieId = movie.Id, GenreId = genreId, Genre = genreDB });
                        }
                    }
                    movie.MovieGenreList = result;
                }

                // MapCinemaMovies
                if (movieCreateDTO.CinemaIds != null)
                {
                    var result = new List<MovieCinema>();
                    foreach (var cinemaId in movieCreateDTO.CinemaIds)
                    {
                        var cinemaDB = await _cinemaRepository.Get(v => v.Id == cinemaId);
                        if (cinemaDB != null)
                        {
                            result.Add(new MovieCinema() { Movie = movie, MovieId = movie.Id, CinemaId = cinemaId, Cinema = cinemaDB });
                        }
                    }
                    movie.MovieCinemaList = result;
                }

                if (movieCreateDTO.Poster != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await movieCreateDTO.Poster.CopyToAsync(stream);
                        var content = stream.ToArray();
                        var extension = Path.GetExtension(movieCreateDTO.Poster.FileName);
                        movie.PosterURL = await _fileStorage.EditFile(content, extension, _container, movie.PosterURL, movieCreateDTO.Poster.ContentType);
                    }
                }

                var updatedMovie = await _movieRepository.Update(movie);

                _logger.LogInformation($"Se actualizó correctamente la película Id:{id}.");
                _response.Result = _mapper.Map<MovieDTO>(updatedMovie);
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

        /// <summary>
        /// ToDo: MEJORAR MÉTODO: usar filtros avanzados (no dbcontext)
        /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20330805#overview
        /// </summary>
        /// <param name="movieFilterDTO"></param>
        /// <returns></returns>
        [HttpGet("filter")] // url completa: https://localhost:7003/api/Movies/filter
        [AllowAnonymous]
        public async Task<ActionResult<APIResponse>> Filter([FromQuery] MovieFilterDTO movieFilterDTO)
        {
            var queryableMovie = _contextDB.Movie
                .Include(m => m.ActorMovieList)
                .Include(m => m.MovieCinemaList)
                .Include(m => m.MovieGenreList)
                .Include(m => m.ReviewList)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(movieFilterDTO.Title))
            {
                queryableMovie = queryableMovie.Where(x => x.Title.Contains(movieFilterDTO.Title));
            }
            if (movieFilterDTO.OnCinema)
            {
                queryableMovie = queryableMovie.Where(x => x.OnCinema);
            }
            if (movieFilterDTO.NextPremiere)
            {
                var today = DateTime.Today;
                queryableMovie = queryableMovie.Where(x => x.Premiere > today);
            }
            if (movieFilterDTO.GenreId > 0)
            {
                queryableMovie = queryableMovie.Where(x => x.MovieGenreList
                .Select(y => y.GenreId)
                .Contains(movieFilterDTO.GenreId));
            }
            await HttpContext.InsertParamPaginationHeader(queryableMovie, movieFilterDTO.RecordsPerPage);
            var movies = await queryableMovie.DoPagination(movieFilterDTO.Pagination).ToListAsync();

            _response.Result = _mapper.Map<List<MovieDTO>>(movies);
            _response.StatusCode = HttpStatusCode.OK;

            return _response;
        }

        /// <summary>
        /// Clase 136: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26047826#notes
        /// </summary>
        /// <returns></returns>
        [HttpGet("PostGet")] // url completa: https://localhost:7003/api/Movies/postget
        public async Task<ActionResult<APIResponse>> PostGet()
        {
            _logger.LogInformation($"Llegó el request.");
            var genreResponse = await _contextDB.Genre.ToListAsync();
            var cinemaResponse = await _contextDB.Cinema.ToListAsync();

            var sd = new MoviePostGetDTO()
            {
                Genres = _mapper.Map<List<GenreDTO>>(genreResponse),
                Cinemas = _mapper.Map<List<CinemaDTO>>(cinemaResponse)
            };
            _response.Result = sd;
            _response.StatusCode = HttpStatusCode.OK;
            return _response;
        }

        /// <summary>
        /// Clase 142: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26092084#notes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // FRONT: DetailsMovie
        [HttpGet("{id:int}", Name = "Get")] // url completa: https://localhost:7003/api/Movies/1
        [AllowAnonymous]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Datos de entrada inválidos.");
                _response.ErrorMessages = new List<string> { $"Datos de entrada inválidos." };
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            // 1..n
            var includes = new List<IncludePropertyConfiguration<Movie>>
            {
                    new IncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ReviewList
                    }
                };
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Movie>>
            {
                    // actores
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ActorMovieList,
                        ThenIncludeExpression = ab => ((ActorMovie)ab).Actor
                    },
                    // géneros
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieGenreList,
                        ThenIncludeExpression = ab => ((MovieGenre)ab).Genre
                    },
                    // cines
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieCinemaList,
                        ThenIncludeExpression = ab => ((MovieCinema)ab).Cinema
                    }
                };

            var movie = await _movieRepository.Get(v => v.Id == id, includes: includes, thenIncludes: thenIncludes);
            if (movie == null)
            {
                _logger.LogError($"Película no encontrada ID = {id}.");
                _response.ErrorMessages = new List<string> { $"Película no encontrada ID = {id}" };
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            var movieDetails = new MovieDetailsDTO();
            movieDetails.Movie = _mapper.Map<MovieDTO>(movie);
            movieDetails.Genres = _mapper.Map<List<GenreDTO>>(movie.MovieGenreList.Select(mg => mg.Genre).ToList());
            movieDetails.Cinemas = _mapper.Map<List<CinemaDTO>>(movie.MovieCinemaList.Select(mg => mg.Cinema).ToList());
            movieDetails.Actors = _mapper.Map<List<ActorDTO>>(movie.ActorMovieList.Select(mg => mg.Actor).ToList());
            movieDetails.Reviews = _mapper.Map<List<ReviewDTO>>(movie.ReviewList);

            double averageRating = await _contextDB.Rating.Where(x => x.MovieId == id).AverageAsync(x => x.Score);
            int userVote = 0;

            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var userId = user.Id;
                    var currentRating = await _contextDB.Rating.FirstOrDefaultAsync(x => x.MovieId == id && x.UserId == userId);
                    if (currentRating != null)
                    {
                        userVote = currentRating.Score;
                    }
                }
            }
            movieDetails.UserVote = userVote;
            movieDetails.AverageVote = averageRating;

            _response.Result = movieDetails;
            _response.StatusCode = HttpStatusCode.OK;
            return _response;
        }

        // FRONT: EditMovie
        [HttpGet("putget/{id:int}", Name = "PutGet")] // url completa: https://localhost:7003/api/Movies/1
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<MoviePutGetDTO>> PutGet(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Datos de entrada inválidos.");
                _response.ErrorMessages = new List<string> { $"Datos de entrada inválidos." };
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            // 1..n
            var includes = new List<IncludePropertyConfiguration<Movie>>
            {
                    new IncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ReviewList
                    }
                };
            // n..n
            var thenIncludes = new List<ThenIncludePropertyConfiguration<Movie>>
            {
                    // actores
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.ActorMovieList,
                        ThenIncludeExpression = ab => ((ActorMovie)ab).Actor
                    },
                    // géneros
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieGenreList,
                        ThenIncludeExpression = ab => ((MovieGenre)ab).Genre
                    },
                    // cines
                    new ThenIncludePropertyConfiguration<Movie>
                    {
                        IncludeExpression = b => b.MovieCinemaList,
                        ThenIncludeExpression = ab => ((MovieCinema)ab).Cinema
                    }
                };

            var movie = await _movieRepository.Get(v => v.Id == id, includes: includes, thenIncludes: thenIncludes);
            if (movie == null)
            {
                _logger.LogError($"Película no encontrada ID = {id}.");
                _response.ErrorMessages = new List<string> { $"Película no encontrada ID = {id}" };
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            //Clase 142: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26092084#notes
            var selectedGenresIds = movie.MovieGenreList.Select(x => x.GenreId).ToList();
            var noSelectedGenres = _contextDB.Genre
                .Where(x => !selectedGenresIds.Contains(x.Id))
                .ToList();

            var selectedCinemasIds = movie.MovieCinemaList.Select(x => x.CinemaId).ToList();
            var noSelectedCinemas = _contextDB.Cinema
                .Where(x => !selectedCinemasIds.Contains(x.Id))
                .ToList();

            var noSelectedGenresDTO = _mapper.Map<List<GenreDTO>>(noSelectedGenres);
            var noSelectedCinemasDTO = _mapper.Map<List<CinemaDTO>>(noSelectedCinemas);

            var respuesta = new MoviePutGetDTO();
            respuesta.Movie = _mapper.Map<MovieDTO>(movie);


            respuesta.SelectedGenres = _mapper.Map<List<GenreDTO>>(movie.MovieGenreList.Select(mg => mg.Genre).ToList());
            respuesta.NoSelectedGenres = _mapper.Map<List<GenreDTO>>(noSelectedGenres);

            respuesta.SelectedCinemas = _mapper.Map<List<CinemaDTO>>(movie.MovieCinemaList.Select(mg => mg.Cinema).ToList());
            respuesta.NoSelectedCinemas = _mapper.Map<List<CinemaDTO>>(noSelectedCinemasDTO);

            respuesta.ActorMovieDTO = _mapper.Map<List<ActorMovieDTO>>(movie.ActorMovieList);
            return respuesta;
        }

        #endregion

        #region Private methods

        #endregion

    }
}