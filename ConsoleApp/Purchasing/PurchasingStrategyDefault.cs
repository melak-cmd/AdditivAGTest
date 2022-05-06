using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp.Purchasing
{
    public class PurchasingStrategyDefault : IPurchasingStrategy
    {
        public IList<Product> Calcul(Basket basket)
        {
            var budget = basket.Budget;
            var products = basket.Products;


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

            var result = new List<Product>();
            var newBudget = budget;
            foreach (var p in products.OrderByDescending(i => i.Value))
                if (p.Price <= newBudget)
                {
                    result.Add(p);
                    newBudget = newBudget - p.Price;
                }

            return result;
        }
    }
}