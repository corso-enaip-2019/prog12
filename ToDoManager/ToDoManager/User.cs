using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManager
{

    class User
    {
        int _id;
        string _name;

        public int Id {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            private set
            {
                _name = value;
            }

        }
        static int lastId = 0;

        public User(string name)
        {
            Name = name;
            Id = lastId++;
        }
    }
}
