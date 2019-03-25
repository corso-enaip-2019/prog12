using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Loader
    {
        public List<string> FromMemory()
        {
            List<string> _list = new List<string>();

            _list.Add("casa");
            _list.Add("chiesa");
            _list.Add("scuola");

            return _list;
        }

        public List<string> FromFile()
        {
            string dictionaryPath = string.Concat(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Path.DirectorySeparatorChar,
         //       "Repositories",
                Path.DirectorySeparatorChar,
                "660000_parole_italiane.txt");

            try
            {
                return File.ReadAllLines(dictionaryPath).ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Error reading file { dictionaryPath }", e);
            }
        }
    }
}
