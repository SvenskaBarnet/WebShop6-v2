namespace WebShop6_v2;

public class AdminMenu
{

    public static void Main(string username)
    {
        Console.Clear();
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");
        Console.WriteLine(username + "! WELCOME to: The Admin menu\n");
        Console.WriteLine(" 1. Manage Customer Info");
        Console.WriteLine(" 2. Manage Products");
        Console.WriteLine(" 3. Manage Orders");
        Console.WriteLine(" 0. Log out");
        Console.WriteLine($"\n******************************************************************");
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

                case 2: //Manage Products
                    Console.Clear();
                    Console.WriteLine($"******************************************************************");
                    Console.WriteLine($"****************************************************************** \n");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Remove Product");
                    Console.WriteLine("3. Edit Product");
                    Console.WriteLine("4. Back");
                    Console.WriteLine($"\n******************************************************************");
                    Console.WriteLine($"****************************************************************** \n");

                    bool addRemChoice = int.TryParse(Console.ReadLine(), out int addOrRemove);

                    if (addRemChoice)
                    {
                        switch (addOrRemove)
                        {

                            case 1: //add product
                                ProductManagement.addProduct();
                                break;

                            case 2: //remove product
                                ProductManagement.removeProduct();
                                break;

                            case 3: //Edit product WIP
                                ProductManagement.editProduct();
                                break;

                            case 4:
                                AdminMenu.Main(username);
                                break;
                        }
                    }

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