using ConsoleApp.ShopChain;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var s1 = new BudgetHandler();
            var s2 = s1.SetNext(new BasketHandler());
            var s3 = s2.SetNext(new PurchasingHandler());
            var s4 = s3.SetNext(new PrintingHandler());
            s4.SetNext(new EndHandler());
            s1.Handle(null);
        }
    }
}