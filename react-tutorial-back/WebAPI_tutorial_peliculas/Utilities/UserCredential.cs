using System.ComponentModel.DataAnnotations;

namespace WebAPI_tutorial_peliculas.Utilities
{
    /// <summary>
    /// Entidad auxiliar de .NET Identity (no es tabla en la BD)
    /// </summary>
    public class UserCredential
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
