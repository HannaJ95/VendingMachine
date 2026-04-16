# VendingMachine

A simple console-based project where the user can buy items from a virtual vending machine.

## Features

- View available products with price and stock
- Buy items if the user has enough money
- View purchased items and current balance
- Products are loaded from a JSON file

## Structure

The project is built using an object-oriented approach with the following classes:

- **Product** — represents an item with a name and price
- **Inventory** — handles stock levels for the products
- **Machine** — the vending machine itself
- **User** — the user with money and purchased items

## Technologies

- C#
- .NET 10
- System.Text.Json for loading products from file