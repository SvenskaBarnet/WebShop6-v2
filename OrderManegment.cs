using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop6_v2
{
    public static class OrderManegment
    {
        public static void Menu(string username)
        {
            Console.Clear();
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine(username + "! WELCOME to: The Admin Order Management\n");
            Console.WriteLine(" 1. Manage Custumers Orders");
            Console.WriteLine(" 2. Manage Custumers Transactions");
            Console.WriteLine(" 3. See current $$$");
            Console.WriteLine(" 0. Log out");
            Console.WriteLine($"\n******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            string tempchoice;
            bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
            if (isSucceed)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"******************************************************************");
                        Console.WriteLine($"****************************************************************** \n");
                        Console.WriteLine("---                      Custermers                           ----");
                        Console.WriteLine("         For what user do you want to see ongoing order");
                        displayUsers();
                        Console.WriteLine();
                        Console.Write("enter user: ");
                        tempchoice = Console.ReadLine();
                        Console.WriteLine("");
                        getUserCart(tempchoice);
                        break;
                    case 2:
                        Console.WriteLine($"******************************************************************");
                        Console.WriteLine($"****************************************************************** \n");
                        Console.WriteLine("---                      Custermers                           ----");
                        Console.WriteLine("         For what user do you want to see order history");
                        displayUsers();
                        Console.WriteLine("Chose a custemer for see transaction history");
                        Console.Write("enter user: ");
                        tempchoice = Console.ReadLine();
                        Console.WriteLine("");
                        getReceipt(tempchoice);

                        break;
                    case 3:
                        Console.WriteLine("--- Custermers ----");
                        displayUsers();
                        Console.WriteLine("$$$$");
                        Console.WriteLine("");
                        Console.ReadLine();
                        break;
                }

            }

        }
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
            Console.WriteLine("");
            Console.WriteLine($" - number of items: {count}\n");
            Console.WriteLine($" - total price:     {totalsum}$");
            Console.ReadLine();
        }
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
            int tempchoice = Convert.ToInt32(Console.ReadLine());
            string[] Receipt = File.ReadAllLines(fileEntries[tempchoice - 1]);
            foreach (var item in Receipt)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
