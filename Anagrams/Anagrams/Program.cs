using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
/*
            WordsRepository repository = new WordsRepository(new Loader().FromFile);

            DateTime start = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                repository.IsAnagram("lattoso", "salotto");
            }
            DateTime stop = DateTime.Now;
            Console.WriteLine((stop.Subtract(start)).TotalSeconds);

            Console.ReadKey();
*/
            (new Anagrams()).Run();
        }
    }
}
