using ShoppingCartService.Models;
using ShoppingCartService.DatabaseAccess;
using Steeltoe.Discovery.Client;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Default"),
    new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// POST /api/orders
app.MapPost("/api/orders", async (OrderDbContext dbContext, Order order) =>
{
    dbContext.Orders.Add(order);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/api/orders/{order.OrderId}", order);
});

// GET /api/orders/{id}
app.MapGet("/api/orders/{id}", async (OrderDbContext dbContext, int id) =>
{
    var order = await dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.OrderId == id);
    if (order == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(order);
});

// PUT /api/orders/{id}
app.MapPut("/api/orders/{id}", async (OrderDbContext dbContext, int id, string status) =>
{
    var order = await dbContext.Orders.FindAsync(id);
    if (order == null)
    {
        return Results.NotFound();
    }

    order.Status = status;
    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();