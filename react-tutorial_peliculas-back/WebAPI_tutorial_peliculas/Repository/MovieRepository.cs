using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Repository.Interfaces;
using LinqKit; // Ensure this is imported at the top

namespace WebAPI_tutorial_peliculas.Repository
{
    public class MovieRepository: Repository<Movie>, IMovieRepository
    {
        private readonly DbContext _dbContext;

        public MovieRepository(ContextDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> Update(Movie entity)
        {
            entity.Update = DateTime.Now;
            _dbContext.Update(entity);
            await Save();
            return entity;
        }

        public IQueryable<Movie> GetAllQueryable()
        {
            return dbSet.AsQueryable();
        }

        public async Task<List<Movie>> FilterByText(List<Expression<Func<Movie, string>>> properties, List<string> searchTerms)
        {
            IQueryable<Movie> query = dbSet;
            if (properties == null || !properties.Any() || searchTerms == null || !searchTerms.Any())
                return await query.ToListAsync();

            foreach (var term in searchTerms)
            {
                var termPredicate = PredicateBuilder.New<Movie>(false); // Initialize with 'OR'
                foreach (var property in properties)
                {
                    termPredicate = termPredicate.Or(entity => property.Compile()(entity).Contains(term)); // This still has the compile in the loop; consider optimizing if needed
                }
                query = query.AsExpandable().Where(termPredicate);
            }
            return await query.ToListAsync();
        }


    }
}
