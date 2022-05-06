using System;

namespace ConsoleApp.ShopChain
{
    internal class EndHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            Console.WriteLine("\n...");
            return null;
        }
    }
}