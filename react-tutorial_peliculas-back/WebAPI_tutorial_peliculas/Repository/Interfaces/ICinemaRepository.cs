using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.Repository.Interfaces
{
    public interface ICinemaRepository : IRepository<Cinema>
    {
        Task<Cinema> Update(Cinema entity);
        IQueryable<Cinema> GetAllQueryable();
    }
}
