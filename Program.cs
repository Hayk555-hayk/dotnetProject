using dotnetProject.Models;
using dotnetProject.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

app.MapGet("/", () => "Api is running !");
app.MapGet("/api/welcome", () => "Welcome to my API !");

app.MapGet("/api/products", async (AppDbContext context) => await context.Products.ToListAsync());

app.MapGet("/api/products/{id}", async (AppDbContext context, int id) =>
{
    var product = context.Products.Find(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.MapPost("/api/products", async (AppDbContext context, Product newProduct) => {
    context.Products.Add(newProduct);
        await context.SaveChangesAsync();
        return Results.Created($"/api/products/{newProduct.ID}", newProduct);
});

app.Run();