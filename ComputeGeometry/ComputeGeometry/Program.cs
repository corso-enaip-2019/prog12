using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeGeometry
{
    class Program
    {

        static void Main(string[] args)
        {
            List<GeoForm> Lista = new List<GeoForm>();

            Lista.Add(new Circle(5.0));
            Lista.Add(new Triangle(3.5, 7.0, 5.0));
            Lista.Add(new Square(3.7));
            Lista.Add(new Rectangle(3.7, 8.0));

            foreach (GeoForm form in Lista)
            {
                if (form.Name.Equals("Cerchio")) {
                    Console.WriteLine($"Forma {form.Name} Circonferenza {((Circle) form).ComputeCirle()} Area {form.ComputeArea()}");
                }
                else {
                Console.WriteLine($"Forma {form.Name} Perimetro {form.ComputePerimeter()} Area {form.ComputeArea()}");
                }
            }

            Console.ReadKey();
        }
    }
}
