using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryProjects.Common
{
    public static class UI
    {
        public static void ShowMessage(string message, string messageType)
        {
            switch (messageType)
            {
                case "error":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "success":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "info":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "warning":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "statistics":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
