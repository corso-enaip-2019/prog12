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
        Dictionary<int, List<string>> _numberOfAnagramsToAnagramsList;
        Dictionary<string, List<string>> _disassembledWordToAnagramsList;

        public WordsRepository(LoadRepository loader)
        {
            _repository = loader();

            _numberOfAnagramsToAnagramsList = new Dictionary<int, List<string>>();
            _disassembledWordToAnagramsList = new Dictionary<string, List<string>>();

            foreach (string word in _repository)
            {
                string disassembledWord = DisassembleWord(word);

                if (!_disassembledWordToAnagramsList.ContainsKey(disassembledWord))
                {
                    _disassembledWordToAnagramsList[disassembledWord] = new List<string>();
                }

                _disassembledWordToAnagramsList[disassembledWord].Add(word);
            }

            foreach (string word in _repository)
            {
                string disassembledWord = DisassembleWord(word);

                int numberOfAnagrams = _disassembledWordToAnagramsList[disassembledWord].Count - 1;

                if (numberOfAnagrams > 0)
                {
                    if (!_numberOfAnagramsToAnagramsList.ContainsKey(numberOfAnagrams))
                    {
                        _numberOfAnagramsToAnagramsList[numberOfAnagrams] = new List<string>();
                    }

                    _numberOfAnagramsToAnagramsList[numberOfAnagrams].Add(word);
                }
            }
        }

        public List<string> ProduceAnagrams(string word)
        {
            List<string> result = null;
            string disassembledWord = DisassembleWord(word);

            if (_disassembledWordToAnagramsList.ContainsKey(disassembledWord))
            {
                result = _disassembledWordToAnagramsList[disassembledWord];
            }
            else
            {
                result = new List<string>();
            }

            return result;
        }
        public int GetRepositoryMaxNumberOfAnagrams()
        {
            return _numberOfAnagramsToAnagramsList.Keys.Max();
        }

        string DisassembleWord(string word)
        {
            char[] wordToArray = word.ToArray();

            Array.Sort(wordToArray);

            return new string(wordToArray);
        }

        public bool IsAnagram(string word, string tentativeAnagram)
        {
            bool result = false;

            if (!word.Equals(tentativeAnagram))
            {
                string disassembledWord = DisassembleWord(word);

                if (_disassembledWordToAnagramsList.ContainsKey(disassembledWord))
                {
                    if (_disassembledWordToAnagramsList[disassembledWord].Contains(tentativeAnagram))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public string RandomWord(int minAnagrams)
        {
            string result = null;
            int maxNumberOfAnagrams = GetRepositoryMaxNumberOfAnagrams();

            if (minAnagrams <= GetRepositoryMaxNumberOfAnagrams())
            {
                int randomAnagramNumber = minAnagrams + (new Random().Next()) % (maxNumberOfAnagrams - minAnagrams + 1);
                int randomWordIndex = new Random().Next() % _numberOfAnagramsToAnagramsList[randomAnagramNumber].Count();

                result = _numberOfAnagramsToAnagramsList[randomAnagramNumber][randomWordIndex];
            }

            return result;
        }
    }
}
