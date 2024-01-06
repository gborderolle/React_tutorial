using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using WebAPI_tutorial_peliculas.DTOs;
using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ActorCreateDTO, Actor>()
                .ForMember(v => v.PhotoURL, options => options.Ignore());
            CreateMap<ActorPatchDTO, Actor>().ReverseMap();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Actor, ActorDTOWithMovies>()
                .ForMember(dest => dest.MovieList, opt => opt.MapFrom(src => src.ActorMovieList.Select(am => am.Movie)))
                .ReverseMap();

            //

            CreateMap<IdentityUser, UserDTO>();

            //

            CreateMap<CinemaCreateDTO, Cinema>().ReverseMap();
            CreateMap<CinemaPatchDTO, Cinema>().ReverseMap();

            // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660132#notes
            // Parte 1: de Cinema a CinemaDTO
            CreateMap<Cinema, CinemaDTO>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Y)) // de Cinema (Location.Y) a CinemaDTO (Latitud)
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.X)) // de Cinema (Location.X) a CinemaDTO (Longitud)
                                                                                             .ReverseMap();

            CreateMap<Cinema, CinemaNearDTO>() // Prueba Gonzalo
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Y)) // de Cinema (Location.Y) a CinemaDTO (Latitud)
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.X)); // de Cinema (Location.X) a CinemaDTO (Longitud)

            // Parte 2: de CinemaCreateDTO a Cinema
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            CreateMap<CinemaCreateDTO, Cinema>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => geometryFactory
                .CreatePoint(new Coordinate(src.Longitude, src.Latitude)))); // de CinemaDTO (Latitud) a Cinema (Point)

            CreateMap<Cinema, CinemaDTOWithMovies>()
                .ForMember(dest => dest.MovieList, opt => opt.MapFrom(src => src.MovieCinemaList.Select(mc => mc.Movie)))
                .ReverseMap();

            //

            CreateMap<GenreCreateDTO, Genre>().ReverseMap();
            CreateMap<GenrePatchDTO, Genre>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();

            //

            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.ActorMovieList, opt => opt.MapFrom((src, dest, destMember, context) =>
                    src.ActorMovieList?.Select(am => context.Mapper.Map<ActorMovieDTO>(am)).ToList() ?? new List<ActorMovieDTO>()))

                // Similar mapeos para MovieGenre y MovieCinema (ChatGPT)
                .ForMember(dest => dest.MovieGenreList, opt => opt.MapFrom((src, dest, destMember, context) =>
                    src.MovieGenreList.Select(am => context.Mapper.Map<MovieGenreDTO>(am))))

                .ForMember(dest => dest.MovieCinemaList, opt => opt.MapFrom((src, dest, destMember, context) =>
                    src.MovieCinemaList.Select(am => context.Mapper.Map<MovieCinemaDTO>(am))))
                .ReverseMap();

            CreateMap<MoviePatchDTO, Movie>().ReverseMap();
            CreateMap<MovieCreateDTO, Movie>()
                .ForMember(v => v.PosterURL, options => options.Ignore())
                .ForMember(v => v.ActorMovieList, options => options.MapFrom(MapActorsMovies))
                .ForMember(v => v.MovieGenreList, options => options.MapFrom(MapGenresMovies))
                .ForMember(v => v.MovieCinemaList, options => options.MapFrom(MapCinemaMovies));
            CreateMap<Movie, MovieDTOWithActorsAndReviews>()
                .ForMember(dest => dest.ActorList, opt => opt.MapFrom(src => src.ActorMovieList.Select(am => am.Actor)))
                .ReverseMap();

            CreateMap<ActorMovie, ActorMovieDTO>()
                .ForMember(dest => dest.ActorName, opt => opt.MapFrom(src => src.Actor.Name))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ReverseMap();

            CreateMap<MovieCinema, MovieCinemaDTO>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title)) // muestra el MovieName en MovieCinemaDTO que viene de Movie.Title
                .ReverseMap();
            CreateMap<MovieGenre, MovieGenreDTO>().ReverseMap();

            //

            CreateMap<Genre, GenreDTO>().ReverseMap();

            //

            CreateMap<ReviewCreateDTO, Review>().ReverseMap();
            CreateMap<Review, ReviewDTO>()
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.User.UserName))
                .ReverseMap();

            //

            CreateMap<Rating, RatingDTO>().ReverseMap();
        }

        private List<ActorMovie> MapActorsMovies(MovieCreateDTO movieCreateDTO, Movie movie)
        {
            return movieCreateDTO.Actors?.Select(actor =>
            new ActorMovie() { ActorId = actor.Id, Character = actor.Character }).ToList() ?? new List<ActorMovie>();
            //var result = new List<ActorMovie>();
            //if (movieCreateDTO == null)
            //{
            //    return result;
            //}
            //foreach (var actor in movieCreateDTO.Actors)
            //{
            //    result.Add(new ActorMovie() { ActorId = actor.Id, Character = actor.Character, Movie = movie });
            //}
            //return result;
        }

        private List<MovieCinema> MapCinemaMovies(MovieCreateDTO movieCreateDTO, Movie movie)
        {
            return movieCreateDTO.CinemaIds?.Select(cinemaId =>
            new MovieCinema() { CinemaId = cinemaId }).ToList() ?? new List<MovieCinema>();
        }

        private List<MovieGenre> MapGenresMovies(MovieCreateDTO movieCreateDTO, Movie movie)
        {
            return movieCreateDTO.GenreIds?.Select(genreId =>
            new MovieGenre() { GenreId = genreId }).ToList() ?? new List<MovieGenre>();
        }

    }
}