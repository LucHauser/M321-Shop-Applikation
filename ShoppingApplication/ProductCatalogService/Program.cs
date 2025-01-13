using ProductCatalogService.Models;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Product>? testProductBacklog = new List<Product>
{
    new Product { Id = 1, Name = "Product 1", Price = 99.99f },
    new Product { Id = 2, Name = "Product 2", Price = 149.99f },
    new Product { Id = 3, Name = "Product 3", Price = 199.99f }
};

// Define minimal API routes.
app.MapGet("/api/products", () =>
{
    return testProductBacklog;
})
.WithName("GetAllProducts")
.WithOpenApi();

app.MapGet("/api/products/{id}", (int id) =>
{
    Product? product = testProductBacklog.FirstOrDefault(p => p.Id == id);

    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
})
.WithName("GetProductById")
.WithOpenApi();

app.Run();