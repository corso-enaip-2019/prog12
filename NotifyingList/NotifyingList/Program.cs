using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyingList
{
    class Program
    {
        static void Main(string[] args)
        {
            NotifyingList<string> nl = new NotifyingList<string>();

            nl.OnListOperation += Message;

            nl.Add(null);
            nl.Add("Dario");
            nl.Add("Francoise");
            nl.Add("Filippo");

            nl.Remove(null);
            nl.Remove("Filippo");

            Console.ReadKey();
        }

        static public void Message(object o, EventArgsOperationAndArg e)
        {
            Console.WriteLine("Operation on List op: {0}, arg: {1}", e.Operation, e.Arg);
        }
    }

    class NotifyingList<T>
    {
        List<T> _list;

        public NotifyingList()
        {
            _list = new List<T>();
        }

        public void Add(T item)
        {
            if (item != null)
            {
                _list.Add(item);

                if (OnListOperation != null)
                {
                    OnListOperation.Invoke(this, new EventArgsOperationAndArg("Add", item.ToString()));
                }
            }
        }

        public void Remove(T item)
        {
            if (item != null && _list.Contains(item))
            {
                _list.Remove(item);

                if (OnListOperation != null)
                {
                    OnListOperation.Invoke(this, new EventArgsOperationAndArg("Remove", item.ToString()));
                }
            }
        }

        public event ListOperationEvent OnListOperation;
    }

    public delegate void ListOperationEvent(object o, EventArgsOperationAndArg e);

    public class EventArgsOperationAndArg : EventArgs
    {
        public EventArgsOperationAndArg(string op, string arg)
        {
            Operation = op;
            Arg = arg;
        }

        public string Operation { get; }
        public string Arg { get; }
    }
}
