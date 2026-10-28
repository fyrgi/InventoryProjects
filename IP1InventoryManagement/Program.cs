using InventoryProjects.Common;

Console.WriteLine("Little Stationery Shop's Inventory Management System Beta");

// ToDo:
// UML Activity Diagram
// Menu
// Class Product (id, name, price, quantity, category, category)
// Enum with categories (no option for delete or edit, but maybe user can add?)
// Plan where methods will be (change in quantity, price, add a discount).
// Validations
// Error handlig

//Console.WriteLine(args.All);
var product = new Product("test", 12.12);
Console.WriteLine(product.Id + " is the product id");
var product2 = new Product("test 2", 22);
Console.WriteLine(product2.Id + " is the product id");
