using WebAPI_tutorial_peliculas.Utilities.HATEOAS;

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class ActorDTO : Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string PhotoURL { get; set; } // Clase https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/19983788#notes
        public DateTime Born { get; set; }
        public List<ActorMovieDTO> ActorMovieList { get; set; } // n..n

    }
}
