using Azure.Data.Tables;
using ProductReview.Domain;
using Azure;
using ProductReview.Infrastructure.Abstraction.Factories;
using ProductReview.Infrastructure.Abstraction.Repositories;

namespace ProductReview.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ITableClientFactory _tableClientFactory;
    private readonly TableClient _tableClient;

    public ProductRepository(ITableClientFactory tableClientFactory)
    {
        _tableClientFactory = tableClientFactory;
        _tableClient = _tableClientFactory.GetTableClient<Product>();
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _tableClient.AddEntityAsync(product);
        return await _tableClient.GetEntityAsync<Product>(product.PartitionKey, product.RowKey);
    }

    public async Task<Response> DeleteAsync(string category, string productId)
    {
        return await _tableClient.DeleteEntityAsync(category, productId);
    }

    public async Task<List<Product>> GetProducts(int pageNumber, int pageSize)
    {
        var continuationToken = string.Empty;
        var currentPage = 0;
        var entities = new List<Product>();

        var queryResults = _tableClient.QueryAsync<Product>(maxPerPage: pageSize);

        await foreach (var page in queryResults.AsPages(continuationToken))
        {
            currentPage++;

            if (currentPage == pageNumber)
            {
                entities.AddRange(page.Values);
            }

            continuationToken = page.ContinuationToken;

            if (string.IsNullOrEmpty(continuationToken))
                break;
        }
        return entities;
    }
}

