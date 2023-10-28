using System.Runtime.Remoting;
using System;
using WebShop6_v2;
using System.Linq;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace WebShop6_v2;

public class Cart
{
    public static string currentCustomer = LoginMenu.LoggedInCustomer.Username;

    public static List<Product> order = new List<Product>();

    public static List<string> ConvertOrderToStr()
    {
        List<string> myList = new List<string>();
        foreach (var item in order)
        {
            myList.Add($"{item.Name}, {item.Price}, ");
        }
        return myList;
    }
    public static void ConfirmOrder()
    {
        List<string> currentOrder = ConvertOrderToStr();
        bool notFirstTimeOrder = Directory.Exists($"Orders/{currentCustomer}");

        if (!notFirstTimeOrder)
        {
            Directory.CreateDirectory($"Orders/{currentCustomer}");
            File.AppendAllLines($"Orders/{currentCustomer}/{DateTime.Now.Ticks}.txt", currentOrder);
            Console.WriteLine("Thank you for the purchased!");
            Console.WriteLine("For order status, please check - Order History -");
        }
        else
        {
            File.AppendAllLines($"Orders/{currentCustomer}/{DateTime.Now.Ticks}.txt", currentOrder);
        }
        Console.WriteLine("Thank you for the purchased!");
        Console.WriteLine("For order status, please check - Order History -");
    }
    public static void EditCart()
    {
        //låt användaren ange input> relevant nr till produkten
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            var myProduct = order.ElementAtOrDefault(choice - 1);
            //checka om den finns med index
            if (myProduct != null)
            {
                order.RemoveAt(choice - 1);
                File.WriteAllLines($"Carts/{currentCustomer}.csv", ConvertOrderToStr());
            }
            else
            {
                Console.WriteLine(" Invalid choice. Try again!");
                Thread.Sleep(1000);
                EditCart();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Try again!");
            Thread.Sleep(1000);
            CartMenu();
        }
    }
    public static int TotalPrice()
    {
        var totalprice = order.Select(product => product.Price).Sum();
        return totalprice;
    }
    public static void ShowOrder()
    {
        order = new List<Product>(); //STARTAR alltid med en tom lista
        var currentOrder = LoginMenu.LoadCart(currentCustomer);
        int nr = 1;
        foreach (var item in currentOrder)
        {
            Console.WriteLine($"{nr++}. {item.Name}, {item.Price};-");
            order.Add(item);
        }
    }
    public static void CartMenu()
    {
        Console.Clear();
        ShowOrder();
        Console.WriteLine($" Total =  {TotalPrice()} "); //anropa en beräkningsfunktion av totalsumman
        Console.WriteLine("1. Beställa");
        Console.WriteLine("2. Ta bort vara");
        Console.WriteLine("0. Återvända");
        bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
        if (isSucceed)
        {
            switch (choice)
            {
                case 0:
                    CustomerMenu.Main(LoginMenu.LoggedInCustomer);
                    break;

                case 1:
                    ConfirmOrder();
                    break;

                case 2:
                    EditCart();
                    break;

                default: //ogiltig siffra matas in
                    Console.WriteLine(" Invalid choice. Try again!");
                    Thread.Sleep(1000);
                    CartMenu();
                    break;
            }
        }
        else //ogiltig symbol matas in
        {
            Console.WriteLine("Invalid input. Try again!");
            Thread.Sleep(1000);
            CartMenu();
        }

    }
}