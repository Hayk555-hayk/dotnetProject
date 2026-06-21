var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Api is running !");
app.MapGet("/api/welcome", () => "Welcome to my API !");

app.Run();