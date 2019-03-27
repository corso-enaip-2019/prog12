using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    public interface IUiHandler
    {
        string InsertWord();
        int InsertInt(int min, int max);
        void WriteMessage(string message);
        void WriteMessage();
    }
}
