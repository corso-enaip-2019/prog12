using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndNestedObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = CreatePersonMocks();

            Print(people);
        }

        static List<Person> CreatePersonMocks()
        {
            List<Person> people = new List<Person>()
            {
                new Person()
                {
                    Name = "Dario",
                    Surname = "Palmisano",
                    Height = 1.79,
                    Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Model = "Fusion",
                            Brand = "Ford",
                        },
                    },
                    HomeAddress = new Address()
                    {
                        Street = "Via Francesco Fiascone",
                        Number = "45/b",
                        ZipCode = "34135",
                        City = "Trieste",
                    },
                },

                new Person()
                {
                    Name = "Francoise",
                    Surname = "Misiti",
                    Height = 1.70,
                    Cars = new List<Car>()
                    {
                    },
                    HomeAddress = new Address()
                    {
                        Street = "Via Salento",
                        Number = "116",
                        ZipCode = "74100",
                        City = "Taranto",
                    },
                },

                new Person()
                {
                    Name = "John",
                    Surname = "Doe",
                    Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Model = "Daytona",
                            Brand = "Ferrari",
                        },
                        new Car()
                        {
                            Model = "Corvette",
                            Brand = "Chevrolet",
                        },
                    },
                    HomeAddress = new Address()
                    {
                        Street = "Pacific cost avenue",
                        Number = "10505",
                        ZipCode = "USA-3277",
                        City = "San Francisco",
                    },
                },
            };

            return people;
        }

        static void Print(List<Person> people)
        {
            foreach (Person person in people)
            {
                Print(person);
            }

            Console.ReadKey();
        }

        static void Print(Person person)
        {
            Console.WriteLine($"Name:    {person.Name}");
            Console.WriteLine($"Surname: {person.Surname}");

            if (person.Height > 0.0)
            {
                Console.WriteLine($"Surname: {person.Height}");
            }

            Console.WriteLine();

            Print(person.HomeAddress);
            Print(person.Cars);

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Print(Address address)
        {
            Console.WriteLine("\tAddress");

            Console.WriteLine($"\t\t{address.Street}, {address.Number}");
            Console.WriteLine($"\t\t{address.ZipCode}");
            Console.WriteLine($"\t\t{address.City}");

        }

        static void Print(List<Car> cars)
        {
            Console.WriteLine("\tCars");

            if (cars.Count == 0)
            {
                Console.WriteLine($"\t\tnone");
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"\t\tModel:  {car.Model}");
                Console.WriteLine($"\t\tBrand:  {car.Brand}");

                if (car.Mileage > 0.0)
                {
                    Console.WriteLine($"\t\tMileage: {car.Mileage}");
                }

                Console.WriteLine();
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Height { get; set; }

        public Address HomeAddress { get; set; }
        public List<Car> Cars { get; set; }

        public Person()
        {
        }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Height = 0.0;
            HomeAddress = null;
            Cars = new List<Car>();
        }

        public Person(string name, string surname, double height) :
            this(name, surname)
        {
            Height = height;
        }

    }

    class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public Address()
        {
        }

        public Address(string street, string number, string zipCode, string city)
        {
            Street  = street;
            Number  = number;
            ZipCode = zipCode;
            City    = city;
        }
    }

    class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Mileage { get; set; }

        public Car()
        { }

        public Car(string model, string brand)
        {
            Model   = model;
            Brand   = brand;
            Mileage = 0.0;
        }
    }
}
