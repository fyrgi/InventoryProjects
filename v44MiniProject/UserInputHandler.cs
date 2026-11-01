using InventoryProjects.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace v44MiniProject
{
    public class UserInputHandler
    {
        public static Product? GetProductInput(int maxId)
        {
            string? name = ReadRequiredText("Product name");
            if (name == null)
                return null;

            string? category = ReadRequiredText("Category");
            if (category == null)
                return null;

            double? price = ReadPrice();
            if (price == null)
                return null;

            return new Product(maxId + 1, name, category, price.Value);
        }

        // Create a Submenu for editing a product's name, category, or price
        public static void EditProduct(Product product)
        {
            while (true)
            {
                Console.WriteLine("\n==== Edit Product ====");
                Console.WriteLine($"1. Name: {product.Name}");
                Console.WriteLine($"2. Category: {product.CategoryManual}");
                Console.WriteLine($"3. Price: {product.Price}");
                Console.WriteLine("4. Cancel");
                Console.Write("Select an option to edit (1-4): ");
                string? input = Console.ReadLine();
                if (input == "4")
                    break;
                switch (input)
                {
                    case "1":
                        string? newName = ReadRequiredText("New name:");
                        if (newName != null)
                            product.Name = newName;
                        break;
                    case "2":
                        string? newCategory = ReadRequiredText("New category");
                        if (newCategory != null)
                            product.CategoryManual = newCategory;
                        break;
                    case "3":
                        double? newPrice = ReadPrice();
                        if (newPrice != null)
                            product.Price = newPrice.Value;
                        break;
                    default:
                        UI.ShowMessage("Invalid option. Please try again.", "error");
                        break;
                }
            }
        }

        private static string? ReadRequiredText(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (q to cancel): ");
                string? input = Console.ReadLine();

                if (input?.Trim().ToLower().Equals("q",
                    StringComparison.OrdinalIgnoreCase) == true)
                    return null;

                if (string.IsNullOrWhiteSpace(input))
                {
                    UI.ShowMessage($"{prompt} cannot be empty.", "error");
                    continue;
                }

                return input.Trim();
            }
        }
        private static double? ReadPrice()
        {
            while (true)
            {
                Console.Write("Price (q to cancel): ");
                string? input = Console.ReadLine();

                if (input?.Trim().Equals("q") == true)
                    return null;

                if (!double.TryParse(input, out double price) || price < 0)
                {
                    UI.ShowMessage("Invalid price. Please try again.", "error");
                    continue;
                }

                return price;
            }
        }
    }
}