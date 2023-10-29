﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop6_v2
{
    public static class Catalogue
    {
        //public static List<Product> currentCart = Cart.order();
        public static List <string> currentStrCart = Cart.ConvertOrderToStr();
        public static void AddProductToCart()
        {
            Console.Clear();
            Console.WriteLine("-- CURRENCY IN: CatCoins --\n\n");
            ProductNameAndPrice();
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                //var myProduct = currentCart.ElementAtOrDefault(choice--);

                //if (myProduct != null)
                //{
                //    Cart.order.Add(choice--);
                //    File.AppendAllLines($"Carts/{Cart.currentCustomer}.csv", currentStrCart);
                //    Console.WriteLine("---[ ITEM ADDED ]--");
                //    Thread.Sleep(1000);
                //}
            }
        }

        public static void ProductNameAndPrice()
        {
            int nr = 1;
            foreach (var item in Inventory.products)
            {
                Console.WriteLine($" {nr++}. {item.ProductName.ToUpper()}, {item.ProductPrice};-");
            }
        }
        public static void ShowAllProductDetail()
        {
            int nr = 1;
            foreach (var item in Inventory.products)
            {
                Console.WriteLine($" {nr++}. {item.ProductName.ToUpper()}, {item.ProductPrice};-");
                Console.WriteLine($" ({item.ProductInfo})\n\n");
            }
        }

        public static void CatalogueMenu()
        {
            Console.Clear();
            Console.WriteLine("-- CURRENCY IN: CatCoins --\n\n");
            ShowAllProductDetail();
            Console.WriteLine("1. Buy");
            Console.WriteLine("0. Go Back");
            bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
            if (isSucceed)
            {
                switch (choice)
                {
                    case 0:
                        CustomerMenu.Main(LoginMenu.LoggedInCustomer);
                        break;

                    case 1:
                        AddProductToCart();
                        break;

                    default: //ogiltig siffra matas in
                        Console.WriteLine(" Invalid choice. Try again!");
                        Thread.Sleep(1000);
                        CatalogueMenu();
                        break;
                }
            }
            else //ogiltig symbol matas in
            {
                Console.WriteLine("Invalid input. Try again!");
                Thread.Sleep(1000);
                CatalogueMenu();
            }

        }
    }
}