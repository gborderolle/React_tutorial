namespace WebAPI_tutorial_peliculas.DTOs
{
    public class ActorDTOWithMovies : ActorDTO
    {
        public List<MovieDTO> MovieList { get; set; }
    }
}