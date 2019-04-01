using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    abstract class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string  Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The name cannot be empty or blank");
                name = value;
            }
        }
        private string name;


        //public string GetName()
        //{
        //    return name;
        //}

        //private void SetName(string value)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //        throw new ArgumentException("The name cannot be empty or blank");
        //    name = value;
        //}
    }

    class Baby : Person
    {

    }
    class Mum : Person
    {

    }
    class Dad : Person
    {

    }
}
