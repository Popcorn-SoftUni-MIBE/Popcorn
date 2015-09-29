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
            int counter = 1;

            ConsoleKeyInfo enter = new ConsoleKeyInfo();

            while (enter.Key != ConsoleKey.Enter)
            {
                if (enter.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                }
                else if (enter.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                }
                switch (counter)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "*NEW GAME  "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "HIGH SCORE "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "INSTRUCTIONS"));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "QUIT    ")); break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "NEW GAME  "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "*HIGH SCORE "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "INSTRUCTIONS"));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "QUIT    ")); break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "NEW GAME  "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "HIGH SCORE "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "*INSTRUCTIONS"));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "QUIT    ")); break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "NEW GAME  "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "HIGH SCORE "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "INSTRUCTIONS"));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "*QUIT    ")); break;
                    default:
                        counter = 1;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "*NEW GAME  "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "HIGH SCORE "));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "INSTRUCTIONS"));
                        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "QUIT    "));
                        break;
                }


                enter = Console.ReadKey();
                Console.Clear();

            }
            switch (counter)
            {
                case 1: NewGame(); break;
                case 2: GetHighScore(); break;
                case 3: DrawControls(); break;
                case 4: Quit(); break;
                default:
                    break;
            }
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

            int counter = 0;
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(String.Format(" {0," + Console.WindowWidth / (2) + "}", "HIGH SCORE  "));

            Console.WriteLine(String.Format("  {0," + Console.WindowWidth / 2 + "}", new string('-', 16)));
            foreach (var item in highScore.Reverse())
            {
                counter++;
                Console.Write(String.Format("{0," + Console.WindowWidth / 3 + "} | ", counter));
                Console.WriteLine(String.Format("{0} {1}", item.Key, item.Value));
                if (counter >= 10)
                {
                    break;
                }

            }
            ConsoleKeyInfo enter = Console.ReadKey();

            if (enter.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                DrawMenu();
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
