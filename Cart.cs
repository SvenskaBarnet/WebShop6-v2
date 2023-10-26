using System.Runtime.Remoting;
using System;
using WebShop6_v2;
namespace WebShop6_v2;

public static class Cart
{
    public static void ShowOrder()//Visa innehållet av varukorgen
    {
        var currentOrder = LoginMenu.LoadCart(LoginMenu.CurrentCustomer.Username);
        int nr = 1;
        foreach (var item in currentOrder) //loopa aktuella kund-ordern
        {
            Console.WriteLine($"{nr++}. {item.Name}, {item.Price};-");
        }

    }

    public static void ConfirmOrder()
    {
        //skapa en ny folder med deras username> order-folder> om användaren ej har redan en
        //annars lägg kvitton under anävdarens-folder
        //kvitto> = ny txt-fil

    }

    public static void EditCart()
    {
        ShowOrder();
        //låt användaren ange input> relevant nr till produkten
        bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
        //om nr-val finns, ta bort
        if (isSucceed)
        {
            switch (choice)
            {
                case (choice  )
                 //Lista.RemoveAt(val av produkt)
                break;

                default:
                    //ogiltigt nr-val, låt användaren försöka igen
                    EditCart();
                    break;
            }
        }
        else
        {
            //ogiltigt symbol, gå tillbaka till cartmenu
            CartMenu();
        }
    }

    public static int TotalPrice()
    {
        var totalprice = Inventory.products.Select(product => product.ProductPrice).Sum();
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
                CustomerMenu.Main(LoginMenu.CurrentCustomer);
                break;

        }
    }
}
