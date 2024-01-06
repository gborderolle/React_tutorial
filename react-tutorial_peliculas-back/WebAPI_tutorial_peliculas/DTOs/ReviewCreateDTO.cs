using System.ComponentModel.DataAnnotations;

namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Los CreateDTO no llevan ID ni Datetimes de crear o modificar
    /// Acá no puede venir el UserID porque es info sensible, tiene que venir del JsonWebToken -> Controller: HttpContext.User.Claims...
    /// </summary>
    public class ReviewCreateDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Content { get; set; }

        [Range(1, 5)]
        public int Score { get; set; }

    }
}