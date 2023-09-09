namespace WebAPI_tutorial_peliculas.DTOs
{
    public class MovieDetailsDTO
    {
        public MovieDTO Movie { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<CinemaDTO> Cinemas { get; set; }
        public List<ActorDTO> Actors { get; set; }
        public List<ReviewDTO> Reviews { get; set; } // 0..n (0=no existe Review sin Book)
        public int UserVote { get; set; }
        public double AverageVote { get; set; }

    }
}
