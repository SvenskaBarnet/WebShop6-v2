﻿namespace WebShop6_v2;

public class AdminMenu
{
    public static void Menu(string username)
    {
        Console.Clear();
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");
        Console.WriteLine(username + "! WELCOME to: The Admin menu\n");
        Console.WriteLine(" 1. Manage Customer Info ");
        Console.WriteLine(" 2. Manage Products\n");
        Console.WriteLine(" 3. Manage Orders\n");
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

                case 1: //Manage Customer Info
                    Menu(username);
                    break;


                case 3: //Manage Orders
                    Menu(username);
                    break;

                default: //ogiltig siffra matas in
                    Console.WriteLine(" Invalid choice. Try again!");
                    Thread.Sleep(1000);
                    Menu(username);
                    break;
            }
        }
        else //ogiltig symbol matas in
        {
            Console.WriteLine("Invalid input. Try again!");
            Thread.Sleep(1000);
            Menu(username);
        }

    }
}