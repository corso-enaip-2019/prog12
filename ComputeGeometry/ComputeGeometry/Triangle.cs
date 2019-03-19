using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeGeometry
{
    class Triangle : GeoForm
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }

        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            Name = "Triangolo";
        }

        public override double ComputePerimeter()
        {
            return Side1 + Side2 + Side3;
        }

        public override double ComputeArea()
        {
            double semiPerimeter = ComputePerimeter() / 2.0;

            return Math.Sqrt(
                semiPerimeter
                    * (semiPerimeter - Side1)
                    * (semiPerimeter - Side2)
                    * (semiPerimeter - Side3) );
        }

    }
}

