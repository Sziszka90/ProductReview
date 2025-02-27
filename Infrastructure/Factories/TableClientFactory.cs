using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using ProductReview.Domain;
using ProductReview.Infrastructure.Abstraction.Factories;

namespace ProductReview.Infrastructure.TableClients;

public class TableClientFactory : ITableClientFactory
{
    private readonly TableServiceClient _tableServiceClient;

    public TableClientFactory(TableServiceClient tableServiceClient)
    {
        _tableServiceClient = tableServiceClient;
    }

    public TableClient GetTableClient<T>()
    {
        return _tableServiceClient.GetTableClient(typeof(T).Name);
    }
}

