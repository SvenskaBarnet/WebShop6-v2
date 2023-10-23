namespace WebShop6_v2;

public class AdminMenu
{
    public static void Main(string username)
    {
        Console.Clear();
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");
        Console.WriteLine(username + "! WELCOME to: The Admin menu\n");
        Console.WriteLine(" 1. Manage Customer Info\n");
        Console.WriteLine(" 2. Manage Products");
        Console.WriteLine(" 3. Manage Orders");
        Console.WriteLine(" 0. Log out");
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
                    CustomerManagement.Menu();
                    Main(username);
                    break;

                case 2: //Manage products
                    break;

                case 3: //Manage Orders
                    Main(username);
                    break;

                default: //ogiltig siffra matas in
                    Console.WriteLine(" Invalid choice. Try again!");
                    Thread.Sleep(1000);
                    Main(username);
                    break;
            }
        }
        else //ogiltig symbol matas in
        {
            Console.WriteLine("Invalid input. Try again!");
            Thread.Sleep(1000);
            Main(username);
        }

    }
}