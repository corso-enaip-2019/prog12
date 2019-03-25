using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Challenge : GamePlay
    {
        public override IUiHandler UiHandler { set; get; }
        public override string Description { set; get; }

        public Challenge(string description, IUiHandler uiHandler) : base(description, uiHandler)
        {
        }

        public override void Run()
        {

        }
    }
}
