using System;
using System.Reflection;
using System.Collections.Generic;

namespace Validate
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidator iv = new IdValid();
            IValidator nv = new NameNotEmpty();
            IValidator bv = new BirthInRange();
            IValidator av = new AddressValidator();

            ValidatorFactory vf = new ValidatorFactory();

            List<IValidator> lv = vf.CreateValidator(new List<string> { "IdValid", "NameNotEmpty" });

            iv = lv[0];

            List<Person> people = CreatePeopleMockUp();

            foreach (Person p in people)
            {
                List<string> diags = iv.Validate(p);
                diags.AddRange(nv.Validate(p));
                diags.AddRange(bv.Validate(p));
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

    interface IValidator
    {
        List<string> Validate(Person person);
    }

    class IdValid : IValidator
    {
        public List<string> Validate(Person person)
        {
            List<string> result = new List<string>();

            if (person.Id < 0)
                result.Add("l'`Id` non può essere negativo");

            return result;
        }
    }

    class NameNotEmpty : IValidator
    {
        public List<string> Validate(Person person)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrWhiteSpace(person.Name))
                result.Add("il `Name` non può essere null o stringa blank");

            return result;
        }
    }

    class BirthInRange : IValidator 
    {
        public List<string> Validate(Person person)
        {
            List<string> result = new List<string>();

            if (person.Birth.Year < 1900 || person.Birth.Year> 2017)
                result.Add("la data di nascita non può essere fuori dal range 1900 - 2017");

            return result;
        }
    }

    class AddressValidator : IValidator
    {
        public List<string> Validate(Person person)
        {
            List<string> result = new List<string>();

            result.AddRange(AddressNotNull(person));
            result.AddRange(StreetNotEmpty(person));
            result.AddRange(ZipValid(person));

            return result;
        }

        List<string> AddressNotNull(Person person)
        {
            List<string> result = new List<string>();

            if (person.Address == null)
            {
                result.Add("l'intero oggetto `Address` non può essere null sulla `Person`");
            }

            return result;
        }

        List<string> StreetNotEmpty(Person person)
        {
            List<string> result = new List<string>();

            if (person.Address != null && string.IsNullOrWhiteSpace(person.Address.Street))
            {
                result.Add("la strada non può essere stringa blank");
            }
            
            return result;
        }

        List<string> ZipValid(Person person)
        {
            List<string> result = new List<string>();

            if (person.Address != null && person.Address.ZIP.ToString().Length != 5)
            {
                result.Add("il numero deve avere 5 cifre");
            }

            return result;
        }

    }

    class ValidatorFactory
    {
        public List<IValidator> CreateValidator(List<string> validatorNames)
        {
            string ns = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;
            List<IValidator> result = new List<IValidator>();

            foreach (string validatorName in validatorNames)
            {

                Type type = Type.GetType($"{ns}.{validatorName}");

                if (type == null)
                    throw new ArgumentException();
              
                result.Add((IValidator) Activator.CreateInstance(type));
            }
            return result;
        }
    }

    class Database
    {
        DB db = DB.Instance;

        List<IValidator> _validators;

        private Database(List<IValidator> validators)
        {
            _validators = validators;    
        }

        public List<string> Save(Person person)
        {
            List<string> diags = new List<string>();

            foreach (IValidator validator in _validators)
            {
                diags.AddRange(validator.Validate(person));
            }

            if (diags.Count == 0)
            {
                db.Put(person);
            }

            return diags;
        }

    }

    sealed class DB
    {
        Dictionary<int, Person> _db;

        public static DB Instance { get; }

        static DB()
        {
            Instance = new DB();
        }

        private DB ()
        {
            _db = new Dictionary<int, Person>();
        }
        
        public Person Get(int id)
        {
            return _db[id];
        }

        public void Put(Person person)
        {
            _db.Add(person.Id, person);
        }
    }

}
