using System.Linq.Expressions;
using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.Repository.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> Update(Movie entity);
        IQueryable<Movie> GetAllQueryable();

        Task<List<Movie>> FilterByText(List<Expression<Func<Movie, string>>> properties, List<string> searchTerms);

    }
}
