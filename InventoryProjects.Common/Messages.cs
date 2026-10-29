
namespace InventoryProjects.Common
{
    public class Messages
    {
        public static void showMessage(string message, string messageType)
        {
            switch(messageType)
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
        }
    }
}
