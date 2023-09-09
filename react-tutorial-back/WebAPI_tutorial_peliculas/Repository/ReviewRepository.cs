using Microsoft.EntityFrameworkCore;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;

namespace WebAPI_tutorial_peliculas.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly DbContext _dbContext;

        public ReviewRepository(ContextDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Review> Update(Review entity)
        {
            entity.Update = DateTime.Now;
            _dbContext.Update(entity);
            await Save();
            return entity;
        }

        public IQueryable<Review> GetAllQueryable()
        {
            return dbSet.AsQueryable();
        }

    }
}