using System;
using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Printing
{
    public class PrintingStrategyEmpty : IPrintingStrategy
    {
        public void Print(IEnumerable<Product> products)
        {
            Console.WriteLine("Purchasing ticket ---- ");
            Console.WriteLine("Empty");
        }
    }
}