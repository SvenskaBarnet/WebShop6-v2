﻿using System;
using WebShop6_v2;
namespace WebShop6_v2;

public class LoginMenu
{
    //public static string loggedInUser { get; set; }
    public static Customer LoggedInCustomer { get; set; }
    public static void Register()
    {
        string? username;
        bool validName;
        do
        {
            validName = true;
            string[] users = File.ReadAllLines("users.csv");
            Console.Clear();
            Console.WriteLine("Username must be 4-12 characters long.\n\nLeave blank to return to previous menu.\n");
            username = Utils.Promt("Username: ");
            if (username.Equals(string.Empty))
            {
                return;
            }
            else if (username.Length is < 4 or > 12)
            {
                Console.WriteLine("Invalid Username length");
                Thread.Sleep(1000);
                validName = false;
            }
            else
            {
                foreach (string user in users)
                {
                    string[] info = user.Split(',');
                    if (info[0].Equals(username))
                    {
                        Console.Clear();
                        Console.WriteLine("Username already exists, try again");
                        Thread.Sleep(1000);
                        validName = false;
                    }
                }
            }
        } while (!validName);
        bool validPassword;
        do
        {
            validPassword = true;
            Console.Clear();
            Console.WriteLine("Password must be at least 8 characters long.\n\nLeave blank to return to previous menu.\n");
            string password = MaskedPass();
            if (password.Equals(string.Empty))
            {
                return;
            }
            else if (password.Length > 7)
            {
                Console.Clear();
                Console.WriteLine("Please re-enter password\n\nLeave blank to return to previous menu\n");
                string passwordCheck = MaskedPass();
                if (passwordCheck.Equals(string.Empty))
                {
                    return;
                }
                else if (passwordCheck.Equals(password))
                {
                    File.AppendAllText("users.csv", $"{username},{password},Customer{Environment.NewLine}");
                    File.Create($"Carts/{username}.csv").Close();
                    Directory.CreateDirectory($"Orders/{username}/");

                    //loggedInUsername = username;

                    return;
                }
            }
            Console.WriteLine("\nInvalid password, try again");
            Thread.Sleep(1000);
            validPassword = false;
        } while (!validPassword);
    }
    public static IUser? Login()
    {
        bool validInput;
        do
        {
            validInput = true;
            Console.Clear();
            Console.WriteLine("Enter you username and password, leave blank to return to previous menu\n");
            string input = Utils.Promt("Username: ");
            if (!input.Equals(string.Empty))
            {
                bool userExists = false;
                string[] users = File.ReadAllLines("users.csv");
                foreach (string user in users)
                {
                    string[] info = user.Split(',');
                    if (info[0].Equals(input))
                    {
                        userExists = true;
                        input = MaskedPass();
                        if (!input.Equals(string.Empty))
                        {
                            if (info[1].Equals(input))
                            {
                                if (Enum.TryParse(info[2], out Role role))
                                {
                                    //loggedInUser = info[0];

                                    switch (role)
                                    {
                                        case Role.Admin:
                                            return new Admin(info[0]);

                                        case Role.Customer:
                                            LoggedInCustomer = new Customer(info[0], LoadCart(info[0]));
                                            return LoggedInCustomer;

                                        default:
                                            Console.WriteLine("Invalid Role");
                                            Thread.Sleep(1000);
                                            throw new Exception();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n\nCouldn't parse something.");
                                    Thread.Sleep(1000);
                                    throw new Exception();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n\nWrong Password, try again");
                                Thread.Sleep(1000);
                                validInput = false;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                if (!userExists)
                {
                    Console.WriteLine("\nUsername does not exist, try again");
                    Thread.Sleep(1000);
                    validInput = false;
                }
            }
        } while (!validInput);
        return null;
    }

    public static List<Product> LoadCart(string username)
    {
        List<Product> cart = new List<Product>();
        string[] savedCart = File.ReadAllLines($"Carts/{username}.csv");
        foreach (string product in savedCart)
        {
            cart.Add(new Product(product));
        }
        return cart;
    }

    static string MaskedPass()
    {
        Console.Write("Password: ");
        string pass = string.Empty;
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        } while (key.Key != ConsoleKey.Enter);
        return pass;
    }
}