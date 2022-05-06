using System;
using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Printing
{
    public class PrintingStrategyProduct : IPrintingStrategy
    {
        public void Print(IEnumerable<Product> products)
        {
            Console.WriteLine("Purchasing ticket ---- ");
            foreach (var product in products)
                Console.WriteLine($"Product : {product.Name},  Value : {product.Value},  Price : {product.Price} CHF");
        }
    }
}