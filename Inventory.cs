using System.ComponentModel.DataAnnotations;

namespace WebShop6_v2;

public class Inventory
{
    public static List<Inventory> products = new List<Inventory>();
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public string ProductInfo { get; set; }

    public static void Printer()
    {
        string filePath = "inventory.csv";
        StreamReader reader = new StreamReader(filePath);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');

            if (values.Length == 3)
            {
                Inventory obj = new Inventory
                {
                    ProductName = values[0],
                    ProductPrice = int.Parse(values[1]),
                    ProductInfo = values[2],
                };
                products.Add(obj);
            }
        }
    }

    public static List<Product> ConvertToProductList(List<Inventory> inventoryList)
    {
        var productList = new List<Product>();
        //omvandla Inventory products till lista av produkter
        foreach (var item in inventoryList)
        {
            var product = new Product(item.ProductName, item.ProductPrice);
            productList.Add(product);
        }
        return productList;
    }
    public static Product ConvertToProduct(Inventory inventory)
    {
        return new Product(inventory.ProductName, inventory.ProductPrice);
    }
}