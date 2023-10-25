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

            Console.WriteLine("Write the description of the new product and press enter:");
            newItemDesc = Console.ReadLine();

            string[] products = File.ReadAllLines("inventory.csv");

            string[] newItem = { newItemName + "," + newItemPrice + "," + newItemDesc };
            File.AppendAllLines("inventory.csv", newItem);

            Console.Clear();
        }

        public static void removeProduct()
        {
            string[] productsList = File.ReadAllLines("inventory.csv");
            Console.Clear();
            
            foreach (string product in productsList)
            {
                string[] products = product.Split(',');
                Console.WriteLine(products[0] + " " + products[1]);
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
            string editItem;
            string[] productsListEdit = File.ReadAllLines("inventory.csv");

            Console.Clear();

            foreach (string product in productsListEdit)
            {
                string[] products = product.Split(',');
                Console.WriteLine(products[0] + " " + products[1]);
            }

            Console.WriteLine("Choose a product to edit");
            bool editChoice = int.TryParse(Console.ReadLine(), out int Edit);
            Edit = Edit - 1;

            List<string> editList = File.ReadAllLines("inventory.csv").ToList();
            string itemEdit = editList[Edit];

            Console.WriteLine("The items new name and price:   ('Name,Price,Description')");
            editItem = Console.ReadLine();

            editList[Edit] = editItem;
            File.WriteAllLines("inventory.csv", editList.ToArray());
        }
    }
}
