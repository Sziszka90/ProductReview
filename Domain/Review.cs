using Azure.Data.Tables;
using Azure;

namespace ProductReview.Domain;
public class Review : ITableEntity
{
    public string PartitionKey { get; set; } = default!;  // Product Name
    public string RowKey { get; set; } = default!;        // Timestamp
    public string ReviewContent { get; set; } = default!;
    public ETag ETag { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
}