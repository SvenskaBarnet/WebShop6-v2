using System.Runtime.Remoting;
using System;
using WebShop6_v2;
using System.Linq;
using System.Xml;

namespace WebShop6_v2;

public class Cart
{
    public static string currentCustomer = LoginMenu.LoggedInCustomer.Username;

    public static List<Product> order = new List<Product>();
    public static void ShowOrder()//Visa innehållet av varukorgen
    {
        var currentOrder = LoginMenu.LoadCart(currentCustomer);
        int nr = 1;
        foreach (var item in currentOrder) //loopa aktuella kund-ordern
        {
            Console.WriteLine($"{nr++}. {item.Name}, {item.Price};-");
            order.Add(item);
        }

    }
    public static void ConfirmOrder()
    {
        List<string> currentOrder = ConvertOrderToStr();

        bool notFirstTimeOrder = Directory.Exists($"Orders/{currentCustomer}");

        //skapa en ny folder med deras username> order-folder> om användaren ej har redan en
        if (!notFirstTimeOrder)
        {
            Directory.CreateDirectory($"Orders/{currentCustomer}");
            File.AppendAllLines($"Orders/{currentCustomer}/{DateTime.Now.Ticks}.txt", currentOrder);
        }
        //annars lägg kvitton under anävdarens-folder
        //kvitto> = ny txt-fil
        else
        {
            File.AppendAllLines($"Orders/{currentCustomer}/{DateTime.Now.Ticks}.txt", currentOrder);
        }
        Console.WriteLine("Thank you for the purchased!");
        Console.WriteLine("For order status, please check - Order History -");
    }

    public static List<string> ConvertOrderToStr()
    {
        List<string> myList = new List<string>();
        foreach (var item in order)
        {
            myList.Add($"{item.Name}, {item.Price}, ");
        }
        return myList;
    }
    public static void EditCart()
    {
        //låt användaren ange input> relevant nr till produkten
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            //checka om den finns med index
            //if (order.ElementAtOrDefault()
            //{
              
            //}

            //om nr-val finns, ta bort
            //var newList = list.slice(begin,end);
            //list.RemoveAt(val av produkt)

            //ogiltigt nr-val, låt användaren försöka igen
            //felmeddelande + EditCart();
        }
        else
        {
            //ogiltigt symbol, gå tillbaka till cartmenu
            CartMenu();
        }
    }
    public static int TotalPrice()
    {
        var totalprice = order.Select(product => product.Price).Sum();
        return totalprice;
    }
    public static void CartMenu()//Visa totala beställning
    {
        Console.Clear();
        ShowOrder();
        Console.WriteLine($" Total =  {TotalPrice()} "); //anropa en beräkningsfunktion av totalsumman
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
                CustomerMenu.Main(LoginMenu.LoggedInCustomer);
                break;

        }
    }
}
