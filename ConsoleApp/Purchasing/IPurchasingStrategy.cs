using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Purchasing
{
    public interface IPurchasingStrategy
    {
        IList<Product> Calcul(Basket basket);
    }
}