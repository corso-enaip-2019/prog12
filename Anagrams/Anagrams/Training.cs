using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Training : GamePlay
    {
        public override IUiHandler UiHandler { set; get; }
        public override string Description { set; get; }

        public Training(string description, IUiHandler uiHandler) : base(description, uiHandler)
        {
        }

        List<string> Permutations(string word)
        {
            char[] wordAsArray;
            List<string> result = new List<string>();

            for (int i = 0; i < word.Length - 1; i++)
            {
                for (int j = i + 1; j < word.Length; j++)
                {
                    wordAsArray = word.ToArray();

                    char t = wordAsArray[i];
                    wordAsArray[i] = wordAsArray[j];
                    wordAsArray[j] = t;

                    result.Add(new string(wordAsArray));
                }
            }

            return result;
        }


        public override void Run()
        {
            string word;
            List<string> permutations;

            UiHandler.WriteMessage(Description);
            UiHandler.WriteMessage("");
            UiHandler.WriteMessage("Please type a word to anagram");
            word = UiHandler.InsertWord();
            permutations = Permutations(word);

            foreach (string s in permutations)
            {
                UiHandler.WriteMessage(s);
            }

        }
    }
}
