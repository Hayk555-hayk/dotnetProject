
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var products = new List<Product>
{
    new Product { ID = 1, Name = "Product 1", Price = 10.99m, Description = "Description for Product 1" },
    new Product { ID = 2, Name = "Product 2", Price = 19.99m, Description = "Description for Product 2" },
    new Product { ID = 3, Name = "Product 3", Price = 29.99m, Description = "Description for Product 3" }
};


app.MapGet("/", () => "Api is running !");
app.MapGet("/api/welcome", () => "Welcome to my API !");

app.MapGet("/api/products", () => products);

app.MapPost("/api/products", (Product newProduct) => {
    newProduct.ID = products.Count + 1; 
    products.Add(newProduct);
    return Results.Created($"/api/products/{newProduct.ID}", newProduct);
});

app.Run();