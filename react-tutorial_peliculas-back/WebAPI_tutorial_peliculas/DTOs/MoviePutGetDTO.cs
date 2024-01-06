namespace WebAPI_tutorial_peliculas.DTOs
{
    public class MoviePutGetDTO
    {
        public MovieDTO Movie { get; set; }
        public List<GenreDTO> SelectedGenres { get; set; }
        public List<GenreDTO> NoSelectedGenres { get; set; }
        public List<CinemaDTO> SelectedCinemas { get; set; }
        public List<CinemaDTO> NoSelectedCinemas { get; set; }
        public List<ActorMovieDTO> ActorMovieDTO { get; set; }
    }
}
