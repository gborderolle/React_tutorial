namespace WebAPI_tutorial_peliculas.DTOs
{
    public class MovieFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public PaginationDTO Pagination
        {
            get
            {
                return new PaginationDTO()
                {
                    Page = Page,
                    RecordsPerPage = RecordsPerPage
                };
            }
        }

        public string Title { get; set; }
        public int GenreId { get; set; }
        public bool OnCinema { get; set; }
        public bool NextPremiere { get; set; }

    }
}
