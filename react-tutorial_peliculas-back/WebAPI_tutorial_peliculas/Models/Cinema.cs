using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_tutorial_peliculas.Models
{
    /// <summary>
    /// Google Maps: latitud y longitud (en ese orden)
    /// Ej. apto: -34.90990874483437, -56.192072498205505
    /// lat: -34.90990874483437, long: -56.192072498205505
    /// </summary>
    public class Cinema : IId
    {
        // ------------- Genéricas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; }

        public DateTime Creation { get; set; } = DateTime.Now;

        public DateTime Update { get; set; } = DateTime.Now;

        // ------------- Específicas
        /// <summary>
        ///  Clase NetTopologySuite.Geometries
        /// </summary>
        public Point Location { get; set; } // Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660132#notes

        // ------------- Relaciones
        public List<MovieCinema> MovieCinemaList { get; set; } // n..n

    }
}
