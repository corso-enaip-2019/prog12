using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Numero di inquilini di tutti gli appartamenti di classe enerfgetica A o B
            // 2) media del numero di inquilini di tutti gli appartamanti
            // 3) di ogni citta, nome di citta e elenco di vie degli appartamenti
            // 4) di ogni citta, nome di citta e media di metri quadri
            // 5) di ogni citta, nome di citta e media di metri quadri
            //                    tutti ordinati per nome di citta,e dentro le citta ordianate per via.
            // 6) elenco dei nomi di citta che hano solo appartamentid NON in calsse A, B, C.
        }
    }
    class Flat
    {
        public int SquaresMeters { get; set; }
        public string Street { get; set; }
        public String City { get; set; }
        public int Flatmates { get; set; }
        public EnergyClassType EnergyClass { get; set; }
    }

    enum EnergyClassType
    {
        A, B , C, D, E, F, G
    }
}
