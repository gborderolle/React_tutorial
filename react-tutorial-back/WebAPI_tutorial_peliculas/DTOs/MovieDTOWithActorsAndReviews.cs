namespace WebAPI_tutorial_peliculas.DTOs
{
    public class MovieDTOWithActorsAndReviews : MovieDTO
    {
        public List<ActorDTO> ActorList { get; set; }
        //public List<ReviewDTO> ReviewList { get; set; }
    }
}