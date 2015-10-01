using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

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
            string userName = GetUserName();
            //string userName = "User";
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
            GameObject[,] matrixForGame = LoadLevel(level);
            int score = 0;
            bool clearedAllBricks = false;
            Ball ball = new Ball(matrixForGame.GetLength(0) - 1, matrixForGame.GetLength(1) / 2);
            ball.UpdateRow = -1;
            ball.UpdateCol = 1;
            int boardRow = matrixForGame.GetLength(0) - 1;
            int boardCol = matrixForGame.GetLength(1) / 2;
            Board board = new Board(boardRow, boardCol);
            while (true)
            {
                PrintFrame(ball, matrixForGame, board);
                Update(ball, matrixForGame, board);
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {

                    case ConsoleKey.LeftArrow:
                        if (board.Col - 1 > 1)
                        {
                            board.Col--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (board.Col + board.Size < matrixForGame.GetLength(1))
                        {
                            board.Col++;
                        }
                        break;

                }
                Console.Clear();
            }
            if (clearedAllBricks)
            {
                score += PlayGame(level + 1);
            }
            return score;

        }
        private static void Update(Ball ball, GameObject[,] matrixForGame, Board board)
        {
            ball.Col += ball.UpdateCol;
            ball.Row += ball.UpdateRow;

            if (ball.Col >= matrixForGame.GetLength(1) - 1 || ball.Col <= 1)
            {
                ball.UpdateCol *= (-1);
                ball.Col += ball.UpdateCol;
            }
            if (ball.Row <= 1)
            {
                ball.UpdateRow *= -1;
                ball.Row += ball.UpdateRow;
            }
            if (matrixForGame[ball.Row, ball.Col] is IDestructableObject)
            {
                //TO DO.. Implement Destroy
                (matrixForGame[ball.Row, ball.Col] as IDestructableObject).Destroy();
                ball.UpdateRow *= -1;
                ball.Row += ball.UpdateRow;
            }
            if (ball.Row == board.Row && (ball.Col >= board.Col && ball.Col <= board.Col + board.Size))
            {
                ball.UpdateRow *= -1;
                ball.Row += ball.UpdateRow;
            }
        }
        private static void PrintFrame(Ball ball, GameObject[,] matrixForGame, Board board)
        {
            int currBallRow = ball.Row;
            int currBallCol = ball.Col;
            int currBoardRow = board.Row;
            matrixForGame[currBallRow, currBallCol] = ball;
            for (int i = 0; i < board.Size; i++)
            {
                matrixForGame[board.Row, board.Col + i] = board;
            }
            for (int rows = 0; rows < matrixForGame.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrixForGame.GetLength(1); cols++)
                {
                    Console.Write(matrixForGame[rows, cols].GetCharOfObject());
                }
                Console.WriteLine();
            }
            for (int i = 0; i < board.Size; i++)
            {
                matrixForGame[board.Row, board.Col + i] = new EmptyBlock();
            }
            matrixForGame[ball.Row, ball.Col] = new EmptyBlock();

        }

        private static GameObject[,] LoadLevel(int level)
        {
            switch (level)
            {
                //Each case is a single level with bricks in a matrix
                case 1:
                    GameObject[,] matrix =
                    {
                    {new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    {new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    {new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    {new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    {new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },
                    { new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },
                    { new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },
                    { new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },
                    { new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },

                    };
                    return matrix;
                    //Implement the levels in each case (matrix)
            }
            //Return the matrix with the bicks
            return new GameObject[0, 0];
        }

        private static string GetUserName()
        {
            //TO DO: If username is valid break while loop

            string enterNameText = "Please enter your username: ";
            string allowedCharsText = "Allowed characters: (A-Z a-z 0-9 _)";
            string enterAgainText = "Incorrect username, please enter again";
            string usernameIsAddedText = "Username is added";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (enterNameText.Length / 2)) + "}", enterNameText);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (allowedCharsText.Length / 2)) + "}", allowedCharsText);
            Console.WriteLine();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorLeft = Console.WindowWidth / 3;
                string username = Console.ReadLine();
                Regex regex = new Regex("^(?!.*[_].*[_])[A-Za-z0-9_]{3,26}$");

                if (regex.IsMatch(username))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (usernameIsAddedText.Length / 2)) + "}",
                        usernameIsAddedText);
                    Console.Clear();
                    return username;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (enterAgainText.Length / 2)) + "}",
                        enterAgainText);
                }
            }

        }
    }
}
