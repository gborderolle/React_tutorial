namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Esta clase sirve de apoyo al IdentityUser
    /// El UserID nunca va en los DTOs porque sería una vulnerabilidad del sistema
    /// En el Context la tabla es .Users
    /// 
    /// Cuidado: uso este Id en el front
    /// </summary>
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }

    }
}