using System;

namespace LL
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Add("Marco");

            Console.WriteLine(ll.Get(-5));

            Console.Read();
        }
    }
    public class LinkedList<T>
    {
        public LinkedList()
        {
            _count = 0;
            head = null;
        }

        class Node
        {
            public Node(T item)
            {
                Item = item;
                Next = null;
            }
            public T Item { get; set; }
            public Node Next { get; set; }
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            Node n = head;

            for (int i = 0; i < index; i++)
            {
                n = n.Next;
            }
            return n.Item;
        }

        public void Add(T item)
        {
            Node node = new Node(item);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node n = head;

                while (n.Next != null)
                {
                    n = n.Next;
                }

                n.Next = node;

            }
            _count++;
        }

        public void Insert(T item, int index)
        {
            if (index < 0 || index > _count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == _count)
                Add(item);
            else
            {
                Node n = head;
                Node node = new Node(item);

                if (index == 0)
                {
                    node.Next = head;
                    head = node;
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        n = n.Next;
                    }

                    node.Next = n.Next;
                    n.Next = node;
                }
                _count++;
            }
        }

        public void Remove(T item)
        {
            Node np;
            Node n = head;
            if (object.Equals(n.Item, item))
            {
                head = n.Next;
                _count--;
            }

            else
            {
                for (int i = 1; i < _count; i++)
                {

                    np = n;
                    n = n.Next;
                    
                    if (object.Equals(n.Item, item))
                    {

                    }
                    
                }
            }

        }

        int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        Node head;
    }
}