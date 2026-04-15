using VendingMachine.Console;
using VendingMachine.Console.Models;
using VendingMachine.Console.Services;


var user = new User(50);

var machine = new Machine();

machine.AddProduct(new Product("Coffee", 15), 5);
machine.AddProduct(new Product("Cola", 20), 3);
machine.AddProduct(new Product("Marabou", 25), 7);

Console.WriteLine("Welcome to this VendingMachine!");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("1. Show products");
    Console.WriteLine("2. Buy product");
    Console.WriteLine("3. Show purchased items");
    Console.WriteLine("4. Show balance");
    Console.WriteLine("5. Exit");
    Console.WriteLine();
    Console.Write("Choose an option: ");

    var input = Console.ReadLine();

    if (input == "1")
    {
        Console.Clear();
        Console.WriteLine("Products:");
        machine.ShowProducts();
    }
    else if (input == "2")
    {
        Console.Clear();
        Console.WriteLine("Products to purchase:");
        machine.ShowProducts();
        Console.WriteLine();
        Console.Write("Which product do you want to buy? Enter number: ");
        var choice = Console.ReadLine();

        if (int.TryParse(choice, out var number))
        {
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
                Console.WriteLine($"You bought {product.Name} for {product.Price} kr!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    else if (input == "3")
    {
        if (user.PurchasedItems.Count == 0)
        {
            Console.WriteLine("You haven't bought anything yet.");
        }
        else
        {
            foreach (var item in user.PurchasedItems)
            {
                Console.WriteLine($"- {item.Name} ({item.Price} kr)");
            }
        }
    }
    else if (input == "4")
    {
        Console.WriteLine($"Your balance: {user.Money} kr");
    }
    else if (input == "5")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice, please try again.");
    }
}