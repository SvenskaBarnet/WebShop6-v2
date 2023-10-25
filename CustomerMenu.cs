using System;
using WebShop6_v2;
namespace WebShop6_v2;


public class CustomerMenu
{
    public static void Main(Customer customer)
    {

        Console.Clear();
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");
        Console.WriteLine(customer.Username + "! WELCOME to: The Customer menu\n");
        Console.WriteLine(" 1. Product List");
        Console.WriteLine(" 2. Order History\n");
        Console.WriteLine(" 3. Shopping Basket\n");
        Console.WriteLine(" 0. Log out\n");
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");

        bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
        if (isSucceed)
        {
            switch (choice)
            {
                case 0:
                    return;

                case 1: //Product List
                    break;

                case 2: //Order History
                    break;

                case 3: //Shopping Basket
                    Cart.CartMenu();
                    break;

                default: //ogiltig siffra matas in
                    Console.WriteLine(" Invalid choice. Try again!");
                    Thread.Sleep(1000);
                    Main(customer);
                    break;
            }
        }
        else //ogiltig symbol matas in
        {
            Console.WriteLine("Invalid input. Try again!");
            Thread.Sleep(1000);
            Main(customer);
        }
    }
}