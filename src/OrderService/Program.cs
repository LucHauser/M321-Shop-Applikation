using ShoppingCartService.Models;
using ShoppingCartService.DatabaseAccess;
using Steeltoe.Discovery.Client;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

app.MapPost("/api/orders", async (OrderDbContext db, Order order) =>
{
    db.Orders.Add(order);
    await db.SaveChangesAsync();
    return Results.Created($"/api/orders/{order.OrderId}", order);
});

app.MapGet("/api/orders/{id}", async (OrderDbContext db, int id) =>
{
    var order = await db.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.OrderId == id);
    return order is not null ? Results.Ok(order) : Results.NotFound();
});

app.MapPut("/api/orders/{id}", async (OrderDbContext db, int id, Order updatedOrder) =>
{
    var order = await db.Orders.FindAsync(id);
    if (order is null) return Results.NotFound();

    order.Status = updatedOrder.Status;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();