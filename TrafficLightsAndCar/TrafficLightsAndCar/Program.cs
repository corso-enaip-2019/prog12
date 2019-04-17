using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsAndCar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = CreateMocks();
        }

        static List<Car> CreateMocks()
        {
            List<TrafficLight> trafficLights = new List<TrafficLight>
            {
                new TrafficLight(5),
                new TrafficLight(2),
                new TrafficLight(3),
                new TrafficLight(4),
                new TrafficLight(1),
            };

            List<Car> cars = new List<Car>
            {
                new Car("Fiat Ritmo", "Blue", trafficLights),
                new Car("Pegeot 205", "Green", trafficLights),
                new Car("Ferrari GTO", "Red",trafficLights),
            };

            return cars;
        }
    }

    class Car
    {
        public Car(string model, string color, List<TrafficLight> trafficLights)
        {
            Model = model;
            Color = color;
            _trafficLights = new List<TrafficLight>();
            _trafficLights.AddRange(trafficLights);

            Console.WriteLine($"Car waiting at traffic light ID {_trafficLights[0].Id}");
            _trafficLights[0].OnNowGreen += CarPass;
            _trafficLights[0].FireSwitchLigth();
        }

        private void CarPass()
        {

            _trafficLights[0].OnNowGreen -= CarPass;

            Console.WriteLine($"{Model} find Green at traffic light ID {_trafficLights[0].Id}");
            _trafficLights.RemoveAt(0);
            if (_trafficLights.Count > 0)
            {
                Console.WriteLine($"Car waiting at traffic light ID {_trafficLights[0].Id}");
                _trafficLights[0].OnNowGreen += CarPass;
                _trafficLights[0].FireSwitchLigth();

            }
        }

        public string Model { get; }
        public string Color { get; }

        List<TrafficLight> _trafficLights;
    }

    class TrafficLight
    {
        static int idGenerator = 0;

        public TrafficLight(int timeToWait)
        {
            Id = idGenerator++;
            TimeToWait = timeToWait;
        }

        public int Id { get; }
        public int TimeToWait;
        public event NowGreen OnNowGreen;

        public void FireSwitchLigth()
        {
            System.Threading.Thread.Sleep(TimeToWait * 1000);

            if (OnNowGreen != null)
                OnNowGreen.Invoke();
        }
    }

    public delegate void NowGreen();

}
