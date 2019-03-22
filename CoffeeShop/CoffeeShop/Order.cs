using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    class Order
    {
        List<Ingredient> _ingredients;

        public Order()
        {
            _ingredients = new List<Ingredient>();
        }

        public decimal Price {
            get
            {
                decimal total = 0;
                foreach (Ingredient ingredient in _ingredients)
                {
                    total += ingredient.Price;
                }

                return total;
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public List<Ingredient> GetList()
        {
            return _ingredients;
        }
    }
}
