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
        }

        List<Person> CreatePersonMocks()
        {
            Person person;
            Car car;
            Address address;
            List<Person> people = new List<Person>();

            /*            person = new Person()
                        {
                            Name = "",
                            Surname = "";
                        Height = 1.79;
                    };
              */

            person = new Person("Dario", "Palmisano", 1.79);
            car = new Car("Fusion", "Ford");
            address = new Address("Via Francesco Fiascone", "45/b", "34135", "Trieste");
            person.Cars.Add(car);
            person.HomeAddress = address;

            people.Add(person);

            person = new Person("Francoise", "Misiti", 1.70);
            //Car car = 
            address = new Address("Via Salento", "116", "74100", "Taranto");
            person.HomeAddress = address;

            people.Add(person);

            person = new Person("John", "Doe");
            address = new Address("Pacific cost avenue", "10505", "USA-3277", "San Francisco");
            person.HomeAddress = address;
            car = new Car("Daytona", "Ferrari");
            person.Cars.Add(car);
            car = new Car("Corvette", "Chevrolet ");
            person.Cars.Add(car);

            return people;
        }

        void PrintPeople(List<Person> people)
        {
            foreach (Person person in people)
            {
                PrintPerson(person);
            }
        }

        void PrintPerson(Person person)
        {
            Console.WriteLine($"Name:    {person.Name}");
            Console.WriteLine($"Surname: {person.Surname}");

            if (person.Height > 0.0)
            {
                Console.WriteLine($"Surname: {person.Height}");
            }

            Console.WriteLine();
        }

        void PrintAddress(Address address)
        {
            Console.WriteLine("\tAddreess");

            Console.WriteLine($"\t\t{address.Street}, {address.Number}");
            Console.WriteLine($"\t\t{address.ZipCode}");
            Console.WriteLine($"\t\t{address.City}");

        }

        void PrintCars(List<Car> cars)
        {
            Console.WriteLine("Cars");

            foreach (Car car in cars)
            {
                Console.WriteLine($"\tModel:  {car.Model}");
                Console.WriteLine($"\tBrand:  {car.Brand}");

                if (car.Mileage > 0.0)
                {
                    Console.WriteLine($"\tMileage: {car.Mileage}");
                }

                Console.WriteLine();
            }
        }
    }

    class Person
    {
        public string Name { get; }
        public string Surname { get; }
        public double Height { get; set; }

        public Address HomeAddress { get; set; }
        public List<Car> Cars { get; set; }

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
        public string Model { get; }
        public string Brand { get; }
        public double Mileage { get; set; }

        public Car(string model, string brand)
        {
            Model   = model;
            Brand   = brand;
            Mileage = 0.0;
        }
    }
}
