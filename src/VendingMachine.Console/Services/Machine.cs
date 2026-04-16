using System.Text.Json;
using VendingMachine.Console.Models;

namespace VendingMachine.Console.Services;

public class Machine
{
    private readonly Inventory _inventory = new Inventory();

    public void AddProduct(Product product, int quantity)
    {
        _inventory.AddProduct(product, quantity);
    }
    
    public void LoadProductsFromFile(string file)
    {
        var json = File.ReadAllText(file);
        var options = new System.Text.Json.JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var products = System.Text.Json.JsonSerializer.Deserialize<List<ProductData>>(json, options);

        if (products == null) return;

        foreach (var p in products)
        {
            AddProduct(new Product(p.Name, p.Price), p.Quantity);
        }
    }

    public void ShowProducts()
    {
        _inventory.ShowProducts();
    }

    public Product? GetProduct(int index)
    {
        return _inventory.GetProduct(index);
    }

    public void ReduceStock(Product product)
    {
        _inventory.ReduceStock(product);
    }
}