using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryProjects.Common
{
    internal class InputValidator
    {
        public static bool IsValidPrice(decimal price)
        {
            return price >= 0;
        }

        public static bool IsValidQuantity(int quantity)
        {
            return quantity > 0;
        }

        public static bool IsValid(string? name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

    }
}
