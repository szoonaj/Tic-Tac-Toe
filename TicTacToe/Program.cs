using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        //private static char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        public static bool isAWinner = false, isADraw = false;
        public static char chosenField;
        public static int counter = 0;

        public static void DisplayBoard()
        {
            Console.WriteLine("    Tic Tac Toe - have fun! \n ------------------------------\n\n");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 2)
                        Console.Write("\t" + board[i, j]);

                    else
                        Console.Write("\t" + board[i, j] + "   |");
                }
                Console.WriteLine("\n\t-----------------");
            }
        }

        public static void ChooseAField()
        {
            bool result;
            result = char.TryParse(Console.ReadLine(), out chosenField);
            Console.WriteLine("\n");
        }
        
        public static void SetAField(int chosenField)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    char sign1 = 'X', sign2 = 'O';

                    if (board[i, j] == chosenField && counter % 2 == 0)
                        board[i, j] = sign1;
                    else if (board[i, j] == chosenField && counter % 2 == 1)
                        board[i, j] = sign2;
                }
            }
        }

        public static void ResetTheGame()
        {
            Console.Clear();
            board = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            isAWinner = false;
            isADraw = false;
            counter = 0;
            chosenField = '\0';
        }

        public static void CheckIfThereISAWinner()
        {
            if (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2] || board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] ||
                board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] || board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] ||
                board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] || board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] ||
                board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] || board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
            {
                isAWinner = true;
            }
        }

        public static void CheckIfThereIsADraw()
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 'X' || board[i, j] == 'O')
                        counter++;
                }
            }
            if (counter == 9 && isAWinner == false)
                isADraw = true;
        }

        static void Main(string[] args)
        {
            DisplayBoard();

            while (!isAWinner && !isADraw)
            //while (true)
            {
                if (counter % 2 == 0)
                    Console.Write("\nChoose a field you'd like to mark with X (Enter a number 1-9):  ");
                else
                    Console.Write("\nChoose a field you'd like to mark with O (Enter a number 1-9):  ");

                ChooseAField();
                bool error = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == chosenField)
                            error = false;
                    }
                }
                
                if (error == false)
                {
                    SetAField(chosenField);
                    CheckIfThereISAWinner();
                    CheckIfThereIsADraw();
                    Console.Clear();
                    DisplayBoard();

                    if (isAWinner == true)
                    {
                        if (counter % 2 == 0)
                            Console.WriteLine("Player X has won! Congratulations!");
                        else
                            Console.WriteLine("Player O has won! Congratulations!");

                        Console.WriteLine("Enter anything to restart the game or 'q' if you want to quit.");
                        string input = Console.ReadLine();
                        if (input == "q")
                            Environment.Exit(0);
                        else
                        {
                            ResetTheGame();
                            DisplayBoard();
                            continue;
                        }
                    }

                    if (isADraw == true)
                    {
                        Console.WriteLine("The game has finished with a draw.");
                        Console.WriteLine("Enter anything to restart the game or 'q' if you want to quit.");
                        string input = Console.ReadLine();
                        if (input == "q")
                            Environment.Exit(0);
                        else
                        {
                            ResetTheGame();
                            DisplayBoard();
                            continue;
                        }
                    }
                }

                else
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("An error occured. Please try again.");
                    continue;
                }

                counter++;
            }
        }
    }
}
