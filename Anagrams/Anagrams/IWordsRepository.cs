using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    interface IWordsRepository
    {
        List<string> ProduceAnagrams(string word);
        bool IsAnagram(string word);
        string RandomWord();
    }
}
