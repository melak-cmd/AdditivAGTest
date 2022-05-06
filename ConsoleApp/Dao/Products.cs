using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp.Dao
{
    public class Products : DataAccessObject<Product>

    {
        private List<Product> _products;

        public override void Select()
        {
            _products = SerializationHelper.LoadData<List<Product>>("products.xml");
        }

        public bool Exist(int id)
        {
            return _products.Any(i => i.Id == id);
        }

        public override Product Get(int id)
        {
            var product = (from p in _products
                where p.Id == id
                select p).SingleOrDefault();
            return product;
        }

        public override void Process()
        {
            Console.WriteLine("Products ---- ");
            foreach (var product in _products)
                Console.WriteLine($"Id : {product.Id}, Name : {product.Name}, Price : {product.Price} CHF");

            Console.WriteLine();
        }
    }
}