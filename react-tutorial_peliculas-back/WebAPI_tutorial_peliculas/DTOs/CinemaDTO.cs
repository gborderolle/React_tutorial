using WebAPI_tutorial_peliculas.Utilities.HATEOAS;

namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Google Maps: latitud y longitud (en ese orden)
    /// Ej. apto: -34.90990874483437, -56.192072498205505
    /// lat: -34.90990874483437, long: -56.192072498205505
    /// </summary>
    public class CinemaDTO : Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieCinemaDTO> MovieCinemaList { get; set; } // n..n
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
