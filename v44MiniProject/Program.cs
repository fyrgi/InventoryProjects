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

int maxId = savedProducts.Count > 0 ? savedProducts.Max(p => p.Id) : 0;

ProductManager productManager = new ProductManager();
ExtractTheFileIntoList();

// Create the menu for the program and add the options.
List<MenuOption> mainMenuOptions = new()
{
    new MenuOption("Add Product", AddProduct),
    new MenuOption("View Products", productManager.View),
    new MenuOption("Search Products", productManager.Search),
    new MenuOption("Edit Product", EditProduct),
    new MenuOption("Remove Product", productManager.Remove),
    new MenuOption("Statistics", productManager.Statistics),
};

Menu mainMenu = new Menu("Inventory Management", mainMenuOptions);

mainMenu.Show();

// Recursive function to add products until the user stops. The products are being objects of a local class,
// then added to the list and at the end to a JSON file.
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
            CategoryManual = p.CategoryManual,
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

void EditProduct()
{
    Console.WriteLine("Editing product");
    // show a list of products (unsorted) and ask the user to select by Id. In UserInputHandler a method
    // is created to ask which attribute to edit until cance.
    productManager.View();

    Console.Write("Enter the ID of the product to edit: ");
    int id = int.Parse(Console.ReadLine() ?? "0");
    Product? productToEdit = productManager.Products.FirstOrDefault(p => p.Id == id);
    if (productToEdit != null)
    {
        UserInputHandler.EditProduct(productToEdit);
        // Save the updated products to the file
        List<ProductJson> updatedProducts = productManager.Products.Select(p => new ProductJson
        {
            Id = p.Id,
            Name = p.Name,
            CategoryManual = p.CategoryManual,
            Price = p.Price
        }).ToList();
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(updatedProducts, options);
        _fileHandler.WriteAllText(json);
        UI.ShowMessage("Product updated successfully!", "success");
    }
    else
    {
        UI.ShowMessage($"No product found with ID {id}.", "error");
    }

    }


// On program start, get all the products from the file and add them to the ProductManager _products list.
// To ensure that we always have all the records to work with on view or statistics.
void ExtractTheFileIntoList()
{
    if (savedProducts.Count > 0)
    {
        foreach (var product in savedProducts)
        {
            Product newProduct = new Product(product.Id, product.Name, product.CategoryManual, product.Price);
            productManager.Add(newProduct);
        }
    }
}

Console.WriteLine();
