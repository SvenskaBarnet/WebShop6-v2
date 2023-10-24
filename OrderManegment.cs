using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop6_v2
{
    public static class OrderManegment
    {
        public static void Menu()
        {
            Console.WriteLine("For what user do you want to see order history");
            Console.WriteLine("----------------------------------------------");
            string[] users = File.ReadAllLines("users.csv");
            string[] userline, username;
            foreach (var user in users)
            {
                string[] info = user.Split(",");
                Console.WriteLine(info[0]);
            }
            string choise = Console.ReadLine();
            editUserCart(choise);




        }


       
        public static void editUserCart(string choise)
        {
            Console.WriteLine("");
            Console.WriteLine("------" + choise + "------");
            Console.WriteLine("------ Cart -------");
            string[] cart = File.ReadAllLines($"Carts/{choise}.csv");
            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }





            Console.ReadLine();



        }

    }

}
