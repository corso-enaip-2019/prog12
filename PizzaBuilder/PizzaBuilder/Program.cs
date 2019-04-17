using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBuilderNS
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaBuilder = new PizzaBuilder(true)
                .AddHam()
                .AddMushrooms();
            
            Pizza pizza = pizzaBuilder.Create(true);


            Console.ReadKey();
        }
    }

    class Pizza
    {
        public Pizza(bool isMignon)
        {
            IsMignon = isMignon;
            Ingredients = new List<Ingredient>();
        }

        bool IsMignon { get; }
        public List<Ingredient> Ingredients { get; set; }
    }

    class PizzaBuilder : IPizzaBuilder
    {
        private static Dictionary<bool, PizzaConfiguration> _configurations =
            new Dictionary<bool, PizzaConfiguration>
            {
                {
                    false,
                    new PizzaConfiguration
                    {
                        Tomato = 50,
                        Mozzarella = 70,
                        Ham = 30,
                        Mushroom = 20,
                        RocketSalad = 20,
                    }
                },
                {
                    true,
                    new PizzaConfiguration
                    {
                        Tomato = 40,
                        Mozzarella = 60,
                        Ham = 20,
                        Mushroom = 10,
                        RocketSalad = 10,
                    }
                }
            };

        List<Ingredient> _ingredients;
        PizzaConfiguration _config;

        
        public PizzaBuilder(bool isMignon)
        {
            _config = _configurations[isMignon];

            _ingredients = new List<Ingredient>();

            AddTomato();
            AddMozzarella();
        }

        public PizzaBuilder AddTomato()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Tomato,
                Quantity = _config.Tomato,
            });

            return this;
        }

        public PizzaBuilder AddMozzarella()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Mozzarella,
                Quantity = _config.Mozzarella,
            });

            return this;
        }

        public PizzaBuilder AddHam()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Ham,
                Quantity = _config.Ham,
            });

            return this;
        }

        public PizzaBuilder AddMushrooms()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Mushrooms,
                Quantity = _config.Ham,
            });

            return this;
        }

        public PizzaBuilder AddRocketSalad()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.RocketSalad,
                Quantity = _config.RocketSalad,
            });

            return this;
        }

        public Pizza Create(bool isMignon)
        {
            var ingredientsClones = _ingredients
                .Select(x => new Ingredient { Type = x.Type, Quantity = x.Quantity });

            var pizza = new Pizza(isMignon);

            pizza.Ingredients.AddRange(ingredientsClones);

            return pizza;
        }

        private class PizzaConfiguration
        {
            public int Tomato { get; set; }
            public int Mozzarella { get; set; }
            public int Ham { get; set; }
            public int Mushroom { get; set; }
            public int RocketSalad { get; set; }
        }
    }

    public enum IngredientType
    {
        Tomato,
        Mozzarella,
        Ham,
        Mushrooms,
        RocketSalad,
    }

    public class Ingredient
    {
        public IngredientType Type { get; set; }
        public int Quantity { get; set; } 

        public override string ToString()
        {
            return $"Type: {Type}, Quantity: {Quantity}";
        }
    }

    interface IPizzaBuilder
    {
         Pizza Create(bool isMignon);
    }
}
