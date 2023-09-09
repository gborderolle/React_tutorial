using System.ComponentModel.DataAnnotations;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Validations;

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class CinemaPatchDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [FirstCharCapitalValidation]
        public string Name { get; set; }
    }
}
