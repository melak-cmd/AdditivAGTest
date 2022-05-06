using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;
using ConsoleApp.Purchasing;
using FizzWare.NBuilder;
using NUnit.Framework;

namespace ConsoleApp.Test
{
    [TestFixture]
    internal class PurchasingTest
    {
        [TestCase(0900, 0, 1000, 1000, 1000, 1, 1, 1)]
        [TestCase(1200, 1, 1000, 1000, 1000, 1, 1, 1)]
        [TestCase(1500, 2, 0500, 1000, 1000, 1, 1, 1)]
        [TestCase(2500, 3, 0500, 1000, 1000, 1, 1, 1)]
        public void GetSelectionTest(int b, int r, int p1, int p2, int p3, int v1, int v2, int v3)
        {
            var products = Builder<Product>.CreateListOfSize(3).Build();

            products[0].Price = p1;
            products[1].Price = p2;
            products[2].Price = p3;

            products[0].Value = v1;
            products[1].Value = v2;
            products[2].Value = v3;

            var context = PurchasingStrategy.Instance();
            context.SetStrategy(new PurchasingStrategyDefault());
            var result = context.Calcul(new Basket() { Budget = b, Products = products });

            Assert.AreEqual(r, result.Count, "count number of product");
        }

        [TestCase(1200, 2, 0, 0, 1000, 1000, 1000, 1, 2, 1)]
        [TestCase(1200, 3, 0, 0, 1000, 1000, 1000, 1, 2, 3)]
        [TestCase(1200, 1, 0, 3, 1000, 2000, 0200, 1, 2, 4)]
        [TestCase(1200, 1, 2, 1, 1000, 0200, 2000, 1, 2, 4)]
        [TestCase(0500, 1, 0, 3, 0200, 0200, 0200, 4, 2, 3)]
        public void GetSelectionTest_Value(int b, int r1, int r2, int r3, int p1, int p2, int p3, int v1, int v2, int v3)
        {
            var products = Builder<Product>.CreateListOfSize(3).Build();
            var r = new List<int> { r1, r2, r3 };

            products[0].Price = p1;
            products[1].Price = p2;
            products[2].Price = p3;

            products[0].Value = v1;
            products[1].Value = v2;
            products[2].Value = v3;

            var context = PurchasingStrategy.Instance();
            context.SetStrategy(new PurchasingStrategyDefault());
            var result = context.Calcul(new Basket() { Budget = b, Products = products });

            Assert.AreEqual(result.Count, r.Intersect(result.Select(product => product.Id)).Count());
        }
    }
}
