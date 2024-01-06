using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_tutorial_peliculas.Models
{
    public class Movie : IId
    {
        // ------------- Genéricas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Creation { get; set; } = DateTime.Now;

        public DateTime Update { get; set; } = DateTime.Now;

        // ------------- Específicas
        
        public bool OnCinema { get; set; }
        public DateTime Premiere { get; set; }
        public string PosterURL { get; set; }
        public string Trailer { get; set; }

        // ------------- Relaciones
        public List<ActorMovie> ActorMovieList { get; set; } // n..n
        public List<MovieGenre> MovieGenreList { get; set; } // n..n
        public List<MovieCinema> MovieCinemaList { get; set; } // n..n
        public List<Review> ReviewList { get; set; } // 0..n (0=no existe Review sin Book)

    }
}
