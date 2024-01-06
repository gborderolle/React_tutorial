using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.Repository.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<Genre> Update(Genre entity);
        IQueryable<Genre> GetAllQueryable();
    }
}
