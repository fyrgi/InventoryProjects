using InventoryProjects.Common;
using System;

// Get the path from the app-context to ensure that file is created in the project folder.
string programFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, @"..\..\.."));

FileHandler fileHandler = new FileHandler(programFolder, "products.json");
fileHandler.EnsureFileExists();

List<MenuOption> mainMenuOptions = new()
{
    new MenuOption("Add Product", ProductManager.Add),
    new MenuOption("View Products", ProductManager.View),
    new MenuOption("Search Products", ProductManager.Search),
    new MenuOption("Edit Product", ProductManager.Edit),
    new MenuOption("Remove Product", ProductManager.Remove),
    new MenuOption("Statistics", ProductManager.Statistics),
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
