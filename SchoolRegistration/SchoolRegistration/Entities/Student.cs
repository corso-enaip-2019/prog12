using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistration.Entities
{
    class Student
    {
        string _firstName;

        public Student(string firstName, string lastName, string birthTown)
        {
            FirstName = firstName;
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            private set
            {
                if (!IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
            }
        }

        bool IsNullOrEmpty(string value)
        {
            return value == null || value.Equals("");
        }

        public bool IsValid()
        {
            return !(IsNullOrEmpty(_firstName) ||
        }
    }
}
