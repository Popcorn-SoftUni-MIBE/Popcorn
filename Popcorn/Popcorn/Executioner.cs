﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine();
                }
                string instructionsText = "INSTRUCTIONS";
                string newGame = "NEW GAME";
                string highScore = "HIGH SCORE";
                string quit = "QUIT";
                switch (counter)
                {
                    case 1:
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", "-> " + newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); break;
                    case 2:
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", "-> " + highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); break;
                    case 3:

                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", "-> " + instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); break;
                    case 4:

                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", "-> " + quit); break;
                    default:
                        counter = 1;
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", "-> " + newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); break;
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
            }
        }

        private static void Quit()
        {
            string quitQuestionStr = "Are you sure you want to quit? Y/N?";
            Console.Clear();
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quitQuestionStr.Length / 2)) + "}", quitQuestionStr);
            while (true)
            {
                ConsoleKeyInfo result = Console.ReadKey(true);
                if ((result.KeyChar == 'Y') || (result.KeyChar == 'y'))
                {
                    Process.GetCurrentProcess().Kill();
                }
                else if ((result.KeyChar == 'N') || (result.KeyChar == 'n'))
                {
                    Console.Clear();
                    DrawMenu();
                }
            }
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
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            string highScoreStr = "HIGH SCORE";
            string highScoreDelimiter = new string('-', 22);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScoreStr.Length / 2)) + "}", highScoreStr);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScoreDelimiter.Length / 2)) + "}", highScoreDelimiter);

            foreach (var item in highScore.Reverse())
            {
                counter++;
                Console.Write("{0," + Console.WindowWidth / 2.5 + "} | ", counter);
                Console.WriteLine("{0} {1}", item.Key, item.Value);
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
            //string userName = GetUserName();
            string userName = "User";
            int score = PlayGame(1);
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
            GameObject[,] matrixOfBricks = LoadLevel(level);
            GameObject[,] matrixForGame = new GameObject[20, 12];
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

        private static GameObject[,] LoadLevel(int level)
        {
            switch (level)
            {
                //Each case is a single level with bricks in a matrix
                case 1:
                    GameObject[,] matrix = 
                    {
                    {new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick()},
                    {new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick()},
                    {new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick()},
                    {new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick()}
                    };
                    return matrix;
                    break;
                    //Implement the levels in each case (matrix)
            }
            //Return the matrix with the bicks
            return new GameObject[0, 0];
        }

        private static string GetUserName()
        {
            //Ask the user for the user name and check if it is valid
            throw new NotImplementedException();
        }
    }
}
