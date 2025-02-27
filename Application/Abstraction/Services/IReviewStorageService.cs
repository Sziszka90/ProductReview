using Azure;
using ProductReview.Application.Dtos.ProductDtos;
using ProductReview.Application.Dtos.ReviewDtos;
using ProductReview.Domain;

namespace ProductReview.Application.Abstraction.Services;
    
public interface IReviewStorageService
{
    public Task<GetReviewDto> AddReview(string partitionKey, CreateReviewDto createReviewDto);
    public Task<Response> DeleteReview(string partitionKey, string reviewId);
    public Task<List<GetReviewDto>> GetReviews(string productName, int pageSize, int pageNumber);
}
