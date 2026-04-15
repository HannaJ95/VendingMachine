namespace VendingMachine.Console.Models;

public class User
{
    public decimal Money { get; private set; }
    public List<Product> PurchasedItems { get; } = new List<Product>();

    public User(decimal money)
    {
        Money = money;
    }

    public bool CanAfford(Product product)
    {
        return Money >= product.Price;
    }

    public void Pay(decimal amount)
    {
        Money -= amount;
    }
}