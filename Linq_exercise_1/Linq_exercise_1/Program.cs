using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) numero di inquilini di tutti gli appartamenti di classe energetica A o B
            // 2) media del numero di inquilini di tutti gli appartamenti
            // 3) di ogni città, nome di città e elenco di vie degli appartamenti
            // 4) di ogni città, nome di città e media dei metri quadri
            // 5) di ogni città, nome di città e media dei metri quadri,
            //        tutti ordinati per nome di città, e dentro la città ordinati per via.
            // 6) elenco dei nomi di città che hanno solo appartamenti NON in classe A, B, C.

            IEnumerable<Flat> flats = CreateFlatMocks();

            int sum = 0;
            foreach (Flat flat in flats.
                                        Where(f => (f.EnergyClass == EnergyClassType.A ||
                                                    f.EnergyClass == EnergyClassType.B)))
            {
                sum += flat.Flatmates;
            }

            Console.WriteLine("Numero di inquilini di tutti gli appartamenti di classe energetica A o B: {0}", sum);
            Console.WriteLine();
            Console.WriteLine();

            sum = 0;
            foreach (Flat flat in flats)
            {
                sum += flat.Flatmates;
            }

            Console.WriteLine("Media del numero di inquilini di tutti gli appartamenti: {0}",(double) sum/flats.Count());
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Di ogni città, nome di città e elenco di vie degli appartamenti");
            Console.WriteLine();

            IEnumerable<IGrouping<string, Flat>> flatsByCity = flats.GroupBy(f => f.City);
            
            foreach (IGrouping<string, Flat> city in flatsByCity)
            {
                Console.WriteLine("Citta': {0}", city.Key);

                foreach (Flat flat in city)
                {
                    Console.WriteLine("\tIndirizzo: {0}", flat.Street);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Di ogni città, nome di città e media dei metri quadri");
            Console.WriteLine();

            foreach (IGrouping<string, Flat> city in flatsByCity)
            {
                sum = 0;
                Console.WriteLine("Citta': {0}", city.Key);

                foreach (Flat flat in city)
                {
                    Console.WriteLine("\tIndirizzo: {0}", flat.Street);
                    sum += flat.SquaresMeters;
                }

                Console.WriteLine("\tMedia metri quadri: {0}", (double) sum/city.Count());
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Di ogni città, nome di città e media dei metri quadri,");
            Console.WriteLine("tutti ordinati per nome di città, e dentro la città ordinati per via.");
            Console.WriteLine();

            IEnumerable<IGrouping<string, Flat>> flatsByCityOrdered = flats
                .OrderBy(f => f.City)
                .GroupBy(f => f.City);

            foreach (IGrouping<string, Flat> city in flatsByCityOrdered)
            {
                sum = 0;
                Console.WriteLine("Citta': {0}", city.Key);

                foreach (Flat flat in city.OrderBy(f => f.Street))
                {
                    Console.WriteLine("\tIndirizzo: {0}", flat.Street);
                    sum += flat.SquaresMeters;
                }

                Console.WriteLine("\tMedia metri quadri: {0}", (double)sum / city.Count());
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Elenco dei nomi di città che hanno solo appartamenti NON in classe A, B, C.");

            var flatsByEnergyClassOrdered = flats
                                            .GroupBy(f => f.EnergyClass);

            List<string> citiesNotABC = new List<string>();
            foreach (var flatG in flatsByEnergyClassOrdered)
            {
                if (flatG.Key > EnergyClassType.C)
                    foreach (Flat f in flatG)
                        citiesNotABC.Add(f.City);
            }

            foreach (string city  in citiesNotABC.Distinct())
            {
                Console.WriteLine("Citta': {0}", city);

            }

            Console.ReadKey();
        }

        static IEnumerable<Flat> CreateFlatMocks()
        {
            return new List<Flat>
            {
                new Flat() { SquaresMeters = 50,  Street = "via G. Cesare",          City = "Roma",    Flatmates = 2, EnergyClass = EnergyClassType.A},
                new Flat() { SquaresMeters = 70,  Street = "via Montenapolene",      City = "Milano",  Flatmates = 1, EnergyClass = EnergyClassType.B},
                new Flat() { SquaresMeters = 85,  Street = "Largo A. Roiano",        City = "Trieste", Flatmates = 3, EnergyClass = EnergyClassType.F},
                new Flat() { SquaresMeters = 90,  Street = "via Pestalozzi",         City = "Genova",  Flatmates = 1, EnergyClass = EnergyClassType.E},
                new Flat() { SquaresMeters = 78,  Street = "Calle S. Andrea",        City = "Venezia", Flatmates = 3, EnergyClass = EnergyClassType.C},
                new Flat() { SquaresMeters = 65,  Street = "via dei Fori Imperiali", City = "Roma",    Flatmates = 2, EnergyClass = EnergyClassType.C},
                new Flat() { SquaresMeters = 55,  Street = "via G. Parini",          City = "Milano",  Flatmates = 5, EnergyClass = EnergyClassType.B},
                new Flat() { SquaresMeters = 100, Street = "via Cavana",             City = "Trieste", Flatmates = 3, EnergyClass = EnergyClassType.E},
                new Flat() { SquaresMeters = 200, Street = "Piazza Liberta'",        City = "Trieste", Flatmates = 1, EnergyClass = EnergyClassType.F},
                new Flat() { SquaresMeters = 105, Street = "via Del Porto",          City = "Genova",  Flatmates = 2, EnergyClass = EnergyClassType.G},
            };
        }


    }
    class Flat
    {
        public int SquaresMeters { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Flatmates { get; set; }
        public EnergyClassType EnergyClass { get; set; }
    }

    enum EnergyClassType
    {
        A, B , C, D, E, F, G
    }
}
