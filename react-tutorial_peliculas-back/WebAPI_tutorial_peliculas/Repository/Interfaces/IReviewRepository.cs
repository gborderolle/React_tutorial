using WebAPI_tutorial_peliculas.Models;

namespace WebAPI_tutorial_peliculas.Repository.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<Review> Update(Review entity);
        IQueryable<Review> GetAllQueryable();
    }
}
