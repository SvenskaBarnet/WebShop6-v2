using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop6_v2;

public class CustomerManagement
{
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");
        Console.WriteLine("Customer Account Management");
        Console.WriteLine(" 1. Remove Customer\n");
        Console.WriteLine(" 2. Edit username\n");
        Console.WriteLine(" 3. Edit Password\n");
        Console.WriteLine(" 0. Exit\n");
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
           Menu();
        }
        List<string> userList = new List<string>();
        string[] users = File.ReadAllLines("users.csv");
        foreach (string user in users)
        {
            string[] info = user.Split(',');
            if (info[0].Equals(input))
            {
                Console.WriteLine("\nUsername does not exist, try again");
                Thread.Sleep(1000);
                RemoveCustomer();
            }
            else
            {
                userList.Add(user);
            }
        }
        File.WriteAllLines("users.csv", userList);
        Menu();
        return;
    }
    private static void CustomerList()
    {
        Console.Clear();
        Console.WriteLine("Registred Customers\n\n");
        string[] users = File.ReadAllLines("users.csv");
        foreach (string user in users)
        {
            string[] info = user.Split(',');
            if (info[2] is "Customer")
            {
                Console.WriteLine(info[0]);
            }
        }
        Console.WriteLine();
    }
}