using Azure;
using Azure.Data.Tables;
using ProductReview.Domain;

namespace ProductReview.Infrastructure.Abstraction.Repositories;
public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<List<Product>> GetProducts(int pageNumber, int pageSize);
    Task<Response> DeleteAsync(string category, string productId);
}

