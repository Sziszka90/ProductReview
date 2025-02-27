using Azure.Data.Tables;
using ProductReview.Domain;
using System.ClientModel;
using AutoMapper;
using Azure;
using ProductReview.Application.Abstraction.Services;
using ProductReview.Application.Dtos.ProductDtos;
using ProductReview.Infrastructure.Abstraction.Repositories;

namespace ProductReview.Application.Services;

public class ProductStorageService : IProductStorageService
{
    private readonly IProductRepository _productRepository;
    public readonly IMapper _mapper;

    public ProductStorageService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductDto> AddProduct(CreateProductDto createProductDto)
    {
        var product = new Product
        {
            RowKey = createProductDto.Name,
            PartitionKey = createProductDto.Category,
        };

        var result = await _productRepository.AddAsync(product);

        return _mapper.Map<GetProductDto>(result);
    }

    public async Task<List<GetProductDto>> GetProducts(int pageSize, int pageNumber)
    {
        var result = await _productRepository.GetProducts(pageNumber, pageSize);
        return _mapper.Map<List<GetProductDto>>(result);
    }

    public async Task<Response> DeleteProduct(string category, string productName)
    {
        return await _productRepository.DeleteAsync(category, productName);
    }
}

