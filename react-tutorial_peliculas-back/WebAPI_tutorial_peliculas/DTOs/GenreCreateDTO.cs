using System.ComponentModel.DataAnnotations;
using WebAPI_tutorial_peliculas.Validations;

namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Los CreateDTO no llevan ID ni Datetimes de crear o modificar
    /// </summary>
    public class GenreCreateDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [FirstCharCapitalValidation]
        public string Name { get; set; }

    }
}
