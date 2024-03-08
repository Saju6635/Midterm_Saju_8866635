using System;

public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        //  Initialize the properties with the values passed to the constructor.
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
        Console.WriteLine($"Price of {ItemName} updated to : ${newPrice} :)");
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
        Console.WriteLine($"{additionalQuantity} {ItemName} added to the stock. Now Total is : {QuantityInStock}");
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        if (QuantityInStock >= quantitySold)
        {
            QuantityInStock -= quantitySold;
            Console.WriteLine($"{quantitySold} {ItemName} sold. Now the remaining quantity is : {QuantityInStock}");
        }
        else
        {
            Console.WriteLine($"Insufficient stock:(, Only {QuantityInStock} {ItemName} available.");
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName}");
        Console.WriteLine($"Item ID: {ItemId}");
        Console.WriteLine($"Price: ${Price}");
        Console.WriteLine($"Quantity in Stock: {QuantityInStock}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem laptop = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem smartphone = new InventoryItem("Smartphone", 102, 800.30, 15);

        // logic to interact with these objects.

        Console.WriteLine("__MAIN MENU__");
        Console.WriteLine("_-_-_-_-_-_-_-");
        Console.WriteLine("1.View the details of all items");
        Console.WriteLine("2.Sell items");
        Console.WriteLine("3.Restock items");
        Console.WriteLine("4.Check if an item is in stock");
        Console.WriteLine("5.Update item price");
        Console.WriteLine("6.Exit");

        bool exit = false;
        while (!exit)
        {
            Console.Write("\n Please enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1://Print details of all items.
                    Console.WriteLine("\n Details of all items:");
                    Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-");
                    laptop.PrintDetails();
                    Console.WriteLine();
                    smartphone.PrintDetails();
                    break;

                case 2:// Sell some items and then print the updated details.
                    Console.WriteLine("\n Selling some items:");
                    Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-");
                    Console.Write("Enter the quantity of laptops that you wanna sell: ");
                    int sellLaptopQuantity = Convert.ToInt32(Console.ReadLine());
                    laptop.SellItem(sellLaptopQuantity);
                    Console.Write("Enter the quantity of smartphones that you wanna sell: ");
                    int sellSmartphoneQuantity = Convert.ToInt32(Console.ReadLine());
                    smartphone.SellItem(sellSmartphoneQuantity);
                    break;

                case 3://Restock an item and print the updated details.
                    Console.WriteLine("\n Restocking an item:");
                    Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-");
                    Console.Write("Enter the quantity to restock for Laptop: ");
                    int restoLaptopQuantity = Convert.ToInt32(Console.ReadLine());
                    laptop.RestockItem(restoLaptopQuantity);
                    Console.Write("Enter the quantity to restock for Smartphone: ");
                    int restoSmartphoneQuantity = Convert.ToInt32(Console.ReadLine());
                    smartphone.RestockItem(restoSmartphoneQuantity);
                    break;

                case 4://Check if an item is in stock and print a message accordingly.
                    Console.WriteLine("\n Checking if an item is in the stock:");
                    Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
                    Console.WriteLine($"Laptop in stock : {laptop.IsInStock()}");
                    Console.WriteLine($"Smartphone in stock : {smartphone.IsInStock()}");
                    break;

                case 5://Updating item prices
                    Console.WriteLine("\n Updating item price:");
                    Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-");
                    Console.Write("Enter the new price for Laptop that you wanna update: ");
                    double newLaptopPrice = Convert.ToDouble(Console.ReadLine());
                    laptop.UpdatePrice(newLaptopPrice);
                    Console.Write("Enter the new price for Smartphone that you wanna update: ");
                    double newSmartphonePrice = Convert.ToDouble(Console.ReadLine());
                    smartphone.UpdatePrice(newSmartphonePrice);
                    break;

                case 6://exit from the program
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice, Please enter a number from 1 to 6 checking the Main Menu.");
                    break;
            }
        }
    }
}