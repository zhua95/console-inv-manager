using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager //Zachary Huard 
{
    internal class Program
    {
        class InventoryItem
        {
            public string ID { get; set; }
            public string ShortName { get; set; }
            public string LongDescription { get; set; }
            public double PriceAmount { get; set; }
        }

        class InventoryProgram
        {
            static List<InventoryItem> inventory = new List<InventoryItem>();

            static void Main()
            {
                int choice;
                do
                {
                    DisplayMenu(); //Program menu to make selection process
                    Console.Write("Enter your choice (1-4): ");
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                InsertNewItem();
                                break;
                            case 2:
                                DisplaySingleItem();
                                break;
                            case 3:
                                DisplayAllItems();
                                break;
                            case 4:
                                Console.WriteLine("Exiting the application. Goodbye!");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                } while (choice != 4);
            }

            static void DisplayMenu() //Menu display
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Insert a new item in inventory");
                Console.WriteLine("2. Display an item");
                Console.WriteLine("3. Display all items");
                Console.WriteLine("4. Exit");
            }

            static void InsertNewItem() //Adding new items to inventory
            {
                do
                {
                    Console.WriteLine("\nEnter details for the new item:");
                    InventoryItem newItem = new InventoryItem();

                    Console.Write("ID (3-digit numerical string): ");
                    newItem.ID = Console.ReadLine();

                    Console.Write("Short Name: ");
                    newItem.ShortName = Console.ReadLine();

                    Console.Write("Long Description: ");
                    newItem.LongDescription = Console.ReadLine();

                    Console.Write("Price Amount: $");
                    if (double.TryParse(Console.ReadLine(), out double price))
                    {
                        newItem.PriceAmount = price;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                        continue;
                    }

                    inventory.Add(newItem);

                    Console.Write("\nDo you want to enter another item? (y/n): ");
                } while (Console.ReadLine().ToLower() == "y");
            }

            static void DisplaySingleItem() //Search and display an item using its item id
            {
                Console.Write("\nEnter the ID of the item to display: ");
                string searchID = Console.ReadLine();
                InventoryItem item = inventory.Find(i => i.ID == searchID);

                if (item != null)
                {
                    DisplayItemDetails(item);
                }
                else
                {
                    Console.WriteLine("Item not found with the given ID.");
                }
            }

            static void DisplayAllItems() //Displays all items entered up until the point this option is selected
            {
                if (inventory.Count == 0)
                {
                    Console.WriteLine("No items in inventory.");
                    return;
                }

                Console.WriteLine("\nID\tShort Name\tLong Description\tPrice Amount");
                foreach (var item in inventory)
                {
                    DisplayItemDetails(item);
                }

                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
            }

            static void DisplayItemDetails(InventoryItem item) //Displays all fields for an items entry
            {
                Console.WriteLine($"{item.ID}\t{item.ShortName}\t{item.LongDescription}\t${item.PriceAmount:F2}");
            }
        }
    }    
}

