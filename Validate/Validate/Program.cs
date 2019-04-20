using System;
using System.Collections.Generic;

namespace ValidateWithTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonValidator pv = new PersonValidator();
            AddressValidator av = new AddressValidator();
            List<Person> people = CreatePeopleMockUp();

            foreach (Person p in people)
            {
                List<string> diags = pv.Validate(p);
                diags.AddRange(av.Validate(p));
                if (diags.Count > 0)
                {
                    Console.WriteLine(p.Name);
                    foreach (string msg in diags)
                        Console.WriteLine(msg);
                }
            }

            Console.ReadKey();
        }

        static List<Person> CreatePeopleMockUp()
        {
            return new List<Person>
                {
                    new Person
                    {
                        Id = 0,
                        Name = "Dario",
                        Birth = new DateTime(1966, 06, 03),
                        Address = new Address { Street = "via Salento 116", ZIP = 74100 }
                    },
                    new Person
                    {
                        Id = 1,
                        Name = "Antonio",
                        Birth = new DateTime(1899, 06, 03),
                        
                    },
                    new Person
                    {
                        Id = -1,
                        Name = "Gerardo",
                        Birth = new DateTime(1962, 06, 03),
                        Address = new Address { ZIP = 74100 }
                    },
                    new Person
                    {
                        Id = -1,
                        Name = "",
                        Birth = new DateTime(1899, 06, 03),
                        Address = new Address { Street = "via Salento 116", ZIP = 7400 }
                    },
                };
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public Address Address { get; set; }
    }

    class Address
    {
        public string Street { get; set; }
        public int ZIP { get; set; }
    }

    abstract class BasePersonValidator
    {
        public List<string> Validate(Person person)
        {
            string value;
            List<string> result = new List<string>();

            value = IdValid(person.Id);
            if (value != null) result.Add(value);

            value = NameNotEmpty(person.Name);
            if (value != null) result.Add(value);

            value = BirthInRange(person.Birth);
            if (value != null) result.Add(value);

            return result;
        }

        public abstract string IdValid(int id);

        public abstract string NameNotEmpty(string name);

        public abstract string BirthInRange(DateTime birth);
    }

    class PersonValidator : BasePersonValidator
    {
        public override string IdValid(int id)
        {
            return (id < 0) ? "l'`Id` non può essere negativo" : null;
        }

        public override string NameNotEmpty(string name)
        {
            return (string.IsNullOrWhiteSpace(name)) ? "il `Name` non può essere null o stringa blank" : null;
        }

        public override string BirthInRange(DateTime birth)
        {
            return (birth.Year < 1900 || birth.Year > 2017) ? "la data di nascita non può essere fuori dal range 1900 - 2017" : null;
        }
    }

    interface IAddressValidator
    {
        List<string> Validate(Person person);
    }

    class AddressValidator : IAddressValidator
    {
        public List<string> Validate(Person person)
        {
            string value;
            List<string> result = new List<string>();

            value = AddressNotNull(person.Address);
            if (value != null) result.Add(value);
            else
            { 
                value = StreetNotEmpty(person.Address.Street);
                if (value != null) result.Add(value);

                value = ZipValid(person.Address.ZIP);
                if (value != null) result.Add(value);
            }

            return result;
        }
        

        string AddressNotNull(Address address)
        {
            return (address == null) ? "l'intero oggetto `Address` non può essere null sulla `Person`" : null;
        }

        string StreetNotEmpty(string street)
        {
            return (string.IsNullOrWhiteSpace(street)) ? "la strada non può essere stringa blank" : null;
        }

        string ZipValid(int zip)
        {
            return (zip.ToString().Length != 5) ? "il numero deve avere 5 cifre" : null;
        }
    }

}
