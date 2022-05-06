using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Purchasing
{
    public class PurchasingStrategy
    {
        private IPurchasingStrategy _purchasingStrategy;

        public void SetStrategy(IPurchasingStrategy purchasingStrategy)
        {
            _purchasingStrategy = purchasingStrategy;
        }

        public IList<Product> Calcul(Basket basket)
        {
            return _purchasingStrategy.Calcul(basket);
        }

        public static PurchasingStrategy Instance()
        {
            return new PurchasingStrategy();
        }
    }
}