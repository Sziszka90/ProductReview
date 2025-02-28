using Azure;
using Azure.Data.Tables;
using ProductReview.Domain;
using ProductReview.Infrastructure.Abstraction.Factories;
using ProductReview.Infrastructure.Abstraction.Repositories;

namespace ProductReview.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ITableClientFactory _tableClientFactory;
    private readonly TableClient _tableClient;

    public ReviewRepository(ITableClientFactory tableClientFactory)
    {
        _tableClientFactory = tableClientFactory;
        _tableClient = _tableClientFactory.GetTableClient<Review>();
    }

    public async Task<Review> AddAsync(Review review)
    {
        review.RowKey = DateTime.UtcNow.Ticks.ToString();
        await _tableClient.AddEntityAsync(review);
        return await _tableClient.GetEntityAsync<Review>(review.PartitionKey, review.RowKey);
    }

    public async Task DeleteAllForProductAsync(string productName)
    {
        await foreach (var entity in _tableClient.QueryAsync<TableEntity>(e => e.PartitionKey == productName))
        {
            await _tableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);
            Console.WriteLine($"Deleted entity with RowKey: {entity.RowKey}");
        }

        Console.WriteLine("All entities with the specified PartitionKey have been deleted.");
    }

    public async Task<Response> DeleteAsync(string productName, string reviewId)
    {
        return await _tableClient.DeleteEntityAsync(productName, reviewId);
    }

    public async Task<List<Review>> GetReviews(string productName, int pageNumber, int pageSize)
    {
        var continuationToken = string.Empty;
        var currentPage = 0;
        var entities = new List<Review>();

        var filter = TableClient.CreateQueryFilter<Review>(r => r.PartitionKey == productName);

        var queryResults =  _tableClient.QueryAsync<Review>(filter: filter, maxPerPage: pageSize);

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