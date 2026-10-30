using InventoryProjects.Common;
using System;
using System.Text.Json;
using v44MiniProject;

// Get the path from the app-context to ensure that file is created in the project folder.
string programFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, @"..\..\.."));

FileHandler _fileHandler = new FileHandler(programFolder, "products.json");
_fileHandler.EnsureFileExists();

ProductManager productManager = new ProductManager();

List<MenuOption> mainMenuOptions = new()
{
    new MenuOption("Add Product", AddProduct),
    new MenuOption("View Products", productManager.View),
    new MenuOption("Search Products", productManager.Search),
    new MenuOption("Edit Product", productManager.Edit),
    new MenuOption("Remove Product", productManager.Remove),
    new MenuOption("Statistics", productManager.Statistics),
};

Console.ReadLine();

Menu mainMenu = new Menu("Inventory Management", mainMenuOptions);

mainMenu.Show();

void AddProduct()
{
    Product? product = UserInputHandler.GetProductInput();

    if (product is not null)
    {
        productManager.Add(product);

        string json = JsonSerializer.Serialize(
            productManager.Products,
            new JsonSerializerOptions { WriteIndented = true });

        _fileHandler.WriteAllText(json);

        UI.ShowMessage("Product added successfully!", "success");
    } else
    {
        UI.ShowMessage("Product addition cancelled. No product was added.", "info");
        return;
    }
    AddProduct();
}

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
