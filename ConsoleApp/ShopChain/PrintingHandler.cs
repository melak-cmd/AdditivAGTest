using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;
using ConsoleApp.Printing;

namespace ConsoleApp.ShopChain
{
    public class PrintingHandler : AbstractHandler
    {
        private readonly PrintingStrategy _context;

        public PrintingHandler()
        {
            _context = PrintingStrategy.Instance();
        }

        public override object Handle(object request)
        {
            Guard.NotNull(() => request, request);
            return Handle((dynamic) request);
        }

        private object Handle(IList<Product> products)
        {
            if (products.Any())
                _context.SetStrategy(new PrintingStrategyProduct());
            else
                _context.SetStrategy(new PrintingStrategyEmpty());

            _context.Print(products);
            return base.Handle(products);
        }
    }
}