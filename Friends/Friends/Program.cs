using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends
{
    class Program
    {
        static void Main(string[] args)
        {
            Kid dario = new Kid("Dario");
            Kid vito = new Kid("Vito");
            Kid antonio = new Kid("Antonio");
            Kid carillo = new Kid("carillo");

            dario.AddFriend(vito);

            Console.WriteLine("Amici di Dario");

            foreach (Kid kid in dario.Friends)
            {
                Console.WriteLine(kid.Name);
            }

            Console.WriteLine("Amici di Vito");

            foreach (Kid kid in vito.Friends)
            {
                Console.WriteLine(kid.Name);
            }

            dario.AddFriend(antonio);
            Console.WriteLine("Amici di Dario");

            foreach (Kid kid in dario.Friends)
            {
                Console.WriteLine(kid.Name);
            }

            Console.WriteLine("Amici di Antonio");

            foreach (Kid kid in antonio.Friends)
            {
                Console.WriteLine(kid.Name);
            }

            Console.ReadKey();
        }
    }

    class Kid
    {
        public Kid(string name)
        {
            Name = name;
            _Friend = new List<Kid>();
        }

        public string Name { get; }

        public void AddFriend(Kid kid)
        {
            if (! _Friend.Contains(kid))
            {
                _Friend.Add(kid);
            }

            if (!kid.Friends.Contains(this))
            {
                kid.AddFriend(this);
            }
        }

        public List<Kid> Friends
        {
            get
            {
                return _Friend.ToList();
            }
        }

        private List<Kid> _Friend;
    }
}
