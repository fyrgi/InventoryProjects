using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Text.Json;

namespace InventoryProjects.Common
{
    public class ProductManager
    {
        private List<Product> _products = new();
        // Refference to the eventual list of objects. 
        public IReadOnlyList<Product> Products => _products;
        // If list with objects is provided the manager will use it. Otherwise it won't
        public ProductManager(List<Product>? products = null)
        {
            _products = products ?? new List<Product>();
        }
        // Add, view, update and delete products
        public void Add(Product product)
        {
            _products.Add(product);
        }
        
        public void View()
        {
            if (_products.Count == 0)
            {
                UI.ShowMessage("No products found.", "warning");
                return;
            }
            
            Console.WriteLine("\n==== Product List ====");
            
            foreach (Product product in _products)
            {
                Console.WriteLine(
                    $"{product.Id} | {product.Name} | " +
                    $"{product.Category} | {product.Price}");
            }
            
            Console.WriteLine("==== End of List ====\n");
        }
        
        // Search by ID, name or category
        public void Search()
        {
            Console.WriteLine("searching");
            Console.ReadLine();
        }
        //
        public void Edit()
        {
            Console.WriteLine("editing");
            Console.ReadLine();
        }

        public void Remove()
        {
            Console.WriteLine("deleting...");
            Console.ReadLine();
        }
        public void Sort()
        {
            Console.WriteLine("sorting...");
            Console.ReadLine();
        }
        // Sort by price

        public void Calculate()
        {
            Console.WriteLine("Calculating Total...");
            Console.ReadLine();
        }
        
        public void Statistics()
        {
            Console.WriteLine("statistics...");
            Console.ReadLine();
        }
    }
}
