using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    public class UiHandler : IUiHandler
    {

        public int InsertInt(int min, int max)
        {
            int result;
            bool isValid;

            do
            {
                string input = InsertGeneric();

                isValid = int.TryParse(input, out result) ? result >= min && result <= max: false;

                if (!isValid)
                {
                    WriteMessage("The inserted value is not a valid menu option!\n\rPlease try again...");
                }
            } while (!isValid);

            return result;
        }

        public string InsertWord()
        {
            string result;
            bool isValid;

            do
            {
                result = InsertGeneric();

                isValid = IsValidWord(result);

                if (!isValid)
                {
                    WriteMessage("The inserted value is not a valid word!\n\rPlease try again...");
                }
            } while (!isValid);

            return result;
        }

        public string InsertGeneric()
        {
            string result;
            bool isValid;

            do
            {
                result = Console.ReadLine().Trim().ToLower();

                isValid = result.Equals("") ? false : true;

                if (!isValid)
                {
                    WriteMessage("The input should be not empty!\n\rPlease try again...");
                }
            } while (!isValid);

            return result;
        }

        bool IsValidWord(string word)
        {
            bool result = true;

            foreach (char c in word)
            {
                if (!Char.IsLetter(c))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteMessage()
        {
            WriteMessage("");
        }
    }
}
