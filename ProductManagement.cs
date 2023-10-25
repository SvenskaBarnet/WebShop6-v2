using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebShop6_v2
{
    internal class ProductManagement
    {
        public static void addProduct()
        {
            string newItemName, newItemPrice, newItemDesc;

            Console.Clear();

            Console.WriteLine("Add a new product");
            Console.WriteLine("Write the name of the new product and press enter:");
            newItemName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Write the price of the new product and press enter:");
            newItemPrice = Console.ReadLine();

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
            string editItem, newName, newPrice, newDesc;
            int num = 0;
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
            newPrice = Console.ReadLine();
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
