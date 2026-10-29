namespace InventoryProjects.Common;

    public class Menu
    {
        private readonly string _title;
        private readonly List<MenuOption> _options;
        public Menu(string title, List<MenuOption> options)
        {
            _title = title;
            _options = options;
        }
        public void Show()
        {
            while(true)
            {
                Console.Clear();

                Console.WriteLine(_title);
                Console.WriteLine();

                for(int i = 0; i < _options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_options[i].Text}");
                }

                Console.WriteLine("0. Exit");
                Console.Write("\nChoose an option: ");

                string? input = Console.ReadLine();

                if(input == "0")
                    return;

                if(int.TryParse(input, out int choice) &&
                    choice >= 1 &&
                    choice <= _options.Count)
                {
                    _options[choice - 1].Action.Invoke();
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Console.ReadLine();
                }
            }
        }
    }

