using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Anagrams
    {
//      WordsRepository repository = new WordsRepository(new Loader().FromMemory);
        WordsRepository repository = new WordsRepository(new Loader().FromFile);
        IUiHandler uiHandler = new UiHandler();
        List<GamePlay> gamePlayList = new List<GamePlay>();
     
        public void Run()
        {
            int menuOption;

            gamePlayList.Add(new Challenge("Anagram challenge", uiHandler));
            gamePlayList.Add(new Training("Anagram training", uiHandler));

            do
            {
                menuOption = GetMenuOption(gamePlayList, uiHandler);

                if (menuOption != 0)
                {
                    gamePlayList[menuOption - 1].Run(repository);
                }
            
            } while (menuOption != 0);
        }

        int GetMenuOption(List<GamePlay> gamePlayList, IUiHandler uiHandler)
        {
            int index = 1;

            uiHandler.WriteMessage($"Please choose what game you wish to play\n\r");

            foreach (GamePlay gamePlay in gamePlayList)
            {
                uiHandler.WriteMessage($"{index++} - {gamePlay.Description}");
            }

            uiHandler.WriteMessage($"\n\r0 - to exit...");

            return uiHandler.InsertInt(0, gamePlayList.Count());
        }

    }
}
