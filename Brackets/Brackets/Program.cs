using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "({([({})]())})";

            if (CheckBrackets(text))
            {
                Console.WriteLine("Brackets Ok");
            }
            else
            {
                Console.WriteLine("Brackets NOT Ok");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Check if the text provided contains a coherent number of open/close parentesys "(", "[", "{".
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool CheckBrackets(string text)
        {
            Stack<char> stack = new Stack<char>();
            char[] pOpen = {'(', '[', '{'};
            char[] pClose ={')', ']', '}'};

            for (int index = 0; index < text.Length; index++)
            {
                int closeIndex = 0;
                char charAt = text[index];

                if (Array.IndexOf(pOpen, charAt) >= 0) {

                    stack.Push(charAt);
                }
                else if ((closeIndex = Array.IndexOf(pClose, charAt)) >= 0)
                {
                    if (stack.Count > 0)
                    {
                        char charInStack = stack.Pop();

                        if (closeIndex !=
                            Array.IndexOf(pOpen, charInStack))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        static char GetCorrespondingOpenBracket(char bracket)
        {


        }
    }
}
