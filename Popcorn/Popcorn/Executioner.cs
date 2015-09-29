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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(String.Format(" {0," + Console.WindowWidth / (2) + "}", "HIGH SCORE  "));

            Console.WriteLine(String.Format("  {0," + Console.WindowWidth / 2 + "}", new string('-', 16)));

            foreach (var item in highScore.Reverse())
            {
                Console.Write(String.Format("{0," + Console.WindowWidth / 3 + "} | ", counter));
                Console.WriteLine(String.Format("{0} {1}", item.Key, item.Value));
                counter++;
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
        }

        private static string GetUserName()
        {
            throw new NotImplementedException();
        }
    }
}
