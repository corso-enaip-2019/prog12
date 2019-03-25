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
        void WriteMessage(string message);
    }
}
