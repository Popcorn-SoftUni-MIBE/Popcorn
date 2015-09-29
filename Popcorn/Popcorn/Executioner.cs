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
            //   NewGame();
            GetHighScore();
            //    DrawControls();
            //  Quit();
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
            int counter = 1;
            SortedDictionary<int, string> highScore = new SortedDictionary<int, string>();
            string line;
            StreamReader file = new StreamReader(@"../../HighScore.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] highScoreValues = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = highScoreValues[1];
                int score = int.Parse(highScoreValues[0]);
                highScore.Add(score, name);

            }
            Console.WriteLine("{0}HIGH SCORE",new string(' ',5));
            Console.WriteLine("   {0}", new string('-', 15));

            foreach (var item in highScore.Reverse())
            {
                Console.Write(" {0} |", counter);
                Console.WriteLine("{0} {1}", item.Key, item.Value);
                counter++;
                if (counter >= 11)
                {
                    break;
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
