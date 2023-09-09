using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.Repository.Interfaces
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task<Actor> Update(Actor entity);
        IQueryable<Actor> GetAllQueryable();
    }
}
