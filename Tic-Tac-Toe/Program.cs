using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void PrintBoard(char[,] board)
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

        static void GetPlayerMove(ref char[,] board, ref bool isPlayerXTurn)
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

        static bool CheckIfGameOver(ref char[,] board, ref bool didCatWin)
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

        static void ResetGame(ref char[,] board, ref bool isPlayerXTurn, ref bool gameOver, ref bool didCatWin)
        {
            board = new char[3,3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            isPlayerXTurn = true;
            gameOver = false;
            didCatWin = false;
        }

        static void DisplayResults(int numOfXWins, int numOfOWins, int numOfCatWins)
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
            bool isRunning = true, isPlayerXTurn = true, gameOver, didPlayerXWin, didCatWin = false;
            char[,] board = new char[3,3] { {' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            string userInput;
            int numOfXWins = 0, numOfOWins = 0, numOfCatWins = 0;

            Console.Title = "Tic-Tac-Toe";

            while (isRunning)
            {
                Console.Clear();

                PrintBoard(board);

                GetPlayerMove(ref board, ref isPlayerXTurn);

                gameOver = CheckIfGameOver(ref board, ref didCatWin);

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
                            ResetGame(ref board, ref isPlayerXTurn, ref gameOver, ref didCatWin);
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
