using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.Repository.Interfaces;

namespace WebAPI_tutorial_peliculas.Filters
{
    /// <summary>
    /// Clase: https://www.udemy.com/course/construyendo-web-apis-restful-con-aspnet-core/learn/lecture/20660150#notes
    /// </summary>
    public class MovieExistsAttribute : Attribute, IAsyncResourceFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMovieRepository _movieRepository;

        public MovieExistsAttribute(IHttpContextAccessor httpContextAccessor, IMovieRepository movieRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _movieRepository = movieRepository;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var movieIdObject = _httpContextAccessor.HttpContext.Request.RouteValues["movieId"]; // toma el valor de la URL
            if (movieIdObject == null)
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundResult();
                return;
            }
            var movieId = 0;
            if (!int.TryParse(movieIdObject.ToString(), out movieId))
            {
                movieId = 0;
                _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundResult();
                return;
            }
            else
            {
                var movieExists = await _movieRepository.Get(x => x.Id == movieId);
                if (movieExists == null)
                {
                    _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new NotFoundResult();
                }
                else
                {
                    await next();
                }
            }
        }

    }
}