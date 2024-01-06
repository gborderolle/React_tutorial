using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_tutorial_peliculas.Models
{
    public class Actor : IId
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

        public string Biography { get; set; }

        public string PhotoURL { get; set; }

        public DateTime Born { get; set; }

        // ------------- Relaciones
        public List<ActorMovie> ActorMovieList { get; set; } // n..n

    }
}
