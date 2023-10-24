using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop6_v2;

public class CustomerManagement
{
    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");
        Console.WriteLine("Customer Account Management\n");
        Console.WriteLine(" 1. Remove Customer");
        Console.WriteLine(" 2. Edit username");
        Console.WriteLine(" 3. Edit Password");
        Console.WriteLine(" 0. Exit");
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");

        bool validInput = int.TryParse(Console.ReadLine(), out int choice);
        if (validInput)
        {
            switch (choice)
            {
                case 0:     //Exit
                    return;
                case 1:     //Remove Customer
                    RemoveCustomer();
                    break;
                case 2:     //Edit Username
                    break;
                case 3:     //Edit Password
                    break;
                default:    //Invalid input
                    Console.WriteLine("Invalid input");
                    Menu();
                    break;

            }
        }
        else    //Invalid input
        {
            Console.WriteLine("Invalid input");
            Thread.Sleep(1000);
            Menu();
        }
    }

    private static void RemoveCustomer()
    {
        CustomerList();
        Console.WriteLine("\n\nWrite the username of the customer you want to remove or leave blank to return to previous menu.");
        string input = Utils.Promt("\nUsername: ");
        if (input.Equals(string.Empty))
        {
            return;
        }
        List<string> userList = new List<string>();
        string[] users = File.ReadAllLines("users.csv");
        foreach (string user in users)
        {
            string[] info = user.Split(',');
            if (info[0].Equals(input))
            {
                bool valid;
                do
                {
                    valid = true;
                    Console.WriteLine($"\nAre you sure you want to remove {info[0]}? (y/n)");
                    string choice = Console.ReadLine() ?? string.Empty;

                    if (choice.Equals("n"))
                    {
                        RemoveCustomer();
                        return;
                    }
                    else if (choice.Equals("y"))
                    {
                        Console.WriteLine($"\n{info[0]} has been removed");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again");
                        valid = false;
                    }
                } while (!valid);
            }
            else
            {
                userList.Add(user);
            }
        }
        File.WriteAllLines("users.csv", userList);
        RemoveCustomer();
        return;
    }

    private static void CustomerList()
    {
        Console.Clear();
        Console.WriteLine("Registered Customers\n\n");
        string[] users = File.ReadAllLines("users.csv");
        foreach (string user in users)
        {
            string[] info = user.Split(',');
            if (Enum.TryParse(info[2], out Role role))
            {
                if (role.Equals(Role.Customer))
                {
                    Console.Write("Customer: ");
                    Console.WriteLine(info[0]);
                }
            }
            else
            {
                Console.WriteLine("Failed to parse something");
                Thread.Sleep(1000);
                return;
            }
        }
        Console.WriteLine();
    }
}