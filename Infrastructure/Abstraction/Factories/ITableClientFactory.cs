using Azure.Data.Tables;
using Azure.Data.Tables.Models;

namespace ProductReview.Infrastructure.Abstraction.Factories;

public interface ITableClientFactory
{
    public TableClient GetTableClient<T>();
}
