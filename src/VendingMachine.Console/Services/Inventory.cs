using VendingMachine.Console.Models;

namespace VendingMachine.Console.Services;

public class Inventory
{
    private readonly List<Product> _products = new List<Product>();
    private readonly Dictionary<string, int> _stock = new Dictionary<string, int>();

    public void AddProduct(Product product, int quantity)
    {
        if (!_stock.ContainsKey(product.Name))
        {
            _products.Add(product);
            _stock[product.Name] = quantity;
        }
        else
        {
            _stock[product.Name] += quantity;
        }
    }
    
    public void ShowProducts()
    {
        for (var i = 0; i < _products.Count; i++)
        {
            var product = _products[i];
            var quantity = _stock[product.Name];
            System.Console.WriteLine($"{i + 1}. {product.Name} - {product.Price} kr ({quantity} st)");
        }
    }

    public Product? GetProduct(int index)
    {
        if (index < 0 || index >= _products.Count)
        {
            return null;
        }

        var product = _products[index];

        if (_stock[product.Name] <= 0)
        {
            return null;
        }

        return product;
    }

    public void ReduceStock(Product product)
    {
        _stock[product.Name]--;
    }
}