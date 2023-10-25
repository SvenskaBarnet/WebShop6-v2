using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebShop6_v2
{
    internal class ProductManagement
    {

        public static void Menu()
        {
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
                        Menu();
                        break;

                    case 2: //remove product
                        ProductManagement.removeProduct();
                        Menu();
                        break;

                    case 3: //Edit product WIP
                        ProductManagement.editProduct();
                        Menu();
                        break;

                    case 4:
                        return;
                }
            }
        }


        public static void addProduct()
        {
            string newItemName, newItemDesc;
            int newItemPrice;
            Console.Clear();

            Console.WriteLine("Add a new product");
            Console.WriteLine("Write the name of the new product and press enter:");
            newItemName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Write the price of the new product and press enter:");

            if (int.TryParse(Console.ReadLine(), out int newValue))
            {
                newItemPrice = newValue;
            }
            else
            {
                Console.WriteLine("Must be a number");
                Thread.Sleep(1000);
                return;
            }
            Console.Clear();

            Console.WriteLine("Write the description of the new product and press enter:");
            newItemDesc = Console.ReadLine();

            string[] products = File.ReadAllLines("inventory.csv");

            string[] newItem = { newItemName + "," + newItemPrice + "," + newItemDesc };
            File.AppendAllLines("inventory.csv", newItem);

            Console.Clear();
        }

        public static void removeProduct()
        {
            int num = 0;
            string[] productsList = File.ReadAllLines("inventory.csv");
            Console.Clear();

            foreach (string product in productsList)
            {
                num = num + 1;
                string[] products = product.Split(',');
                Console.WriteLine(num + " " + products[0] + " " + products[1]);
            }

            Console.WriteLine("Write the number corresponding with the item you want to remove");

            bool remChoice = int.TryParse(Console.ReadLine(), out int Remove);
            Remove = Remove - 1;

            List<string> list = File.ReadAllLines("inventory.csv").ToList();
            string itemRem = list[Remove];
            list.RemoveAt(Remove);
            File.WriteAllLines("inventory.csv", list.ToArray());
        }

        public static void editProduct()
        {
            string editItem, newName, newDesc;
            int num = 0;
            int newPrice;
            string[] productsListEdit = File.ReadAllLines("inventory.csv");

            Console.Clear();

            foreach (string product in productsListEdit)
            {
                num = num + 1;
                string[] products = product.Split(',');
                Console.WriteLine(num + " " + products[0] + " " + products[1]);
            }

            Console.WriteLine("Write the number corresponding with the item you want to edit");
            bool editChoice = int.TryParse(Console.ReadLine(), out int Edit);
            Edit = Edit - 1;

            List<string> editList = File.ReadAllLines("inventory.csv").ToList();
            string itemEdit = editList[Edit];

            Console.Clear();

            Console.WriteLine(itemEdit);
            Console.WriteLine("Write the new name of the product");
            newName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine(itemEdit);
            Console.WriteLine("Write the new price of the product");

            if (int.TryParse(Console.ReadLine(), out int newValue))
            {
                newPrice = newValue;
            }
            else
            {
                Console.WriteLine("Must be a number");
                Thread.Sleep(1000);
                return;
            }
            Console.Clear();

            Console.WriteLine(itemEdit);
            Console.WriteLine("Write the new description of the product");
            newDesc = Console.ReadLine();
            Console.Clear();

            editItem = newName + "," + newPrice + "," + newDesc;

            editList[Edit] = editItem;
            File.WriteAllLines("inventory.csv", editList.ToArray());
        }
    }
}
