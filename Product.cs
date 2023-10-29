using System.ComponentModel.DataAnnotations;

namespace WebShop6_v2;

public class Product
{
    public readonly string Name;
    public readonly int Price;
    public Product(string data)
    {
        string[] info = data.Split(',');
        Name = info[0];
        if (int.TryParse(info[1], out int value))
        {
            Price = value;
        }
        else
        {
            throw new Exception();
        }
    }

    public Product(string Name, int Price)
    {
        this.Name = Name;
        this.Price = Price;
    }
}