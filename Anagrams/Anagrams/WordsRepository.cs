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

        public WordsRepository(LoadRepository loader)
        {
            _repository = loader();
        }

        public List<string> ProduceAnagrams(string word)
        {
            List<string> _anagrams = new List<string>();

            foreach (string w in _repository)
            {
                if (IsAnagram(word, w))
                {
                    _anagrams.Add(w);
                }
            }

            return _anagrams;
        }

        public bool IsAnagram(string wordToAnagram, string tentativeAnagram)
        {
            bool result = true;

            if (result && wordToAnagram.Equals(tentativeAnagram))
            {
                result = false;
            }

            if (result && wordToAnagram.Length != tentativeAnagram.Length)
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

            if (result && !_repository.Contains(tentativeAnagram))
            {
                result = false;
            }

            return result;
        }

        public string RandomWord(int minAnagrams)
        {
            string randomWord;
            List<string> anagrams;

            do
            {
                randomWord = _repository[new Random().Next() % _repository.Count()];

                anagrams = ProduceAnagrams(randomWord);
            }
            while (anagrams.Count < minAnagrams);

            return randomWord;
        }

        void Permute(List<string> permutations, String str,
                              int l, int r)
        {
            if (l == r)
                permutations.Add(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(permutations, str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        public String Swap(String a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        public List<string> Permutations(string word)
        {
            List<string> result = new List<string>();
            Permute(result, word, 0, word.Length - 1);
            result.Remove(word);

            return result;
        }
    }


}
