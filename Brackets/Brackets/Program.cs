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
            string text = @"({
[({})]
)})";
            int errorLine;
            int errorColumn;
            int index;

            if (CheckBrackets(text, out index, out errorLine, out errorColumn))
            {
                Console.WriteLine("Brackets Ok");
            }
            else
            {
                Console.WriteLine($"Brackets NOT Ok index: {index} errorLine: {errorLine} errorColumn: {errorColumn}");
            }

            Console.ReadLine();
        }

        static bool IsNewerrorLine(char c)
        {
            return c == '\n';
        }

        /// <summary>
        /// Check if the text provided contains a coherent number of open/close parentesys "(", "[", "{".
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool CheckBrackets(string text, out int index, out int errorLine, out int errorColumn)
        {
            Stack<char> stack = new Stack<char>();
            char[] OpeningBracket = {'(', '[', '{'};
            char[] ClosingBracket = {')', ']', '}'};

            errorLine = 1;
            errorColumn = 0;

            for (index = 0; index < text.Length; index++)
            {
                int closeIndex = 0;
                char charAt = text[index];

                errorColumn++;

                if (IsNewerrorLine(charAt))
                {
                    errorColumn = 1;
                    errorLine++;
                }

                if (Array.IndexOf(OpeningBracket, charAt) >= 0) {

                    stack.Push(charAt);
                }
                else if ((closeIndex = Array.IndexOf(ClosingBracket, charAt)) >= 0)
                {
                    if (stack.Count > 0)
                    {
                        char charInStack = stack.Pop();

                        if (closeIndex !=
                            Array.IndexOf(OpeningBracket, charInStack))
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
    }
}
