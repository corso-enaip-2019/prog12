using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public enum CoffeSize { Small, Big }

    public class Coffe : Ingredient
    {
        public CoffeSize Size { get; set; }

        public Coffe(string description, decimal price, CoffeSize size) : base (description, price)
        {
            Size = size;
        }
    }
}
