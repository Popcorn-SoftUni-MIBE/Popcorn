using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    class Executioner
    {
        static void Main()
        {
            DrawMenu();
        }

        private static void DrawMenu()
        {
            NewGame();
            GetHighScore();
            DrawControls();
            Quit();
        }

        private static void Quit()
        {
            throw new NotImplementedException();
        }

        private static void DrawControls()
        {
            throw new NotImplementedException();
        }

        private static void GetHighScore()
        {
            throw new NotImplementedException();
        }

        private static void NewGame()
        {
            string userName = GetUserName();
        }

        private static string GetUserName()
        {
            throw new NotImplementedException();
        }
    }
}
