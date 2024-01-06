using System.ComponentModel.DataAnnotations;

namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660144#announcements
    /// </summary>
    public class CinemaNearFilterDTO
    {
        [Range(-90, 90)]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        public double Longitude { get; set; }

        private int distanceMaxKms = 50;
     
        private int distanceKms = 10;
        public int DistanceKms { get => distanceKms; set => distanceKms = (value > distanceMaxKms) ? distanceMaxKms : value; }
    }
}
