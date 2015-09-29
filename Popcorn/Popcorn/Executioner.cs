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
            int score = PlayGame(0);
            //Print score
            bool replyForRetry = true;
            //Ask for a retry
            if (replyForRetry == true)
            {
                NewGame();
            }
            else
            {
                DrawMenu();
            }
        }

        private static int PlayGame(int level)
        {
            //The method returns the score
            int[,] matrix = LoadLevel(level);
            int score = 0;
            bool clearedAllBricks = false;
            while (true)
            {
                //The main loop of the game
                break;
            }
            if (clearedAllBricks)
            {
                score += PlayGame(level + 1);
            }
            return score;
        }

        private static int[,] LoadLevel(int level)
        {
            switch (level)
            {
                    //Each case is a single level with bricks in a matrix
                case 1:
                    break;
                //Implement the levels in each case (matrix)
            }
            //Return the matrix with the bicks
            return new int[1, 1];
        }

        private static string GetUserName()
        {
            //Ask the user for the user name and check if it is valid
            throw new NotImplementedException();
        }
    }
}
