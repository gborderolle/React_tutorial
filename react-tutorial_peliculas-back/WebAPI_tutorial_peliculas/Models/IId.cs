namespace WebAPI_tutorial_peliculas.Models
{
    /// <summary>
    /// Heredar todas las clases que tengan Id
    /// </summary>
    public interface IId
    {
        public int Id { get; set; }
    }
}