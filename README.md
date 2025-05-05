
# Product Review Service

This service allows users to view, write and delete reviews for products.
Pagination is supported for both entities.
Update is not yet supported.



## Tech Stack



**Backend:** .NET 8
**Tests:** Postman



## Installation

```bash
  cd ProductReview
  dotnet run
```
    
## Configuration

You can use the Postman script in the repo to test the endpoints.

Configuration in appsettings.json:

```json
  "TableStorageSettings": {
    "ConnectionString": "your-connection-string"
  }

```

## Usage

Supported endpoints:

**GET** - /api/products?pageNumber={pageNumber}&pageSize={pageSize}


**POST** - /api/products 

**Parameters** 

| Name | Required | Description |
|------|----------|----------|
| Name | required   | Unique name   |
| Category | required  | Category of the product   |

**DELETE** - /api/products/{category}/{productName} 

**GET** - /api/products/{productName}/reviews?pageNumber={pageNumber}&pageSize={pageSize}

**POST** - /api/products/{productName}/reviews 

**Parameters** 

| Name | Required | Description |
|------|----------|----------|
| ReviewContent | required   | Review content   |


**DELETE** - /api/products/{productName}/reviews/{reviewId}








