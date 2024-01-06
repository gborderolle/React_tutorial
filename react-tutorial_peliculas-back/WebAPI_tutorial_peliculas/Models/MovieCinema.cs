namespace WebAPI_tutorial_peliculas.Models
{
    /// <summary>
    /// Navegación n..n
    /// </summary>
    public class MovieCinema
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }

    }
}
