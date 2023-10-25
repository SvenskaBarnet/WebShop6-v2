using WebShop6_v2;

Files.Setup();
while (true)
{
    Console.Clear();
    Console.WriteLine($"******************************************************************");
    Console.WriteLine($"****************************************************************** \n");
    Console.WriteLine(" WELCOME to: The Time-travelling Feline Shop\n");
    Console.WriteLine(" 1. Login ");
    Console.WriteLine(" 2. Register\n");
    Console.WriteLine(" 0. Exit\n");
    Console.WriteLine($"******************************************************************");
    Console.WriteLine($"****************************************************************** \n");

    bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
    IUser? user = null;
    if (isSucceed)
    {
        switch (choice)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("*******************************************************************\n");
                Console.WriteLine(" Welcome back!\n");
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("*******************************************************************\n");
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("Program has exited.");
                Environment.Exit(1);
                break;

            case 1: //login 
                user = LoginMenu.Login();
                if (user is Customer customer)
                {
                    CustomerMenu.Main(customer);
                }
                else if (user is Admin admin)
                {
                    AdminMenu.Main(admin);
                }
                continue;

            case 2: //registrera kund
                LoginMenu.Register();
                continue;

            default: //ogiltig siffra matas in
                Console.WriteLine(" Invalid choice. Try again!");
                Thread.Sleep(1000);
                continue;
        }
    }
    else //ogiltig symbol matas in
    {
        Console.WriteLine("Invalid input. Try again!");
        Thread.Sleep(1000);
        continue;
    }
}
