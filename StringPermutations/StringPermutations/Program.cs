﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutations
{
    //https://www.geeksforgeeks.org/distinct-permutations-string-set-2/
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Type a word: ");
            string word = Console.ReadLine().Trim();

            Console.WriteLine("Permutations?: ");

            foreach (string permutation in Permutations(word))
            {
                Console.WriteLine(permutation);
            }

            Console.ReadKey();
        }

        void SortedPermutations(char[] word)
        {
            bool isFinished = false;
            int size = word.Count();
            Array.Sort(word);

            while (!isFinished)
            {
                int x = 1;

                Console.WriteLine($"{x++} {new string(word)}");

                int i;
                for (i = size - 2; i >= 0; --i)
                {
                    if (word[i] < word[i+1])
                    {
                        break;
                    }
                }

                if (i == -1)
                {
                    isFinished = true;
                }
                else
                {
                    int ceilIndex = FindCeil(word, word[i], i + 1, size - i - 1);

                    Swap(word[i], word[ceilIndex]);


                }
            }
        }

        int FindCeil(char[] word, char first, int l, int h)
        {
            int ceilIndex = 1;

            for (int i= l + 1; i <= h; i++)
            {
                if (word[i] > first && word [i] < word[ceilIndex])
                {
                    ceilIndex = i;
                }
            }

            return ceilIndex;
        }

        static void Swap(out char a, out char b)
        {
            char tmp;

            tmp = a;
            a = b;
            b = tmp;
        }
    }
}
