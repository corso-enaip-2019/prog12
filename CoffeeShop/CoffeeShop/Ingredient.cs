using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class Ingredient
    {
        public string  Description { get; set; }
        public decimal Price       { get; set; }

        public Ingredient(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
}
