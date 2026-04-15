namespace VendingMachine.Console;

public class Machine
{
    private readonly Inventory _inventory = new Inventory();

    public void AddProduct(Product product, int quantity)
    {
        _inventory.AddProduct(product, quantity);
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