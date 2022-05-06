using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Printing
{
    internal interface IPrintingStrategy
    {
        void Print(IEnumerable<Product> products);
    }
}