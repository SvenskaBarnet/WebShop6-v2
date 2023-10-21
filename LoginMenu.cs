using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace WebShop6_v2;

public class LoginMenu
{
    public static IUser? Login()
    {
        Console.Clear();
        Console.WriteLine("Enter you username and password, leave blank to return to previous menu\n");
        string input = Utils.Promt("Username: ");
        if (!input.Equals(string.Empty))
        {
            string[] users = File.ReadAllLines("users.csv");
            foreach (string user in users)
            {
                string[] info = user.Split(',');
                if (info[0].Equals(input))
                {
                    input = MaskedPass("Password: ");
                    if (!input.Equals(string.Empty))
                    {
                        if (info[1].Equals(input))
                        {
                            if (Enum.TryParse(info[2], out Role role))
                            {
                                switch (role)
                                {
                                    case Role.Admin:
                                        return new Admin(info[0]);
                                    case Role.Customer:
                                        return new Customer(info[0], LoadCart(info[0]));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Couldn't parse something.");
                                throw new Exception();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Password, try again");
                            Thread.Sleep(1000);
                            Login();
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            Console.WriteLine("Username does not exist, try again");
            Thread.Sleep(1000);
            Login();
        }
        return null;
    }

    public static List<Product> LoadCart(string username)
    {
        List<Product> cart = new List<Product>();
        string[] savedCart = File.ReadAllLines($"Carts/{username}");
        foreach (string product in savedCart)
        {
            cart.Add(new Product(product));
        }
        return cart;
    }
}