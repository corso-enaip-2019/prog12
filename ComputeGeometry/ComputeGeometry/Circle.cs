using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeGeometry
{
    class Circle : GeoForm
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
            Name = "Cerchio";
        }

        public override double ComputePerimeter()
        {
            return 2.0 * Math.PI * Radius;
        }

        public override double ComputeArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double ComputeCirle()
        {
            return ComputePerimeter();
        }
    }
}
