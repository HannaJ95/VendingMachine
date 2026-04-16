using VendingMachine.Console.Models;
using VendingMachine.Console.Services;
using VendingMachine.Console.Helpers;

var user = new User(50);
var machine = new Machine();

machine.LoadProductsFromFile("products.json");

Console.WriteLine("Welcome to this VendingMachine!");

while (true)
{
    MenuHelper.ShowMenu();
    var input = Console.ReadLine();

    switch (input)
    {
        case "1": ShowProducts(machine); break;
        case "2": BuyProduct(machine, user); break;
        case "3": ShowPurchasedItems(user); break;
        case "4": ShowBalance(user); break;
        case "5":
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
    Console.WriteLine();
}

static void ShowProducts(Machine machine)
{
    Console.Clear();
    Console.WriteLine("Products:");
    machine.ShowProducts();
}

static void BuyProduct(Machine machine, User user)
{
    Console.Clear();
    Console.WriteLine("Products to purchase:");
    machine.ShowProducts();
    Console.WriteLine();
    Console.Write("Which product do you want to buy? Enter number: ");

    var choice = Console.ReadLine();
    Console.Clear();

    if (!int.TryParse(choice, out var number))
    {
        Console.WriteLine("Invalid choice.");
        return;
    }

    var product = machine.GetProduct(number - 1);

    if (product == null)
    {
        Console.Clear();
        Console.WriteLine("Invalid choice.");
    }
    else if (!user.CanAfford(product))
    {
        Console.WriteLine("You don't have enough money.");
    }
    else
    {
        user.Pay(product.Price);
        user.PurchasedItems.Add(product);
        machine.ReduceStock(product);
        Console.Clear();
        Console.WriteLine($"You bought {product.Name} for {product.Price} kr!");
    }
}

static void ShowPurchasedItems(User user)
{
    Console.Clear();
    if (user.PurchasedItems.Count == 0)
    {
        Console.WriteLine("You haven't bought anything yet.");
        return;
    }

    Console.WriteLine("Purchased items:");
    foreach (var item in user.PurchasedItems)
    {
        Console.WriteLine($"  - {item.Name} ({item.Price} kr)");
    }
}

static void ShowBalance(User user)
{
    Console.Clear();
    Console.WriteLine($"Your balance: {user.Money} kr");
}
