namespace WebAPI_tutorial_peliculas.Models
{
    /// <summary>
    /// Navegación n..n
    /// </summary>
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }

    }
}
