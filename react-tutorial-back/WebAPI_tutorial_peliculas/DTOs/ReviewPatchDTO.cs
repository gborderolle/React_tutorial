using System.ComponentModel.DataAnnotations;

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class ReviewPatchDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Content { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int UserId { get; set; }
    }
}
