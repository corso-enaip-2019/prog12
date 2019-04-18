using System;
using System.Collections.Generic;
using System.Linq;

namespace Query1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = CreateMockUps();

            Console.WriteLine("All the Person with pets living in 'London'");

            foreach (Person p in list
                                .Where(p => p.HasPets && p.Address.City == "London"))
                Console.WriteLine($"Name: {p.Name}, Surname: {p.Surname}");

            Console.WriteLine();
            Console.WriteLine("All the Person ordering first by City and then by Surname");

            foreach (Person p in list
                                .OrderBy(p => p.Address.City)
                                .ThenBy(p => p.Surname))
                Console.WriteLine($"Name: {p.Name}, Surname: {p.Surname}, City: {p.Address.City}");

            Console.WriteLine();
            Console.WriteLine("The list of cities involved");

            foreach (string c in list
                                .Select(p => p.Address.City)
                                .Distinct()
                                .OrderBy(s => s))
                Console.WriteLine($"City: {c}");

            Console.WriteLine();
            Console.WriteLine("A list of cities, every city with the number of people living in it");

            foreach (var groupByCity in list
                                .GroupBy(p => p.Address.City))
            {
                Console.WriteLine($"City: {groupByCity.Key}, Inhabitants {groupByCity.Count()}");
            }

            Console.WriteLine();
            Console.WriteLine("A list of 'addresses', every address with the property of the Address class but also a list with all the people leaving in that address");

            foreach (var groupAddress in list
                                .GroupBy(p => p.Address))
            {
                Console.WriteLine($"Address Street: {groupAddress.Key.Street}, Number: {groupAddress.Key.Number}, City: {groupAddress.Key.City}");
                foreach (Person p in groupAddress)
                    Console.WriteLine($"    Name: {p.Name}, Surname: {p.Surname}");

            }

            Console.WriteLine();

            Console.ReadKey();

        }

        static List<Person> CreateMockUps()
        {
            Address myaddress = new Address { Street = "via Salento", Number = 116, City = "Taranto" };

            return new List<Person>
            {
                new Person { Name = "Dario", Surname = "Palmisano", HasPets = true, Address = myaddress},
                new Person { Name = "Antonio", Surname = "Tosi", HasPets = false, Address = myaddress},
                new Person { Name = "Gerardo", Surname = "Giannone", HasPets = false, Address = myaddress},
                new Person { Name = "Ciccio", Surname = "Cappuccio", HasPets = false, Address = new Address {Street = "via Rozzol", Number = 55, City = "Trieste"}},
                new Person { Name = "Giorgio", Surname = "Brambilla", HasPets = true, Address = new Address {Street = "via Della Spiga", Number = 87, City = "Milano"}},
                new Person { Name = "Felice", Surname = "Sciscia", HasPets = false, Address = new Address {Street = "via Posillipo", Number = 12, City = "Napoli"}},
                new Person { Name = "Henry", Surname = "Smith", HasPets = false, Address = new Address {Street = "Parliament", Number = 1, City = "London"}},
                new Person { Name = "John", Surname = "Doe", HasPets = true, Address = new Address {Street = "Brexit", Number = 28, City = "London"}},
            };
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool HasPets { get; set; }
        public Address Address { get; set; }
    }

    class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
    }

}
