using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Application.Abstraction.Services;
using ProductReview.Application.Dtos.ProductDtos;
using ProductReview.Application.Dtos.ReviewDtos;
using System.Net;

namespace ProductReview.Presentation.Controllers;


[Route("api/products/{productName}/reviews")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IReviewStorageService _reviewStorageService;
    public ReviewsController(IReviewStorageService reviewStorageService)
    {
        _reviewStorageService = reviewStorageService;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(string productName, [FromBody] CreateReviewDto createReviewDto)
    {
        var response = await _reviewStorageService.AddReview(productName, createReviewDto);
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> DeleteReview(string productName, string reviewId)
    {
        var response = await _reviewStorageService.DeleteReview(productName, reviewId);
        return StatusCode(response.Status, response.Content);
    }

    [HttpGet]
    public async Task<IActionResult> GetReviews(string productName, [FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var reviews = await _reviewStorageService.GetReviews(productName, pageSize, pageNumber);
        return Ok(reviews);
    }
}