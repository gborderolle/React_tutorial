using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Utilities.HATEOAS;

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class GenreDTO : Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieGenre> MovieGenreList { get; set; } // n..n

    }
}
