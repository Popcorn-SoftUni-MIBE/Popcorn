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
<<<<<<< HEAD

=======
            int counter = 1;
>>>>>>> 1b1e5f4ebf782168032a1924a07df35cc0debba4
            SortedDictionary<int, string> highScore = new SortedDictionary<int, string>();
            string line;
            StreamReader file = new StreamReader(@"../../HighScore.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] highScoreValues = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
<<<<<<< HEAD
                string name = highScoreValues[0];
                int score = int.Parse(highScoreValues[1]);
                highScore.Add(score, name);
                foreach (var item in highScore)
                {
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
=======
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
>>>>>>> 1b1e5f4ebf782168032a1924a07df35cc0debba4
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
