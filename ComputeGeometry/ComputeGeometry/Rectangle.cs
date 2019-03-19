using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeGeometry
{
    class Rectangle : GeoForm
    {

        public double Base { get; set; }
        public double Height { get; set; }

        public Rectangle(double basep, double height)
        {
            Base = basep;
            Height = height;
            Name = "Rettangolo";
        }

        public override double ComputePerimeter()
        {
            return 2.0 * (Base + Height);
        }

        public override double ComputeArea()
        {
            return Base * Height;
        }
    }
}
