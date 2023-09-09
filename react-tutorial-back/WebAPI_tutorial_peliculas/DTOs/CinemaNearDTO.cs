namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660144#announcements
    /// </summary>
    public class CinemaNearDTO : CinemaDTO
    {
        public double DistanceMts { get; set; }
    }
}
