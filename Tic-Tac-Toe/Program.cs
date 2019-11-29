using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        private static void PrintBoard(char[,] board)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |      ");
        }

        private static void GetPlayerMove(ref char[,] board, ref bool isPlayerXTurn)
        {
            bool validMove = false, validInput;
            int row = 0, column = 0;

            Console.WriteLine("It's " + ((isPlayerXTurn) ? " X's " : " O's ") + "Turn:");

            while (!validMove)
            {
                validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Enter the number of the row that you'd like to play on.");
                    validInput = int.TryParse(Console.ReadLine(), out row);
                    if (!validInput || row < 1 || row > 3)
                    {
                        Console.WriteLine("Please enter a valid integer between 1 and 3.");
                        validInput = false;
                    }
                }

                validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Enter the number of the column that you'd like to play on.");
                    validInput = int.TryParse(Console.ReadLine(), out column);
                    if (!validInput || column < 1 || column > 3)
                    {
                        Console.WriteLine("Please enter a valid integer between 1 and 3.");
                        validInput = false;
                    }
                }

                if (board[row - 1, column - 1] == 'X' || board[row - 1, column - 1] == 'O')
                {
                    Console.WriteLine("That space has already been played!");
                } else
                {
                    validMove = true;
                }
            }

            if (isPlayerXTurn)
            {
                board[row - 1, column - 1] = 'X';
                isPlayerXTurn = false;
            } else
            {
                board[row - 1, column - 1] = 'O';
                isPlayerXTurn = true;
            }
        }

        private static void GetAiMove(ref Random rand, ref object synlock, ref bool hardMode, ref char[,] board, ref bool isPlayerXTurn)
        {
            bool validMove = false;
            int row = 0, column = 0;

            if (hardMode == true)
            {
                //Checking Horizontal Blocks On First Row
                if (board[0, 0] == 'X' && board[0, 1] == 'X' && board[0, 2] == ' ')
                {
                    row = 0;
                    column = 2;
                    validMove = true;
                }
                else if (board[0, 0] == 'X' && board[0, 2] == 'X' && board[0, 1] == ' ')
                {
                    row = 0;
                    column = 1;
                    validMove = true;
                }
                else if (board[0, 1] == 'X' && board[0, 2] == 'X' && board[0, 0] == ' ')
                {
                    row = 0;
                    column = 0;
                    validMove = true;
                }

                //Checking Horizontal Blocks on Second Row
                if (board[1, 0] == 'X' && board[1, 1] == 'X' && board[1, 2] == ' ')
                {
                    row = 1;
                    column = 2;
                    validMove = true;
                }
                else if (board[1, 0] == 'X' && board[1, 2] == 'X' && board[1, 1] == ' ')
                {
                    row = 1;
                    column = 1;
                    validMove = true;
                }
                else if (board[1, 1] == 'X' && board[1, 2] == 'X' && board[1, 0] == ' ')
                {
                    row = 1;
                    column = 0;
                    validMove = true;
                }

                //Checking Horizontal Blocks On Third Row
                if (board[2, 0] == 'X' && board[2, 1] == 'X' && board[2, 2] == ' ')
                {
                    row = 2;
                    column = 2;
                    validMove = true;
                }
                else if (board[2, 0] == 'X' && board[2, 2] == 'X' && board[2, 1] == ' ')
                {
                    row = 2;
                    column = 1;
                    validMove = true;
                }
                else if (board[2, 1] == 'X' && board[2, 2] == 'X' && board[2, 0] == ' ')
                {
                    row = 2;
                    column = 0;
                    validMove = true;
                }

                //Checking Vertical Blocks on the First Column
                if (board[0, 0] == 'X' && board[1, 0] == 'X' && board[2, 0] == ' ')
                {
                    row = 2;
                    column = 0;
                    validMove = true;
                }
                else if (board[0, 0] == 'X' && board[2, 0] == 'X' && board[1, 0] == ' ')
                {
                    row = 1;
                    column = 0;
                    validMove = true;
                }
                else if (board[1, 0] == 'X' && board[2, 0] == 'X' && board[0, 0] == ' ')
                {
                    row = 0;
                    column = 0;
                    validMove = true;
                }

                //Checking Vertical Blocks on the Second Column
                if (board[0, 1] == 'X' && board[1, 1] == 'X' && board[2, 1] == ' ')
                {
                    row = 2;
                    column = 1;
                    validMove = true;
                }
                else if (board[0, 1] == 'X' && board[2, 1] == 'X' && board[1, 1] == ' ')
                {
                    row = 1;
                    column = 1;
                    validMove = true;
                }
                else if (board[1, 1] == 'X' && board[2, 1] == 'X' && board[0, 1] == ' ')
                {
                    row = 0;
                    column = 1;
                    validMove = true;
                }

                //Checking Vertical Blocks on the Third Column
                if (board[0, 2] == 'X' && board[1, 2] == 'X' && board[2, 2] == ' ')
                {
                    row = 2;
                    column = 2;
                    validMove = true;
                }
                else if (board[0, 2] == 'X' && board[2, 2] == 'X' && board[1, 2] == ' ')
                {
                    row = 2;
                    column = 1;
                    validMove = true;
                }
                else if (board[1, 2] == 'X' && board[2, 2] == 'X' && board[0, 2] == ' ')
                {
                    row = 0;
                    column = 2;
                    validMove = true;
                }

                //Checking Diagonal Blocks from top-left to bottom-right
                if (board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == ' ')
                {
                    row = 2;
                    column = 2;
                    validMove = true;
                }
                else if (board[0, 0] == 'X' && board[2, 2] == 'X' && board[1, 1] == ' ')
                {
                    row = 1;
                    column = 1;
                    validMove = true;
                }
                else if (board[1, 1] == 'X' && board[2, 2] == 'X' && board[0, 0] == ' ')
                {
                    row = 0;
                    column = 0;
                    validMove = true;
                }

                //Checking Diagonal Blocks from top-right to bottom-left
                if (board[0, 2] == 'X' && board[1, 1] == 'X' && board[2, 0] == ' ')
                {
                    row = 2;
                    column = 0;
                    validMove = true;
                }
                else if (board[0, 2] == 'X' && board[2, 0] == 'X' && board[1, 1] == ' ')
                {
                    row = 1;
                    column = 1;
                    validMove = true;
                }
                else if (board[1, 1] == 'X' && board[2, 0] == 'X' && board[0, 2] == ' ')
                {
                    row = 0;
                    column = 2;
                    validMove = true;
                }
            }

            //Debug AI Decision
            //Console.WriteLine(validMove);
            //Console.ReadKey();

            while (!validMove)
            {
                lock(synlock){
                    row = rand.Next(0, 3);
                    column = rand.Next(0, 3);
                }

                //Debug the computer's move
                //Console.WriteLine((row + 1) + " " + (column + 1));
                //Console.ReadKey();

                if (board[row, column] == 'X' || board[row, column] == 'O')
                {
                    continue;
                }
                else
                {
                    validMove = true;
                }
            }

            if (board[row, column] == ' ')
            {
                board[row, column] = 'O';
            } else
            {
                Console.WriteLine("ERROR");
                Console.ReadKey();
            }
            isPlayerXTurn = true;
        }

        private static bool CheckIfGameOver(ref char[,] board, ref bool didCatWin)
        {
            //Check Rows
            if (board[0,0] == board[0,1] && board[0,1] == board[0,2] && board[0,0] != ' ')
            {
                return true;
            } else if (board[1,0] == board[1,1] && board[1,1] == board[1,2] && board[1, 0] != ' ')
            {
                return true;
            } else if (board[2,0] == board[2,1] && board[2,1] == board[2,2] && board[2, 0] != ' ')
            {
                return true;
            }

            //Check Columns
            if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != ' ')
            {
                return true;
            }
            else if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[0, 1] != ' ')
            {
                return true;
            }
            else if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[0, 2] != ' ')
            {
                return true;
            }

            //Check Diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
            {
                return true;
            }
            else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
            {
                return true;
            }

            //Cat Won
            bool allSpacesFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ') {
                        allSpacesFull = false;
                        break;
                    }
                }

                if (!allSpacesFull) { break; };
            }

            if (allSpacesFull)
            {
                didCatWin = true;
                return true;
            }

            return false;
        }

        private static void ResetGame(ref char[,] board, ref bool isPlayerXTurn, ref bool gameOver, ref bool didCatWin, ref bool modeSelected, ref bool selectDifficulty)
        {
            board = new char[3,3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            isPlayerXTurn = true;
            gameOver = false;
            didCatWin = false;
            modeSelected = false;
            selectDifficulty = false;
        }

        private static void DisplayResults(int numOfXWins, int numOfOWins, int numOfCatWins)
        {
            Console.WriteLine("\nX's Won " + numOfXWins + " Games.");
            Console.WriteLine("O's Won " + numOfOWins + " Games.");
            Console.WriteLine("The Cat Won " + numOfCatWins + " Games");
            if (numOfCatWins > numOfXWins && numOfCatWins > numOfOWins)
            {
                Console.WriteLine(@" /\_/\
( o.o )
 > ^ <");
                Console.WriteLine("The Cat Won!!!");
            }
            else
            {
                if (numOfXWins > numOfOWins)
                {
                    Console.WriteLine(@" __   __
 \ \ / /
  \ V / 
   > <  
  / . \ 
 /_/ \_\");
                    Console.WriteLine("X's Win!!!");
                }
                else if (numOfOWins > numOfXWins)
                {
                    Console.WriteLine(@"   ____  
  / __ \ 
 | |  | |
 | |  | |
 | |__| |
  \____/ ");
                    Console.WriteLine("O's Win!!!");
                }
                else
                {
                    Console.WriteLine(@"  _____  _____       __          __
 |  __ \|  __ \     /\ \        / /
 | |  | | |__) |   /  \ \  /\  / / 
 | |  | |  _  /   / /\ \ \/  \/ /  
 | |__| | | \ \  / ____ \  /\  /   
 |_____/|_|  \_\/_/    \_\/  \/   ");
                    Console.WriteLine("It's a tie game!!!");
                }
            }
        }

        static void Main(string[] args)
        {
            bool isRunning = true, selectDifficulty = false, isPlayerXTurn = true, gameOver, didPlayerXWin, didCatWin = false, modeSelected = false, singlePlayer = false, hardMode = false;
            char[,] board = new char[3,3] { {' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            string userInput;
            int mode, numOfXWins = 0, numOfOWins = 0, numOfCatWins = 0;

            Random rand = new Random();
            object synlock = new object();

            Console.Title = "Tic-Tac-Toe";

            while (isRunning)
            {
                Console.Clear();

                while (!modeSelected)
                {
                    Console.WriteLine("Welcome to Tic-Tac-Toe!");
                    Console.Write("Please enter a '1' to play singleplayer, or a '2' to play multiplayer: ");
                    modeSelected = int.TryParse(Console.ReadLine(), out mode);

                    if (mode == 1)
                    {
                        singlePlayer = true;
                        Console.WriteLine("You have enabled singleplayer.");
                    } else if (mode == 2)
                    {
                        singlePlayer = false;
                        Console.WriteLine("You have selected multiplayer. \nPress any key to continue.");
                        Console.ReadKey();
                    } else
                    {
                        Console.WriteLine("Please enter a valid selection.");
                    }
                }

                if (singlePlayer == true)
                {
                    while (!selectDifficulty)
                    {
                        Console.WriteLine("Would you like to enable hard mode?");
                        Console.Write("Please enter a '1' to enable hard mode, or a '2' to play on easy: ");
                        selectDifficulty = int.TryParse(Console.ReadLine(), out mode);

                        if (mode == 1)
                        {
                            hardMode = true;
                            Console.WriteLine("You have enabled hard mode. \nPress any key to continue.");
                            Console.ReadKey();
                        }
                        else if (mode == 2)
                        {
                            hardMode = false;
                            Console.WriteLine("You have disabled hard mode. \nPress any key to continue.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid selection.");
                        }
                    }
                }

                Console.Clear();

                PrintBoard(board);

                GetPlayerMove(ref board, ref isPlayerXTurn);

                gameOver = CheckIfGameOver(ref board, ref didCatWin);

                if (singlePlayer && !gameOver)
                {
                    GetAiMove(ref rand, ref synlock, ref hardMode, ref board, ref isPlayerXTurn);

                    gameOver = CheckIfGameOver(ref board, ref didCatWin);
                }

                if (gameOver)
                {
                    Console.Clear();
                    PrintBoard(board);

                    Console.Beep();

                    if (!didCatWin)
                    {
                        //Comparison is backwards because turn is advanced in GetPlayerMove()
                        didPlayerXWin = isPlayerXTurn ? false : true;

                        Console.WriteLine(((didPlayerXWin) ? "X's " : "O's ") + " Win!!!");
                        _ = didPlayerXWin ? numOfXWins += 1 : numOfOWins += 1;
                    }  else
                    {
                        numOfCatWins += 1;

                        Console.WriteLine("The Cat Won!!!");
                    }

                    bool userConfirm = false;
                    while (!userConfirm)
                    {
                        Console.Write("Would you like to play again? (Y/N): ");
                        userInput = Console.ReadLine();

                        if (userInput == "y" || userInput == "Y")
                        {
                            ResetGame(ref board, ref isPlayerXTurn, ref gameOver, ref didCatWin, ref modeSelected, ref selectDifficulty);
                            userConfirm = true;
                        } else if (userInput == "n" || userInput == "N")
                        {
                            isRunning = false;
                            userConfirm = true;
                        } else
                        {
                            Console.WriteLine("Please enter a valid selection.");
                        }
                    }
                }
            }

            DisplayResults(numOfXWins, numOfOWins, numOfCatWins);
      
            Console.WriteLine("\nPress any key to close the program.");
            Console.ReadKey();
        }
    }
}
