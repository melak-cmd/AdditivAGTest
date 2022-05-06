using System;

namespace ConsoleApp.ShopChain
{
    public class BudgetHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            var budget = 0;
            while (budget == 0)
            {
                Console.Clear();
                Console.Write("what is your budget : ");
                var str = Console.ReadLine();
                int.TryParse(str, out budget);
            }

            return base.Handle(budget);
        }
    }
}