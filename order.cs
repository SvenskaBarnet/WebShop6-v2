using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class order
{
    static List<Product> products = new List<Product>();
    static List<Order> orders = new List<Order>();

    static void Main()
    {

        // läs in produkter fråm fil
      File.ReadAllText("inventory.csv"); 

        while (true)
        {
            Console.WriteLine("1. View Purchase History");
            Console.WriteLine("2. View Product List");
            Console.WriteLine("3. Place an Order");
            

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    ViewPurchaseHistory();
                    break;
                case 2:
                    DisplayProductList();
                    break;
                case 3:
                    PlaceOrder();
                    break;
                        default:
                    Console.WriteLine("Invalid, try again.");
                    break;
            }
        }
    }

    static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid, please choose correct.");
        }
        return choice;
    }

    static void LoadProductsFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            
            string[] lines = File.ReadAllLines("inventory.csv");
            for (int i = 0; i< lines.Length; i++)
            {
                string[] parts = lines[i].Split(",");
                if (int.TryParse(parts[1], out int price))
                {
                    products.Add(new Product(i, parts[0], price));

                }

            }  
        }
    }

    static void DisplayProductList()
    {
        Console.WriteLine("Product List");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}. {product.Name} - ${product.Price}");
        }
    }

    static void ViewPurchaseHistory()
    {
        Console.WriteLine("Purchase History");
        foreach (var order in orders)
        {
            Console.WriteLine($"Product: {order.Product.Name}");
            Console.WriteLine($"Quantity: {order.Quantity}");
            Console.WriteLine($"Total Amount: ${order.TotalAmount}");
            
        }
    }

    static void PlaceOrder()
    {


        DisplayProductList();
        Console.Write("Enter product ID ");
        int productId = GetChoice();

        Product selectedProduct = products.FirstOrDefault(p => p.Id == productId);

       if (selectedProduct == null)
        {
            Console.WriteLine("Invalid product ID.");
            return;
        }

        

        int totalAmount = selectedProduct.Price;
        Console.WriteLine($"Total Amount: ${totalAmount}");

        orders.Add(new Order(selectedProduct, totalAmount));
        Console.WriteLine("Order placed successfully!");
    }
}
// kom ihåg blir dubbelt
class Product
{
    public int Id { get; }
    public string Name { get; }
    public int Price { get; }

    public Product(int id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

class Order
{
    public Product Product { get; }
    public int Quantity { get; }
    public int TotalAmount { get; }

    public Order(Product product, int quantity, int totalAmount)
    {
        Product = product;
        Quantity = quantity;
        TotalAmount = totalAmount;
    }
}
