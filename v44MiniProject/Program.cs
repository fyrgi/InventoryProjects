using InventoryProjects.Common;
using System;

string dataDirectory = Path.Combine(
    Environment.GetFolderPath(
        Environment.SpecialFolder.LocalApplicationData),
    "InventoryProjects",
    "v44MiniProject");


FileHandler fileHandler = new FileHandler(dataDirectory, "products.json");
fileHandler.EnsureFileExists();
Console.WriteLine($"Data file exists.");
Console.ReadLine();

List<MenuOption> mainMenuOptions = new()
{
    new MenuOption("Add Product", ProductManager.Add),
    new MenuOption("View Products", ViewProducts),
    new MenuOption("Search Products", SearchProducts),
    new MenuOption("Calculate Total Price", CalculateTotalPrice),
    new MenuOption("Statistics", ShowStatistics)
};

Console.ReadLine();

Menu mainMenu = new Menu("Inventory Management", mainMenuOptions);

mainMenu.Show();

void ViewProducts()
{
    Console.WriteLine("View Products selected.");
    Pause();
}

void SearchProducts()
{
    Console.WriteLine("Search Products selected.");
    Pause();
}

void CalculateTotalPrice()
{
    Console.WriteLine("Calculate Total Price selected.");
    Pause();
}

void ShowStatistics()
{
    Console.WriteLine("Statistics selected.");
    Pause();
}

void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to return to the menu...");
    Console.ReadLine();
}

Console.WriteLine();
