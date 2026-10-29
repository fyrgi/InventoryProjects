using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Text.Json;

namespace InventoryProjects.Common
{
    public class ProductManager
    {
        // Add, view, update and delete products
        public static void Add()
        {
            Console.WriteLine("adding product from class Product Manager");
        }


        void viewProducts()
        {
            try
            {
                string programFolder = AppContext.BaseDirectory;
                string filePath = Path.Combine(programFolder, "products.txt");
                if (File.Exists(filePath))
                {
                    string[] products = File.ReadAllLines(filePath);
                    //sortDisplayProducts(products);
                    if (products.Length > 0)
                    {
                        Console.WriteLine("\n==== Product List: ====");
                        foreach (string product in products)
                        {
                            Console.WriteLine(product);
                        }
                        Console.WriteLine("==== End of List ====\n");
                    }
                    else
                    {
                        UI.showMessage("No products found.\n", "warning");
                    }
                }
                else
                {
                    UI.showMessage("The product file is not found!\nContat System Administrator!", "error");
                }
            }
            catch (Exception ex)
            {
                UI.showMessage($"Error reading from file: {ex.Message}" , "error");
            }
        }
        // Search by ID, name or category
        // Sort by price
        // Calculate totals
        // statistics
    }
}
