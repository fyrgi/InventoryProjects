using InventoryProjects.Common;
using System;
using System.Text.Json;
using v44MiniProject;

// Get the path from the app-context to ensure that file is created in the project folder.
string programFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, @"..\..\.."));

FileHandler _fileHandler = new FileHandler(programFolder, "products.json");
_fileHandler.EnsureFileExists();

string content = _fileHandler.ReadAllText();

List<ProductJson> savedProducts = 
    JsonSerializer.Deserialize<List<ProductJson>>(content) 
    ?? 
    new List<ProductJson>();

var maxId = savedProducts.Count > 0 ? savedProducts.Max(p => p.Id) : 0;

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

Menu mainMenu = new Menu("Inventory Management", mainMenuOptions);

mainMenu.Show();

void AddProduct()
{
    Product? product = UserInputHandler.GetProductInput(maxId);
    string json = string.Empty;

    if (product is not null)
    {
        productManager.Add(product);
        maxId++;
        Console.WriteLine("max id is now " + maxId);
        List<ProductJson> newProduct = productManager.Products.Select(p => new ProductJson
        {
            Id = p.Id,
            Name = p.Name,
            Category = p.CategoryManual,
            Price = p.Price
        }).ToList();

        List<ProductJson> productsToSave = savedProducts.Concat(newProduct).ToList<ProductJson>();

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        json = JsonSerializer.Serialize(productsToSave, options);

        _fileHandler.WriteAllText(json);

        UI.ShowMessage("Product added successfully!", "success");
    } else
    {
        UI.ShowMessage("Product addition cancelled. No product was added.", "info");
        return;
    }
    AddProduct();
}

Console.WriteLine();
