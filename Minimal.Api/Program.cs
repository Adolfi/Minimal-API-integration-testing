using Minimal.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var products = new Product[] { 
    new Product(1, "Table", 100),
    new Product(2, "Chair", 200),
    new Product(3, "Desk", 300),
    new Product(4, "Computer", 400),
    new Product(5, "Beer fridge", 500)
};
app.MapGet("/products", () => { return products; });
app.Run();

public partial class Program { }





