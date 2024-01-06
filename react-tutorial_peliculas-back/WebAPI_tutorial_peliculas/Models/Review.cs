using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_tutorial_peliculas.Models
{
    /// <summary>
    /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660150#announcements
    /// </summary>
    public class Review : IId
    {
        // ------------- Genéricas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Creation { get; set; } = DateTime.Now;

        public DateTime Update { get; set; } = DateTime.Now;

        // ------------- Específicas
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Content { get; set; }

        [Range(1, 5)]
        public int Score { get; set; }

        // ------------- Relaciones
        [Required(ErrorMessage = "El campo {0} es requerido")] // n..0 (0=no existe este sin el padre)
        public int MovieId { get; set; } // n..0
        public Movie Movie { get; set; } // n..0 (0=no existe Review sin Book)

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string UserId { get; set; } // n..0 --> en STRING ***********
        public IdentityUser User { get; set; } // n..0 (0=no existe Review sin Book)

    }
}