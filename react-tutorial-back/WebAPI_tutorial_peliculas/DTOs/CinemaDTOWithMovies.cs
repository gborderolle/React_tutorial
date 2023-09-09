namespace WebAPI_tutorial_peliculas.DTOs
{
    public class CinemaDTOWithMovies : CinemaDTO
    {
        public List<MovieDTO> MovieList { get; set; }
    }
}
