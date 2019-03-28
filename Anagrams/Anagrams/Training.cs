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

        public override void Run(WordsRepository repository)
        {
            string word;
            List<string> anagrams;
            UiHandler.WriteMessage(Description);
            UiHandler.WriteMessage();
            UiHandler.WriteMessage("Please type a word to anagram");

            word = UiHandler.InsertWord();

            anagrams = repository.ProduceAnagrams(word);

            if (anagrams.Count() > 0)
            {
                if (anagrams.Count() == 1)
                {
                    UiHandler.WriteMessage("The provided word does not have any anagram...");
                }
                else
                {
                    foreach (string w in anagrams)
                    {
                        if (!word.Equals(w)) { 
                            UiHandler.WriteMessage(w);
                        }
                    }
                }
            }
            else
            {
                UiHandler.WriteMessage("Sorry, the chosen word does not exist in the word repository...");
            }

            UiHandler.WriteMessage();
            UiHandler.WriteMessage();
        }
    }
}
