using System.Runtime.Remoting;
using System;
using WebShop6_v2;
namespace WebShop6_v2;

public static class Cart
{
    public static void GetOrder()
    {
        string[] savedCart = File.ReadAllLines($"Carts/{LoginMenu.CurrentCustomer}.csv");

    }

    public static void ShowOrder()
    {
        //Displayar innehållet av varukorgen
        int nr = 1;
        foreach (var item in Inventory.products)
        {
            Console.WriteLine($"{nr++}. {item.ProductName}, {item.ProductPrice};-");
        }

    }

    public static void ConfirmOrder()
    {

    }

    public static void EditCart()
    {

    }

    public static int TotalPrice()
    {
        var totalprice = Inventory.products.Select(product => product.ProductPrice).Sum();
        return totalprice;
    }

    public static void CartMenu() //visa totala beställning
    {
        Console.Clear();
        //GetOrder();
        Console.WriteLine("1. Beställa");
        Console.WriteLine("2. Ta bort vara");
        Console.WriteLine("Återvända [ENTER]");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                ConfirmOrder();
                break;

            case "2":
                EditCart();
                break;

            default://tillbaka menyval för kunden
                CustomerMenu.Main(LoginMenu.CurrentCustomer);
                break;

        }
        //loopa>hämta produktinfo
        Console.WriteLine($" Total =  {TotalPrice()} "); //anropa en beräkningsfunktion av totalsumman
    }
}
