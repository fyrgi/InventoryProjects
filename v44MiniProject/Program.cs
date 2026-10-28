using InventoryProjects.Common;

Console.WriteLine("Product list manager - checkpoint 2");

List<Product> productList = new List<Product>();

// Test the connection with the Product class in Common
var product = new Product("test", 12.12);
Console.WriteLine(product.Id + " is the product id");
var product2 = new Product("test 2", 22);
Console.WriteLine(product2.Id + " is the product id");