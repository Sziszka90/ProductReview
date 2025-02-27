using System.Data.Common;
using Azure;
using Azure.Data.Tables;

namespace ProductReview.Domain;

public class Product : ITableEntity
{
    public string PartitionKey { get; set; } = default!; // Product Type
    public string RowKey { get; set; } = default!;       // Product Name
    public ETag ETag { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
}

