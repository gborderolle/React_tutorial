using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class MovieGenreDTO
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public string MovieName { get; set; }
        public string GenreName { get; set; }
      
    }
}
