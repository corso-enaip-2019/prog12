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
            string text = @"({(
[({}
)](
))
)";
            int line;
            int index;

            if (CheckBrackets(text, out index, out line))
            {
                Console.WriteLine("Brackets Ok");
            }
            else
            {
                Console.WriteLine($"Brackets NOT Ok index: {index} line: {line}");
            }

            Console.ReadLine();
        }

        static bool IsNewline(char c)
        {
            return c == '\n';
        }

        /// <summary>
        /// Check if the text provided contains a coherent number of open/close parentesys "(", "[", "{".
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool CheckBrackets(string text, out int index, out int line)
        {
            Stack<char> stack = new Stack<char>();
            char[] pOpen = {'(', '[', '{'};
            char[] pClose ={')', ']', '}'};
            line = 0;

            for (index = 0; index < text.Length; index++)
            {
                int closeIndex = 0;
                char charAt = text[index];
                
                if (IsNewline(charAt))
                {
                    line++;
                }

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

        //static char GetCorrespondingOpenBracket(char bracket)
        //{


        //}
    }
}
