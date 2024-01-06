using WebAPI_tutorial_peliculas.Utilities.HATEOAS;

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class MovieDTO : Resource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool OnCinema { get; set; }
        public DateTime Premiere { get; set; }
        public string PosterURL { get; set; }
        public string Trailer { get; set; }

        public List<ActorMovieDTO> ActorMovieList { get; set; } // n..n
        public List<MovieGenreDTO> MovieGenreList { get; set; } // n..n
        public List<MovieCinemaDTO> MovieCinemaList { get; set; } // n..n
        public List<ReviewDTO> Reviews { get; set; } // 0..n (0=no existe Review sin Book)

    }
}
