using ProductReview.Application.Mappings;
using ProductReview.Infrastructure.Abstraction.Services;
using ProductReview.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.SetupTableClients(builder.Configuration);
builder.SetupRepositories();
builder.SetupStorageServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ProductProfile), typeof(ReviewProfile));


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var initializationService = scope.ServiceProvider.GetRequiredService<IInitializationService>();
    await initializationService.InitAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
