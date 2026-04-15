using System;
namespace VendingMachine.Console.Helpers;

public static class MenuHelper
{
    public static void ShowMenu()
    {
        string[] menuOptions =
        [
            "Show products",
            "Buy product",
            "Show purchased items",
            "Show balance",
            "Exit"
        ];

        for (int i = 0; i < menuOptions.Length; i++)
        {
            System.Console.WriteLine($"{i+1}. {menuOptions[i]}");
        }
        System.Console.WriteLine();
        System.Console.Write("Choose an option: ");
    }
}