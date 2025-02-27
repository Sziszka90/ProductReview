using Azure.Data.Tables;
using Microsoft.Extensions.Options;
using ProductReview.Application.Abstraction.Services;
using ProductReview.Application.Services;
using ProductReview.Infrastructure.Abstraction.Factories;
using ProductReview.Infrastructure.Abstraction.Repositories;
using ProductReview.Infrastructure.Repositories;
using ProductReview.Infrastructure.TableClients;
using System.Runtime;
using ProductReview.Infrastructure.Configurations;
using ProductReview.Infrastructure.Abstraction.Services;
using ProductReview.Infrastructure.Services;

namespace ProductReview.Presentation.Extensions;

public static class CommonExtensions
{
    public static WebApplicationBuilder SetupTableClients(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("TableStorageSettings")
            .Get<TableStorageSettings>()?.ConnectionString;

        builder.Services.AddSingleton(sp =>
            new TableServiceClient(connectionString));

        builder.Services.AddSingleton<IInitializationService, InitializationService>();

        builder.Services.AddScoped<ITableClientFactory, TableClientFactory>();

        return builder;
    }

    public static WebApplicationBuilder SetupRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        return builder;
    }

    public static WebApplicationBuilder SetupStorageServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductStorageService, ProductStorageService>();
        builder.Services.AddScoped<IReviewStorageService, ReviewStorageService>();
        return builder;
    }
}
