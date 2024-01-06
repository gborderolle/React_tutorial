// Clase 136: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26047826#notes

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class MoviePostGetDTO
    {
        public List<GenreDTO> Genres { get; set; }
        public List<CinemaDTO> Cinemas { get; set; }
    }
}
