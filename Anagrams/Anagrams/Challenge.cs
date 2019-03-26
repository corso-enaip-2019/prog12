using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Challenge : GamePlay
    {
        public override IUiHandler UiHandler { set; get; }
        public override string Description { set; get; }

        public Challenge(string description, IUiHandler uiHandler) : base(description, uiHandler)
        {
        }

        public override void Run(WordsRepository repository)
        {
            DateTime start, stop;
            string tentativeAnagram;
            string randomWord = repository.RandomWord();

            UiHandler.WriteMessage(Description);
            UiHandler.WriteMessage("");
            UiHandler.WriteMessage("Provide the anagram for the following word:");
            UiHandler.WriteMessage(randomWord);
            start = new DateTime().TimeOfDay();
            tentativeAnagram = UiHandler.InsertWord();
            stop = new DateTime().TimeOfDay();




        }

        bool IsValidAnagram(WordsRepository repository, string wordToAnagram, string tentativeAnagram)
        {
            bool result = true;

            if (result == true && wordToAnagram.Length != tentativeAnagram.Length)
            {
                result = false;
            }

            if (result == true)
            {
                char[] wtaArray = wordToAnagram.ToArray();
                char[] taArray = tentativeAnagram.ToArray();

                Array.Sort(wtaArray);
                Array.Sort(taArray);

                if 
            }

            return result;
        }

    }
}
