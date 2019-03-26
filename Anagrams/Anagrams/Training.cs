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
            UiHandler.WriteMessage("");
            UiHandler.WriteMessage("Please type a word to anagram");
            word = UiHandler.InsertWord();
            anagrams = repository.ProduceAnagrams(word);
            if (anagrams.Count() > 0 )
            {
                foreach (string w in anagrams)
                {
                    UiHandler.WriteMessage(w);
                }
            }
            else
            {
                UiHandler.WriteMessage("Sorry, the chosen word seems not having anagrams...");
            }
        }
    }
}
