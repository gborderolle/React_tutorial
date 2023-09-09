using Microsoft.EntityFrameworkCore;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;

namespace WebAPI_tutorial_peliculas.Repository
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        private readonly DbContext _dbContext;

        public ActorRepository(ContextDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Actor> Update(Actor entity)
        {
            entity.Update = DateTime.Now;
            _dbContext.Update(entity);
            await Save();
            return entity;
        }

        public IQueryable<Actor> GetAllQueryable()
        {
            return dbSet.AsQueryable();
        }

    }
}