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

            List<Smartphone> smartphonesWithColor = Filter(smartphones, new ColorFilter("Gold"));

            List<Smartphone> smartphonesCostLess = Filter(smartphones, new CostLessFilter(300m));

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

            Console.ReadKey();
        }

        static List<Smartphone> CreateMock()
        {
            List<Smartphone> mock = new List<Smartphone>();

            mock.Add(new Smartphone("S71", "2", 200m, "Black"));
            mock.Add(new Smartphone("iPhoneX", "10", 800m, "Gold"));

            return mock;
        }

        static List<T> Filter<T>(List<T> input, IFilter<T> filter)
        {
            List<T> result = new List<T>();

            foreach (T sm in input)
            {
                if (filter.Filter(sm))
                {
                    result.Add(sm);
                }
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
}
