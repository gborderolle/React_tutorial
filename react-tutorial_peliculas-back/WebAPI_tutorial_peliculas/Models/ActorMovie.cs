namespace WebAPI_tutorial_peliculas.Models
{
    /// <summary>
    /// Navegación n..n
    /// </summary>
    public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

    }
}
