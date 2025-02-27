using AutoMapper;
using Azure;
using Azure.Data.Tables;
using ProductReview.Application.Abstraction.Services;
using ProductReview.Application.Dtos.ProductDtos;
using ProductReview.Application.Dtos.ReviewDtos;
using ProductReview.Domain;
using ProductReview.Infrastructure.Abstraction.Repositories;

namespace ProductReview.Application.Services;

public class ReviewStorageService : IReviewStorageService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewStorageService(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<GetReviewDto> AddReview(string productName, CreateReviewDto createReviewDto)
    {
        var review = new Review
        {
            PartitionKey = productName,
            ReviewContent = createReviewDto.ReviewContent
        };

        var result = await _reviewRepository.AddAsync(review);
        return _mapper.Map<GetReviewDto>(result);
    }

    public async Task<List<GetReviewDto>> GetReviews(string productName, int pageSize, int pageNumber)
    {
        var result = await _reviewRepository.GetReviews(productName, pageNumber, pageSize);
        return _mapper.Map<List<GetReviewDto>>(result);
    }

    public async Task<Response> DeleteReview(string partitionKey, string reviewId)
    {
        return await _reviewRepository.DeleteAsync(partitionKey, reviewId);
    }
}