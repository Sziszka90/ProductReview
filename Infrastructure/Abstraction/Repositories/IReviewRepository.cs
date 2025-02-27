using Azure;
using Azure.Data.Tables;
using ProductReview.Domain;

namespace ProductReview.Infrastructure.Abstraction.Repositories;
public interface IReviewRepository
{
    Task<Review> AddAsync(Review review);
    Task<List<Review>> GetReviews(string productId, int pageNumber, int pageSize);
    Task<Response> DeleteAsync(string productId, string reviewId);
}

