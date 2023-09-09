using Microsoft.EntityFrameworkCore;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;

namespace WebAPI_tutorial_peliculas.Repository
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        private readonly DbContext _dbContext;

        public CinemaRepository(ContextDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cinema> Update(Cinema entity)
        {
            entity.Update = DateTime.Now;
            _dbContext.Update(entity);
            await Save();
            return entity;
        }

        public IQueryable<Cinema> GetAllQueryable()
        {
            return dbSet.AsQueryable();
        }

    }
}