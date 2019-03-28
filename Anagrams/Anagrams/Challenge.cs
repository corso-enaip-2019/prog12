using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Challenge : GamePlay
    {
        const int MIN_NUMBER_OF_ANAGRAMS = 10; // THE MAX NUMBER OF ANAGRAMS IN THE PROVIDED WORD DICTIONARY IS 23!
        public override IUiHandler UiHandler { set; get; }
        public override string Description { set; get; }

        public Challenge(string description, IUiHandler uiHandler) : base(description, uiHandler)
        {
        }

        public override void Run(WordsRepository repository)
        {
            int points;
            DateTime start, stop;
            string tentativeAnagram;
            string randomWord = repository.RandomWord(MIN_NUMBER_OF_ANAGRAMS);

            UiHandler.WriteMessage(Description);
            UiHandler.WriteMessage();
            UiHandler.WriteMessage("Provide the anagram for the following word:");

            UiHandler.WriteMessage(randomWord);

            start = DateTime.Now;

            tentativeAnagram = UiHandler.InsertWord();

            stop = DateTime.Now;

            if (repository.IsAnagram(randomWord, tentativeAnagram))
            {
                points = ComputePoints(start, stop);

                UiHandler.WriteMessage($"You anagrammed the word '{randomWord}' with '{tentativeAnagram}' scoring {points} poits.");
            }
            else
            {
                UiHandler.WriteMessage($"The provided word '{tentativeAnagram}' is not a valid anagram of '{tentativeAnagram}', so you scored 0 points.");
            }

            UiHandler.WriteMessage();
        }


        int ComputePoints(DateTime start, DateTime stop)
        {
            int result = 0;
            double seconds = (stop.Subtract(start)).TotalSeconds;
            Dictionary<double, int> scoringTable = new Dictionary<double, int>
            {
                {5.0, 10},
                {6.0, 6},
                {7.0, 4},
                {8.0, 2},
                {9.0, 1},
            };

            foreach (double t in scoringTable.Keys)
            {
                if (seconds < t)
                {
                    result = scoringTable[t];
                    break;
                }
            }

            return result;
        }

    }
}
