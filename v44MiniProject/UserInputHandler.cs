using InventoryProjects.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace v44MiniProject
{
    public class UserInputHandler
    {
        public static Product? GetProductInput()
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

            return new Product(name, category, price.Value);
        }

        private static string? ReadRequiredText(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (q to cancel): ");
                string? input = Console.ReadLine();

                if (input?.Trim().Equals("q",
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