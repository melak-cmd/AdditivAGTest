using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Printing
{
    internal class PrintingStrategy
    {
        private IPrintingStrategy _printingStrategy;

        public void SetStrategy(IPrintingStrategy printingStrategy)
        {
            _printingStrategy = printingStrategy;
        }

        public void Print(IEnumerable<Product> products)
        {
            _printingStrategy.Print(products);
        }

        public static PrintingStrategy Instance()
        {
            return new PrintingStrategy();
        }
    }
}