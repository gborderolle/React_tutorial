using WebAPI_tutorial_peliculas.Utilities.HATEOAS;

namespace WebAPI_tutorial_peliculas.DTOs
{
    public class ReviewDTO : Resource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public string MovieId { get; set; } // n..0
        public string UserId { get; set; } // n..0
        public string UserName { get; set; }

    }
}
