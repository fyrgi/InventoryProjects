namespace InventoryProjects.Common;

public class Product
{
    private static int _currentId;
    public Product(string name, double price)
    {
        Id = ++_currentId;
        Name = name;
        Price = price;
    }

    public Product(int id, string name, string category, double price)
    {
        Id = id;
        Name = name;
        CategoryManual = category;
        Price = price;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public ProductCategory CategoryDb { get; set; }
    public string CategoryManual { get; set; }
    public int Quantity { get; set; }
    
}


public enum ProductCategory
{
    Stationery = 1,
    OfficeSupplies = 2,
    SchoolSupplies = 3,
    TechAccessories = 4,
    WritingTools = 5,
    Filing = 6,
    Packaging = 7,
    Miscellaneous = 8
}