using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Basket
    {
        public IList<Product> Products { get; set; }
        public int Budget { get; set; }
    }
}