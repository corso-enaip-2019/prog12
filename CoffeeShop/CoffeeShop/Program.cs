using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    class Program
    {


        static void Main(string[] args)
        {
            Dictionary<int, Ingredient> menu;
            List<Ingredient> dispensa = new List<Ingredient>();
            InitDispensa(dispensa);

            menu = GetMenu(dispensa);

            Order order = GetOrder(menu);

            foreach (Ingredient ingredient in order.GetList())
            {
                Console.WriteLine($"{ingredient.Description}");
            }

            Console.WriteLine($"\n\rCosto: {order.Price}");

            Console.ReadKey();
        }

        static void InitDispensa(List<Ingredient> dispensa)
        {
            dispensa.Add(new Coffe("Espresso", 1.10m, CoffeSize.Small));
            dispensa.Add(new Coffe("Americano", 1.50m, CoffeSize.Big));
            dispensa.Add(new Ingredient("Latte", 0.10m));
            dispensa.Add(new Ingredient("Cioccolato", 0.20m));
            dispensa.Add(new Ingredient("Sambuca", 0.30m));
            dispensa.Add(new Ingredient("Grappa", 0.30m));
            dispensa.Add(new Ingredient("Rum", 0.40m));
        }

        static Dictionary<int, Ingredient> GetMenu(List<Ingredient> dispensa)
        {
            int index = 1;

            Dictionary<int, Ingredient> menu = new Dictionary<int, Ingredient>();

            foreach (Ingredient ingredient in dispensa)
            {
                menu.Add(index++, ingredient);
            }

            return menu;
        }

        static Order GetOrder(Dictionary<int, Ingredient> menu)
        {
            int choice;
            Order order = new Order();
            int maxIndex = menu.Keys.Max();

            DisplayMenu(menu);

            do
            {
                choice = GetInput(maxIndex);
                
                if (choice != 0)
                {
                    order.AddIngredient(menu[choice]);
                }
            }
            while (choice != 0);

            return order;
        }

        static void DisplayMenu(Dictionary<int, Ingredient> menu)
        {
            Console.WriteLine("Please compose the ingredients for your beverage!");

            foreach (int index in menu.Keys)
            {
                Console.WriteLine($"{index}. {menu[index].Description}");
            }

            Console.WriteLine($"0. Finish order");
        }

        static int GetInput(int maxEntryIndex)
        {
            int value;

            while (!int.TryParse(Console.ReadLine(), out value) && value <= maxEntryIndex) ;

            return value;
        }






    }
}
