using System;
using System.Collections.Generic;

class Item
{
    public string potionSmall = "Small Potion";
    public string potionLarge = "Large Potion";
    public string biscuitSmall = "Small Biscuit";
    public string biscuitLarge = "Large Biscuit";
}

class Inventory
{

    private List<Item> itemsList = new List<Item>();

    public Inventory addItem(string itemName)
    {
        Item newItem = new Item();
        itemsList.Add(newItem);
        Console.WriteLine($"{itemName} added to the inventory.");
        return this; // Method chaining
    }

    public Inventory useItem(string itemName)
    {
       
           Item itemToRemove = itemsList.Find(item =>
               item.potionSmall == itemName || item.potionLarge == itemName ||
               item.biscuitSmall == itemName || item.biscuitLarge == itemName);

           if (itemToRemove != null)
            {
               Console.WriteLine($"Using {itemName}..");
               itemsList.Remove(itemToRemove);
            }
           else
            {
               Console.WriteLine($"{itemName} not found in the inventory.");
               throw new InvalidOperationException("Item not found in the inventory.");
            }
           return this; // Method chaining

    }

    public void getItems()
    {
        Console.WriteLine("Inventory Items:");
        foreach (var item in itemsList)
        {
            Console.WriteLine($"Item: {item.potionSmall}");
            Console.WriteLine($"Item: {item.potionLarge}");
            Console.WriteLine($"Item: {item.biscuitSmall}");
            Console.WriteLine($"Item: {item.biscuitLarge}");
        }
    }
}

class Program
{
    static void Main()
    {
        Inventory playerInventory = new Inventory();

        while (true)
        {
            Item items = new Item();

            Console.WriteLine($"----------------------------------------");

            Console.WriteLine($"{items.potionSmall}");
            Console.WriteLine($"{items.potionLarge}");
            Console.WriteLine($"{items.biscuitSmall}");
            Console.WriteLine($"{items.biscuitLarge}");

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. View Items");
            Console.WriteLine("4. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the item name: ");
                    string itemName = Console.ReadLine();
                    playerInventory.addItem(itemName);
                    break;
                case 2:
                    Console.WriteLine("Enter the item name to use: ");
                    string itemToUse = Console.ReadLine();
                    try
                    {
                        playerInventory.useItem(itemToUse);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;
                case 3:
                    playerInventory.getItems();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }
    }
}
