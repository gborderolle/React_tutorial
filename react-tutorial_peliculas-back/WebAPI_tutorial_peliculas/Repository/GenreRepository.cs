using Microsoft.EntityFrameworkCore;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;

namespace WebAPI_tutorial_peliculas.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly DbContext _dbContext;

        public GenreRepository(ContextDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> Update(Genre entity)
        {
            entity.Update = DateTime.Now;
            _dbContext.Update(entity);
            await Save();
            return entity;
        }

        public IQueryable<Genre> GetAllQueryable()
        {
            return dbSet.AsQueryable();
        }

    }
}
