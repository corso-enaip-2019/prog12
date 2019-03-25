using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    public class UiHandler : IUiHandler
    {
        public string InsertWord()
        {
            string result;

            do
            {
                result = Console.ReadLine().Trim();

                if (!IsValid(result))
                {
                    WriteMessage("The inserted string is not valid!\n\rPlease try again");
                }
            } while (!IsValid(result));

            return result;
        }

        bool IsValid(string word)
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
    }
}
