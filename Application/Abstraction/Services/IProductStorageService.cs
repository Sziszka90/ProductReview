using Azure;
using ProductReview.Application.Dtos.ProductDtos;
using ProductReview.Domain;

namespace ProductReview.Application.Abstraction.Services;

public interface IProductStorageService
{
    public Task<GetProductDto> AddProduct(CreateProductDto createProductDto);
    public Task<Response> DeleteProduct(string category, string productName);
    public Task<List<GetProductDto>> GetProducts(int pageSize, int pageNumber);
}
