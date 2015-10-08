using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Popcorn
{
    class Executioner
    {
        static int lives = 1;
        static GameObject[,] matrixForGame;
        static int score = 0;
        static string user;
        static void Main()
        {
            Console.CursorVisible = false;
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
                
                GameTitle();
                string instructionsText = "INSTRUCTIONS";
                string newGame = "NEW GAME";
                string highScore = "HIGH SCORE";
                string quit = "QUIT";
                switch (counter)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", "-> " + newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", "-> " + highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", "-> " + instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", newGame);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", "-> " + quit); break;
                    default:
                        if (counter==5)
                        {
                            counter = 1;
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}", "-> " + newGame);
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit); 
                        }
                        else if (counter==0)
                        {
                            counter = 4;
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (newGame.Length / 2)) + "}",  newGame);
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (highScore.Length / 2)) + "}", highScore);
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instructionsText.Length / 2)) + "}", instructionsText);
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", "-> " + quit);
                        }
                        {
                            
                        }
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
            }
        }
        private static void NewGame()
        {
            user = GetUserName();
            //TODO: Write a method to print the current score and after pressing enter, to clear
            PlayGame(1);
        }
        private static string GetUserName()
        {
            GameTitle();
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
                string username = Console.ReadLine().ToLower();
                if (username == "menu")
                {
                    Console.Clear();
                    Main();
                }
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
        private static void PlayGame(int level)
        {
            //The method returns the score
            matrixForGame = LoadLevel(level);
            bool clearedAllBricks = false;
            Ball ball = new Ball(matrixForGame.GetLength(0) - 1, matrixForGame.GetLength(1) / 2);
            int boardRow = matrixForGame.GetLength(0) - 1;
            int boardCol = matrixForGame.GetLength(1) / 2;
            Board board = new Board(boardRow, boardCol);
            while (true)
            {
                if (lives < 1)
                {
                    //Read all the users 
                    List<User> users = new List<User>();
                    users.Add(new User(name, score));
                    using (StreamReader scoreReader = new StreamReader(@"..\..\HighScore.txt"))
                    {
                        string lineRead = scoreReader.ReadLine();
                        while (!string.IsNullOrEmpty(lineRead))
                        {
                            users.Add(User.ParseUser(lineRead));
                        }
                    }
                    //Write the current user
                    using (StreamWriter sr = new StreamWriter(@"..\..\HighScore.txt"))
                    {
                        foreach (var userToWrite in users)
                        {
                            sr.WriteLine(userToWrite.ToString());
                        }
                    }

                    lives = 3;
                    score = 0;
                    AskRetry();
                }
                Console.Clear();
                PrintFrame(ball, board);
                Update(ball, board);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {

                        case ConsoleKey.LeftArrow:
                            if (board.Col >= 2)
                            {
                                board.Col--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (board.Col + board.Size < matrixForGame.GetLength(1) - 1)
                            {
                                board.Col++;
                            }
                            break;

                        case ConsoleKey.P:
                            {
                                while (true)
                                {
                                    ConsoleKeyInfo isPause = Console.ReadKey(true);
                                    if (isPause.Key == ConsoleKey.P)
                                    {
                                        break;
                                    }
                                    else
                                        Console.ReadKey(true);
                                }
                            }
                            break;
                    }
                }
                Thread.Sleep(150);
            }

            
            if (clearedAllBricks)
            {
                PlayGame(level + 1);
            }

        }
        private static GameObject[,] LoadLevel(int level)
        {
            switch (level)
            {
                //Each case is a single level with bricks in a matrix
                case 1:
                    GameObject[,] matrix =
                    {{ new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling(), new Ceiling()},
                        { new Wall(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new EmptyBlock(), new Wall()},
                    {new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    {new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    //{new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    {new Wall(), new Brick(), new Brick(), new SpecialBonusBrick(), new Brick(), new SpecialBonusBrick(), new Brick(), new Brick(), new Brick(), new Brick(), new Brick(), new Wall()},
                    {new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },
                    { new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },
                    { new Wall(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new EmptyBlock(),new Wall() },
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
        private static void GameTitle()
        {
            string titleOfTheGame = @"           ______  ______  ______  ______  ______  ______    __      _  
          |  __  ||  __  ||  __  ||  ____||  __  ||  __  \  |  \    | |
          | |__| || |  | || |__| || |     | |  | || |__| |  | ^ \   | |
          |  ____|| |  | ||  ____|| |     | |  | ||  _  _/  | |\ \  | |
          | |     | |  | || |     | |     | |  | || | \ \   | | \ \ | |
          | |     | |  | || |     | |     | |  | || |  \ \  | |  \ \| |
          | |     | |__| || |     | |____ | |__| || |   \ \ | |   \ V |
          |_|     |______||_|     |______||______||_|    \_\|_|    \__|";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (titleOfTheGame.Length / 2)) + "}", titleOfTheGame);
            Console.WriteLine();
            Console.WriteLine();

        }
        private static void DrawControls()
        {
            
            GameTitle();
            string instrStr = "Instructions:";
            string leftArrowKey = @"Left Arrow Key""<-"": Move pad to the left.";
            string rightArrowKey = @"Right Arrow Key""->"": Move pad to the right.";
            string pauseKey = @"Button ""P"": Pause the game.";
            string quitKey = "Ctrl+C: Quit the game.";
            string continueKey = @"Press ""Enter"" to return to main menu.";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (instrStr.Length / 2)) + "}", instrStr);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (leftArrowKey.Length / 2)) + "}", leftArrowKey);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (rightArrowKey.Length / 2)) + "}", rightArrowKey);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (pauseKey.Length / 2)) + "}", pauseKey);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quitKey.Length / 2)) + "}", quitKey);
            Console.WriteLine();
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (continueKey.Length / 2)) + "}", continueKey);

            ConsoleKeyInfo enter = Console.ReadKey();

            if (enter.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                DrawMenu();
            }
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
            GameTitle();
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
        private static void AskRetry()
        {
            GameTitle();
            string retryQ = "Do you want to retry? Y/N";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (retryQ.Length / 2)) + "}", retryQ);
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                {
                    lives = 3;
                    score = 0;
                    Console.Clear();
                    NewGame();
                    break;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    DrawMenu();
                }
                else
                {
                    Console.Clear();
                    GameTitle();
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (retryQ.Length / 2)) + "}", retryQ);
                }
            }
        }
        private static void Update(Ball ball, Board board)
        {
            ball.Col += ball.UpdateCol;
            ball.Row += ball.UpdateRow;

            //Colliding with left or right wall 
            #region
            if (ball.Col >= matrixForGame.GetLength(1) - 1 || ball.Col <= 0)
            {
                ball.UpdateCol *= (-1);
                ball.Col += ball.UpdateCol;
                
            }
            #endregion
            //Colliding with ceiling 
            #region
            if (ball.Row < 1)
            {
                ball.UpdateRow *= -1;
                ball.Row += ball.UpdateRow;
                
            }
            #endregion
            //Colliding with bricks 
            #region
            if (matrixForGame[ball.Row, ball.Col].IsDestroyable)
            {
                //TO DO.. Implement Destroy
                if (matrixForGame[ball.Row, ball.Col] is Brick)
                {
                    Console.Beep(3000,200);
                    score += 5;
                }
                if (matrixForGame[ball.Row, ball.Col] is SpecialBonusBrick)
                {
                    Console.Beep(3000, 300);
                    score += 10;
                }
                matrixForGame[ball.Row, ball.Col] = new EmptyBlock();
                ball.UpdateRow *= -1;
                ball.Row += ball.UpdateRow;
                return;
            }
            #endregion
            //Colliding with board
            #region
            if (ball.Row >= board.Row && (ball.Col >= board.Col && ball.Col <= board.Col + board.Size))
            {
                ball.UpdateRow *= -1;
                ball.Row += ball.UpdateRow;
                
            }
            #endregion
            if (ball.Row >= matrixForGame.GetLength(0) - 1)
            {
                lives--;
                Console.Beep(658, 1250); 

                ball.Row = matrixForGame.GetLength(0) - 1;
                ball.Col = matrixForGame.GetLength(1) / 2;
                ball.UpdateRow = -1;
                ball.UpdateCol = -1;
                board.Col = matrixForGame.GetLength(1) / 2 - board.Size / 2;
                Console.Clear();
                Thread.Sleep(1000);
            }
            
        }
        private static void PrintFrame(Ball ball, Board board)
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
                    Console.Write(" {0} ", matrixForGame[rows, cols].GetCharOfObject());
                }
                Console.WriteLine();
            }
            Console.WriteLine("Score: {0}", score);
            Console.WriteLine("Lives: {0}", lives);
            for (int i = 0; i < board.Size; i++)
            {
                matrixForGame[board.Row, board.Col + i] = new EmptyBlock();
            }
            matrixForGame[ball.Row, ball.Col] = new EmptyBlock();

        }

        private static void Quit()
        {

            string quitQuestionStr = "Are you sure you want to quit? Y/N?";
            GameTitle();
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
    }
}
