using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Smartphone> smartphones = CreateMock();

            //List<Smartphone> smartphonesWithColor = Filter(smartphones, new ColorFilter("Gold"));
            IEnumerable<Smartphone> smartphonesWithColor = Filter(smartphones, s => s.Color.Equals("Gold"));

            //List<Smartphone> smartphonesCostLess = Filter(smartphones, new CostLessFilter(300m));
            IEnumerable<Smartphone> smartphonesCostLess = Filter(smartphones, s => s.Cost < 300m);

            //IEnumerable<string> smartphonesColors = Project(smartphones, new GetColors());
            IEnumerable<string> smartphonesColors = Project(smartphones, s => s.Color);

            foreach (Smartphone sm in smartphones)
            {
                PrintSmartphone(sm);
            }

            foreach (Smartphone sm in smartphonesWithColor)
            {
                PrintSmartphone(sm);
            }

            foreach (Smartphone sm in smartphonesCostLess)
            {
                PrintSmartphone(sm);
            }

            foreach (string item in smartphonesColors)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static List<Smartphone> CreateMock()
        {
            List<Smartphone> mock = new List<Smartphone>();

            mock.Add(new Smartphone("S71", "2", 200m, "Black"));
            mock.Add(new Smartphone("iPhoneX", "10", 800m, "Gold"));
            mock.Add(new Smartphone("Nokia", "1.5", 300m, "White"));

            return mock;
        }

//        static IEnumerable<T> Filter<T>(IEnumerable<T> input, IFilter<T> filter)
        static IEnumerable<T> Filter<T>(IEnumerable<T> input, Filter<T> condition)
        {
            List<T> result = new List<T>();

            foreach (T sm in input)
            {
                if (condition(sm))
                {
                    result.Add(sm);
                }
            }

            return result;
        }

        //static IEnumerable<Tout> Project<Tin, Tout>(IEnumerable<Tin> input, IProject<Tin,Tout> projection)
        static IEnumerable<Tout> Project<Tin, Tout>(IEnumerable<Tin> input, Project<Tin, Tout> projection)
        { 
            List<Tout> result = new List<Tout>();

            foreach (Tin item in input)
            {
                result.Add(projection(item));
            }

            return result;
        }

        static void PrintSmartphone(Smartphone sm)
        {
            Console.WriteLine($"Model: {sm.Model} Version: {sm.Version} Cost: {sm.Cost} Color: {sm.Color}");
        }
    }

    public class Smartphone
    {
        public string  Model { get; }
        public string  Version { get; }
        public decimal Cost { set; get; }
        public string  Color { get; }

        public Smartphone(string model, string version, decimal cost, string color)
        {
            Model = model;
            Version = version;
            Cost = cost;
            Color = color;
        }
    }

    interface IFilter<T>
    {
        bool Filter(T item);
    }

    interface IProject<Tin, Tout>
    {
        Tout Project(Tin item);
    }
    
    public class GetColors : IProject<Smartphone, string>
    {
        public string Project(Smartphone item)
        {
            return item.Color;
        }
    }

    public class ColorFilter : IFilter<Smartphone>
    {
        string _color;

        public ColorFilter(string color)
        {
            _color = color;
        }

        public bool Filter(Smartphone sm) {
            return sm.Color.Equals(_color);
        }
    }

    public class CostLessFilter : IFilter<Smartphone>
    {
        decimal _cost;

        public CostLessFilter(decimal cost)
        {
            _cost = cost;
        }

        public bool Filter(Smartphone sm)
        {
            return sm.Cost < _cost;
        }
    }

    delegate bool Filter<T>(T item);
    delegate Tout Project<Tin, Tout>(Tin item);
}
