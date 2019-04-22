using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartsAndProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDiscount> List = Discont.List;

            List<Cart> carts = CreateCartsMockUp();

            foreach (Cart cart in carts)
            {
                Console.WriteLine($"Initial cart cost: {cart.Products.Sum(p => p.Price)}");
                foreach (IDiscount discount in List)
                {
                    if (discount.IsDiscountDay(new DateTime(2019, 4, 23)))
                        discount.ApplyDiscount(cart);

                    Console.WriteLine($"\tInitial cost after discount: {cart.Products.Sum(p => p.Price)}");
                }
            }

            Console.ReadKey();
        }

        static List<Cart> CreateCartsMockUp()
        {
            return new List<Cart>
            {
                new Cart
                {
                    Products = new List<Product>
                    {
                        new Product("Uova", 10.0m),
                        new Product("Uova", 10.0m),
                        new Product("Uova", 10.0m),
                        new Product("Caffe", 9.0m),
                        new Product("Caffe", 9.0m),
                        new Product("Caffe", 9.0m),
                        new Product("Farina", 1.0m),
                        new Product("Farina", 1.0m),
                        new Product("Farina", 1.0m),
                        new Product("Zucchero", 5.0m),
                        new Product("Zucchero", 5.0m),
                        new Product("Zucchero", 5.0m),
                        new Product("Brandy", 10.0m),
                        new Product("Brandy", 10.0m),
                        new Product("Brandy", 10.0m),
                    }
                },
                new Cart
                {
                    Products = new List<Product>
                    {
                        new Product("Latte", 1.5m),
                        new Product("Latte", 1.5m),
                        new Product("Latte", 1.5m),
                        new Product("Miele", 2.0m),
                        new Product("Miele", 2.0m),
                        new Product("Miele", 2.0m),
                        new Product("Pane", 1.7m),
                        new Product("Pane", 1.7m),
                        new Product("Pane", 1.7m),
                        new Product("Pomodori", 0.6m),
                        new Product("Pomodori", 0.6m),
                        new Product("Pomodori", 0.6m),
                        new Product("Friselle", 0.7m),
                        new Product("Friselle", 0.7m),
                        new Product("Friselle", 0.7m),
                    }
                },
                new Cart
                {
                    Products = new List<Product>
                    {
                        new Product("Whisky", 11.5m),
                        new Product("Whisky", 11.5m),
                        new Product("Whisky", 11.5m),
                        new Product("Rum", 8.0m),
                        new Product("Rum", 8.0m),
                        new Product("Rum", 8.0m),
                        new Product("Cognaq", 12.0m),
                        new Product("Cognaq", 12.0m),
                        new Product("Cognaq", 12.0m),
                        new Product("Coka-cola", 1.5m),
                        new Product("Coka-cola", 1.5m),
                        new Product("Coka-cola", 1.5m),
                    }
                },
            };
        }

    }
    class Cart
    {
        public List<Product> Products { get; set; }
    }

    class Product
    {
        public string Name { get; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
    interface IDiscount
    {
        bool IsDiscountDay(DateTime date);
        void ApplyDiscount(Cart cart);
    }


    abstract class Discont : IDiscount
    {
        public static List<IDiscount> List { get; }

        static Discont()
        {
            List = new List<IDiscount>();

            List.Add(Discount0.Instance);
            List.Add(Discount10.Instance);
            List.Add(Discount15.Instance);
        }

        public virtual bool IsDiscountDay(DateTime date) { return true; }

        public virtual void ApplyDiscount(Cart cart) { }
    }

    class Discount0 : Discont
    {
        public static IDiscount Instance { get; }

        static Discount0()
        {
            Instance = new Discount0();
        }

        private Discount0() { }


    }

    class Discount10 : Discont
    {
        const decimal DISCOUNT = 0.1m;

        public static IDiscount Instance { get; }

        static Discount10()
        {
            Instance = new Discount10();
        }

        private Discount10() { }

        public override bool IsDiscountDay(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Monday;
        }

        public override void ApplyDiscount(Cart cart)
        {
            if (cart.Products.Count > 10)
            {
                foreach(Product product in cart.Products)
                {
                    product.Price -= product.Price * DISCOUNT;
                }
            }

        }
    }

    class Discount15 : Discont
    {
        const decimal DISCOUNT = 0.15m;

        public static IDiscount Instance { get; }

        static Discount15()
        {
            Instance = new Discount15();
        }

        private Discount15() { }

        public override bool IsDiscountDay(DateTime date)
        {
            return date.Day % 2 == 1;
        }

        public override void ApplyDiscount(Cart cart)
        {
            if (cart.Products.Sum(p => p.Price) >= 100m)
            {
                foreach(Product product in cart.Products)
                {
                    product.Price -= product.Price * DISCOUNT;
                }
            }
        }
    }
}
