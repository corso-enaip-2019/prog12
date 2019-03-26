using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    public static class Permutations
    {
        // Prints all distinct permutations  
        // in word[0..n-1]  
        public static void GetAll(List<string> permutations, char[] word, int index, int n)
        {
            if (index >= n)
            {
                permutations.Add(new string(word));
                return;
            }

            for (int i = index; i < n; i++)
            {

                // Proceed further for word[i] only  
                // if it doesn't match with any of  
                // the characters after wor[index]  
                if (ShouldSwap(word, index, i))
                {
                    Swap(word, index, i);
                    GetAll(permutations, word, index + 1, n);
                    Swap(word, index, i);
                }
            }
        }

        // Returns true if word[curr] does  
        // not matches with any of the  
        // characters after word[start]  
        static bool ShouldSwap(char[] word, int start, int curr)
        {
            for (int i = start; i < curr; i++)
            {
                if (word[i] == word[curr])
                {
                    return false;
                }
            }
            return true;
        }

        static void Swap(char[] word, int i, int j)
        {
            char c = word[i];
            word[i] = word[j];
            word[j] = c;
        }
    }
}
