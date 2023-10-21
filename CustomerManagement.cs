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
                case 0:
                    return;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Menu();
                    break;

            }
        }
        else
        {
            Console.WriteLine("Invalid input");
            Thread.Sleep(1000);
            Menu();
        }
    }
}