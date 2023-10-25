using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
// Class for manage all Cart and Receipt 


namespace WebShop6_v2
{
    public static class OrderManegment
    {
        public static void Menu(string username)
        {
            // Main menu
            Console.Clear();
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine(username + "! WELCOME to: The Admin Order Management\n");
            Console.WriteLine(" 1. Manage Customers Orders");
            Console.WriteLine(" 2. Manage Customers Transactions");
            // Console.WriteLine(" 3. See current $$$");
            Console.WriteLine(" 0. Go Back");
            Console.WriteLine($"\n******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            string tempchoice;
            bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
            if (isSucceed)
            {
                switch (choice) 
                {
                    case 1: // Menu for checking ongoning Cart for customers
                        Console.WriteLine($"******************************************************************");
                        Console.WriteLine($"****************************************************************** \n");
                        Console.WriteLine("---                      Customers                             ----");
                        Console.WriteLine("         For what user do you want to see ongoing order");
                        displayUsers(); 
                        Console.WriteLine();
                        Console.Write("enter user: ");
                        tempchoice = Console.ReadLine();
                        if (userExist(tempchoice) == true)
                        {
                            Console.WriteLine("");
                            getUserCart(tempchoice);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Wrong input... returning!");
                            Thread.Sleep(500);
                            Menu(username);
                        }
                        Menu(username);
                        break;
                    case 2: // Menu for checking receipt for customers (order history)
                        Console.WriteLine($"******************************************************************");
                        Console.WriteLine($"****************************************************************** \n");
                        Console.WriteLine("---                      Customers                             ----");
                        Console.WriteLine("         For what user do you want to see order history");
                        displayUsers();
                        Console.WriteLine("\nChose a customer for see transaction history");
                        Console.Write("enter user: ");
                        tempchoice = Console.ReadLine();
                        if (userExist(tempchoice) == true)
                        {
                            Console.WriteLine("");
                            getReceipt(tempchoice);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input... returning!");
                            Thread.Sleep(500);
                            Menu(username);
                        }
                        Menu(username);
                        break;
                    case 3: // did not complet this... unnecessary but could have been fun to display
                        Console.WriteLine("--- Customers ----");
                        displayUsers();
                        Console.WriteLine("$$$$");
                        Console.WriteLine("");
                        Console.ReadLine();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("wrong choice... returning");
                        Thread.Sleep(500);
                        Menu(username);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong input returning");
                Thread.Sleep(500);
                Menu(username);
            }

        }
        // Like the name... getting users from users i Cart
        public static void displayUsers()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");

            string[] users = File.ReadAllLines("users.csv");
            string[] userline, username;
            foreach (var user in users)
            {
                string[] info = user.Split(",");
                Console.WriteLine($"--->   {info[0]}");
            }
        }
        // Like the name getting users cart (ongoing purches) Think that this will be empty when checkout
        public static void getUserCart(string choice)
        {
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine("--->   " + choice + "´s ongoing purchase");
            Console.WriteLine("-------------------------------------------------------------------\n");
            Console.WriteLine("\n {0, -32} {1, 15}", "Product", "Price");
            Console.WriteLine("-------------------------------------------------------------------\n");
            string[] cart = File.ReadAllLines($"Carts/{choice}.csv");
            int count = 1;
            string product;
            int totalsum = 0;
            int price;
            foreach (var item in cart)
            {
                string[] productline = item.Split(",");
                product = productline[0];
                if (int.TryParse(productline[1], out int value))
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("faild to parse");
                    Thread.Sleep(1500);
                    return;
                }
                Console.WriteLine("\n {0, -32} {1, 15}", product, price);
                totalsum = totalsum + price;
                count++;
            }
            //Just cosmetic
            Console.WriteLine("");
            Console.WriteLine($" - number of items: {count}\n");
            Console.WriteLine($" - total price:     {totalsum}$");
        }

        // Like the name. Getting the all the receipt from users. Made it so it is collecting all receipt from users folder 
        public static void getReceipt(string choice)
        {
            Console.Clear();
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine("--->   " + choice + "´s order history");
            Console.WriteLine("-------------------------------------------------------------------\n");
            string[] fileEntries = Directory.GetFiles($"Orders/{choice}/");
            int i;
            for (i = 0; i < fileEntries.Length; i++)
            {

                Console.WriteLine($"[ {i + 1} ] {fileEntries[i]}");
            }
            Console.Write($"\nWhat receipt do you want to checkout? (1 - {i}): ");
            if(int.TryParse(Console.ReadLine(), out int tempchoice) && tempchoice <= i )
            {
                string[] Receipt = File.ReadAllLines(fileEntries[tempchoice - 1]);
                foreach (var item in Receipt)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Wrong input... returning!");
                Thread.Sleep(500);
                return;
            }
        }
        // A failsafe to check so input is a user that exist. Gets input from Console.ReadLine 
        // in the menu and checks if the user is in the users.csv file. The user is added there
        // when created. Used this for the recipt function also.
        public static bool userExist(string input)
        {
            string[] userlist = File.ReadAllLines("users.csv");
            foreach (var item in userlist)
            {
                string[] user = item.Split(",");
                if (input == user[0])
                return true;
            }
            return false;
        }
    }
}

    

