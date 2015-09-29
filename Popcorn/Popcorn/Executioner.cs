using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            SortedDictionary<int, string> highScore = new SortedDictionary<int, string>();
            string line;
            StreamReader file = new StreamReader(@"../../HighScore.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] highScoreValues = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = highScoreValues[0];
                int score = int.Parse(highScoreValues[1]);
                highScore.Add(score, name);
                foreach (var item in highScore)
                {
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
                }
            }
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
