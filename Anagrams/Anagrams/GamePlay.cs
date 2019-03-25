using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    public abstract class GamePlay
    {
        public GamePlay(string description, IUiHandler uiHandler)
        {
            if (description != null && uiHandler != null)
            {
                Description = description;
                UiHandler = uiHandler;
            }
            else
            {
                throw new Exception("Invalid parameter");
            }
        }

        public virtual string Description { set; get; }
        public virtual IUiHandler UiHandler { set; get; }

        public abstract void Run();
    }
}
