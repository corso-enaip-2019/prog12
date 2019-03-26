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

            return _anagrams;
        }

        public bool IsAnagram(string word)
        {
            bool result = false;
            
            if (word != null)
            {
                result = _repository.Contains(word);
            }

            return result;
        }

        public string RandomWord()
        {
            return _repository[new Random().Next() % _repository.Count()];
        }
    }


}
