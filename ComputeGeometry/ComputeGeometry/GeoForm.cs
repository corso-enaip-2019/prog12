using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeGeometry
{
    public abstract class GeoForm
    {
        public string Name { set; get; }
        public abstract double ComputePerimeter();
        public abstract double ComputeArea();
    }
}
