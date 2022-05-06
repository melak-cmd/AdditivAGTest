using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Dao;
using ConsoleApp.Models;

namespace ConsoleApp.ShopChain
{
    public class BasketHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            var budget = (int) request;
            var products = new List<Product>();
            var daoProduct = new Products();
            var answer = ConsoleKey.Enter;
            while (answer!=ConsoleKey.C)
            {
                Console.Clear();

                daoProduct.Run();

                Console.WriteLine("Budget ---- ");
                Console.WriteLine($"{budget} CHF\n");

                if (products.Any())
                {
                    Console.WriteLine("Basket ---- ");
                    foreach (var product in products)
                        Console.WriteLine(
                            $"Product : {product.Name},  Value : {product.Value},  Price : {product.Price} CHF");

                    Console.WriteLine("\n");
                }

                Console.Write("Would you like to add a product?");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" put id of product please\t");
                Console.ResetColor();

                var str = Console.ReadLine();
                int.TryParse(str, out var id);
                Console.Write("enter your interest value of product ?\t");
                str = Console.ReadLine();
                int.TryParse(str, out var value);
                var newProduct = daoProduct.Get(id);
                newProduct.Value = value;
                if (products.All(i => i.Id != newProduct.Id)) products.Add(newProduct);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("press c to checkout or any key to continue");
                Console.ResetColor();
                answer=Console.ReadKey().Key;
            }

            Console.Clear();
            var basket = new Basket {Budget = budget, Products = products};
            return base.Handle(basket);
        }
    }
}