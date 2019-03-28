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
            string word = repository.RandomWord(22);
            List<string> anagrams = repository.ProduceAnagrams(word);

            Console.WriteLine(word);
            Console.WriteLine();

            foreach (string s in anagrams)
            {
                Console.WriteLine(s);

            }
            Console.ReadKey();
*/
            (new Anagrams()).Run();
        }
    }
}
