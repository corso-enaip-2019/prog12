using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeGeometry
{
    class Square : GeoForm
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
            Name = "Quadrato";
        }

        public override double ComputePerimeter()
        {
            return 4.0 * Side;
        }

        public override double ComputeArea()
        {
            return Side * Side;
        }

    }
}
