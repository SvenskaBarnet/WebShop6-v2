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

                //case 2: //Manage products
                //    break;

                case 2: //Manage Products
                    Console.Clear();
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Remove Product");
                    Console.WriteLine("3. Edit Product");
                    Console.WriteLine("4. Back");

                    bool addRemChoice = int.TryParse(Console.ReadLine(), out int addOrRemove);
                    string newItemName, newItemPrice, editItem;

                    if (addRemChoice)
                    {
                        switch (addOrRemove)
                        {

                            case 1: //add product
                                Console.Clear();

                                Console.WriteLine("Add a new product");
                                Console.WriteLine("Name of product:");
                                newItemName = Console.ReadLine();

                                Console.Clear();

                                Console.WriteLine("Price of product:");
                                newItemPrice = Console.ReadLine();

                                string[] products = File.ReadAllLines("inventory.csv");

                                string[] nameAndPrice = { newItemName + "," + newItemPrice };
                                File.AppendAllLines("inventory.csv", nameAndPrice);

                                Console.Clear();

                                break;

                            case 2: //remove product
                                string[] productsList = File.ReadAllLines("inventory.csv");

                                Console.Clear();

                                foreach (string product in productsList)
                                {
                                    Console.WriteLine(product);
                                }

                                Console.WriteLine("Choose a product to remove");

                                bool remChoice = int.TryParse(Console.ReadLine(), out int Remove);
                                Remove = Remove - 1;

                                List<string> list = File.ReadAllLines("inventory.csv").ToList();
                                string itemRem = list[Remove];
                                list.RemoveAt(Remove);
                                File.WriteAllLines("inventory.csv", list.ToArray());

                                break;

                            case 3: //Edit product WIP

                                string[] productsListEdit = File.ReadAllLines("inventory.csv");

                                Console.Clear();

                                foreach (string product in productsListEdit)
                                {
                                    Console.WriteLine(product);
                                }

                                Console.WriteLine("Choose a product to edit");
                                bool editChoice = int.TryParse(Console.ReadLine(), out int Edit);
                                Edit = Edit - 1;

                                List<string> editList = File.ReadAllLines("inventory.csv").ToList();
                                string itemEdit = editList[Edit];

                                Console.WriteLine("The items new name and price:");
                                editItem = Console.ReadLine();

                                editList[Edit] = editItem;
                                File.WriteAllLines("inventory.csv", editList.ToArray());

                                break;


                            case 4:

                                Main(username);
                                break;

                        }
                    }

                break;

                case 3: //Manage Orders
                    OrderManegment.Menu();
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