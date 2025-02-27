
using Azure;
using Azure.Data.Tables;
using ProductReview.Domain;
using ProductReview.Infrastructure.Abstraction.Services;

namespace ProductReview.Infrastructure.Services;

public class InitializationService : IInitializationService 
{
    
    private readonly List<string> _tableNames = [nameof(Product), nameof(Review)];
    private readonly TableServiceClient _tableServiceClient;

    public InitializationService(TableServiceClient tableServiceClient) {

        _tableServiceClient = tableServiceClient;
    }

    public async Task InitAsync()
    {
        try
        {
            foreach (var tableClient in _tableNames.Select(tableName => _tableServiceClient.GetTableClient(tableName)))
            {
                await tableClient.CreateIfNotExistsAsync();
            }
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine("Create existing table throws the following exception:");
            Console.WriteLine(e.Message);
        }
    }
}