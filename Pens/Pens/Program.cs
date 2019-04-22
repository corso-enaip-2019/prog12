using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens
{
    class Program
    {
        static void Main(string[] args)
        {
            Pen pen;
            PenFactory penFactory = new PenFactory(new TubeFactory(), new CapFactory());
            for (int i = 0; i < 10000000; i++)
            {
                pen = penFactory.Create(20, 3);
            }
        }
    }

    class Pen
    {
        public Tube Tube { get; set; }
        public Cap Cap { get; set; }

        public Pen(Tube tube, Cap cap)
        {
            Tube = tube;
            Cap = cap;
        }
    }

    class Tube
    {
        public Tube (double length, double radius)
        {
            Length = length;
            Radius = radius;
        }

        public double Length { get; set; }
        public double Radius { get; set; }
    }

    class Cap
    {
        public Cap(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }
    }

    interface ITubeFactory
    {
        Tube Create(double length, double radius);
    }

    class TubeFactory : ITubeFactory
    {
        public Tube Create(double length, double radius)
        {
            double lengthRnd = length * (1 + new Random().Next(-2, 2) / 100.0);
            double radiusRnd = radius * (1 + new Random().Next(-2, 2) / 100.0);
 
            return new Tube(lengthRnd, radiusRnd);
        }
    }

    interface ICapFactory
    {
        Cap Create(double radius);
    }

    class CapFactory : ICapFactory
    {
        public Cap Create(double radius)
        {
            double radiusRnd = radius * (1 + new Random().Next(-2, 2) / 100.0);

            return new Cap(radiusRnd);
        }
    }

    class PenFactory
    {
        Tube tube;
        Cap cap;
        ITubeFactory _tubeFactory;
        ICapFactory _capFactory;

        public PenFactory(ITubeFactory tubeFactory, ICapFactory capFactory)
        {
            _tubeFactory = tubeFactory;
            _capFactory = capFactory;
        }
      
        public Pen Create(double length, double radius)
        {
            tube = _tubeFactory.Create(length, radius);
            cap = _capFactory.Create(radius);

            double lengthDelta = Math.Abs(tube.Length - length);
            double radiusDelta = Math.Abs(tube.Radius - cap.Radius)/radius;

            if (lengthDelta / length > 0.01)
                throw new Exception($"Tube length delta {lengthDelta} exceed 1.0%");

            if (radiusDelta > 0.005)
                throw new Exception($"Radius tube delta {radiusDelta} exceed 0.5%");

            return new Pen(tube, cap);
        }
    }
}
