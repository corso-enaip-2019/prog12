using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    public delegate List<string> LoadRepository();

    public class WordsRepository : IWordsRepository
    {
        List<string> _repository;
        Dictionary<string, int> _disassembledAnagram;

        public WordsRepository(LoadRepository loader)
        {
            _repository = loader();
            _disassembledAnagram = new Dictionary<string, int>();

            foreach (string word in _repository)
            {
                _disassembledAnagram[DisassembleWord(word)]++;
            }
        }

        public string DisassembleWord(string word)
        {
            char[] wordToArray = word.ToArray();

            Array.Sort(wordToArray);

            return wordToArray.ToString();
        }

        public List<string> ProduceAnagrams(string word)
        {
            List<string> anagrams = new List<string>();
            List<string> permutations = new List<string>();

            Permutations.GetAll(permutations, word.ToArray(), 0, word.Length);

            foreach (string p in permutations)
            {
                if (IsAnagram(word, p))
                {
                    anagrams.Add(p);
                }
            }

            return anagrams;
        }

        public bool IsAnagram(string wordToAnagram, string tentativeAnagram)
        {
            bool result = true;

            if (result && wordToAnagram.Length != tentativeAnagram.Length)
            {
                result = false;
            }

            if (result && wordToAnagram.Equals(tentativeAnagram))
            {
                result = false;
            }

            if (result)
            {
                char[] wtaArray = wordToAnagram.ToArray();
                char[] taArray = tentativeAnagram.ToArray();

                Array.Sort(wtaArray);
                Array.Sort(taArray);

                if (!wtaArray.ToString().Equals(taArray.ToString()))
                {
                    result = false;
                }
            }

            if (result && _repository.BinarySearch(tentativeAnagram) < 0)
//            if (result && !_repository.Contains(tentativeAnagram))
            {
                result = false;
            }

            return result;
        }

        public string RandomWord(int minAnagrams)
        {
            string randomWord;

            do
            {
                randomWord = _repository[new Random().Next() % _repository.Count()];
            }
            while (_disassembledAnagram[DisassembleWord(randomWord)] <= minAnagrams);

            return randomWord;
        }
    }
}
