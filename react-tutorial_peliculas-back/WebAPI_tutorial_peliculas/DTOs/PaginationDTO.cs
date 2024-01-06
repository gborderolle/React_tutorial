﻿namespace WebAPI_tutorial_peliculas.DTOs
{
    /// <summary>
    /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20232284#overview
    /// </summary>
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int recordsPerPage = 10;
        private readonly int pageMaxSize = 50;

        public int RecordsPerPage
        {
            get => recordsPerPage;
            set { recordsPerPage = (value > pageMaxSize) ? pageMaxSize : value; }
        }

    }
}
