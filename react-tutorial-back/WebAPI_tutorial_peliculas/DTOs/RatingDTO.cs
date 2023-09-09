using System.ComponentModel.DataAnnotations;

namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// El UserID nunca va en los DTOs porque sería una vulnerabilidad del sistema
    /// </summary>
    public class RatingDTO
    {
        public int MovieId { get; set; }
        [Range(1,5)]
        public int Score { get; set; }
    }
}
