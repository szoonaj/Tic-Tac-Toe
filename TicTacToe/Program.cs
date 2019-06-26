using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = new char[,] { { '1', '2', '3'}, { '4', '5', '6' }, { '7', '8', '9' } };
        static char chosenField;
        static bool isAWinner = false;
        static bool isADraw = false;
        static int counter = 0;


        public static void Refresh()
        {
            Console.WriteLine(" That's my first game in C# - Tic Tac Toe! Have fun! \n ---------------------------------------------------\n\n");
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
        /*
        public static void ChooseAField()
        {
            try
            {
                chosenField = char.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("You can enter only 1 sign!");
            }
            Console.WriteLine("\n");
        }
        */

        // better and more elegant way than above
        public static void ChooseAField()
        {
            bool result;
            result = char.TryParse(Console.ReadLine(), out chosenField);
            Console.WriteLine("\n");
        }

        public static void SetAFieldToX(int chosenField) 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    char sign = 'X';
                    if (board[i, j] == chosenField)
                        board[i, j] = sign;
                }
            }
        }
        public static void SetAFieldToO(int chosenField)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    char sign = 'O';
                    if (board[i, j] == chosenField)
                        board[i, j] = sign;
                }
            }
        }

        public static void ResetTheGame()
        {
            Console.Clear();
            board = new char [,] { { '1', '2', '3'}, { '4', '5', '6' }, { '7', '8', '9' } };
            isAWinner = false;
            isADraw = false;
            counter = 0;
        }

        public static void CheckIfThereISAWinner()
        {
            if(board[0,0] == board[0,1] && board[0,0] == board[0, 2] || board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] ||
                board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] || board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] ||
                board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] || board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] ||
                board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] || board[0, 2] == board[1, 1] && board[0, 0] == board[2, 0])
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
            START:
            Console.WriteLine(" That's my first game in C# - Tic Tac Toe! Have fun! \n ---------------------------------------------------\n\n");

            for (int i = 0; i<3; i++)
            {
                for(int j = 0; j<3; j++)
                {
                    if(j == 2)
                        Console.Write("\t" + board[i, j]);

                    else
                        Console.Write("\t" + board[i,j] + "   |" );
                }
                Console.WriteLine("\n\t-----------------");
            }

            while (!isAWinner && !isADraw)
            {
                
                if(counter%2 == 0)
                {
                    AGAIN:
                    Console.Write("\nChoose a field you'd like to mark with X (Enter a number 1-9):  ");
                    ChooseAField();
                    int error = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] != chosenField)
                                error++;
                        }
                    }
                    if (error != 9)
                    {
                        SetAFieldToX(chosenField);
                        CheckIfThereISAWinner();
                        CheckIfThereIsADraw();
                        Console.Clear();
                        Refresh();
                    }
                        
                    else
                    { 
                        Console.Clear();
                        Refresh();
                        Console.WriteLine("An error occured. Please try again.");
                        goto AGAIN;
                    }

                    if(isAWinner == true)
                    {
                        Console.WriteLine("Player X has won! Congratulations!");
                        Console.WriteLine("Enter anything to restart the game or 'q' if you want to quit.");
                        string input = Console.ReadLine();
                        if (input == "q")
                            Environment.Exit(0);
                        else
                        {
                            ResetTheGame();
                            goto START;
                        }
                        
                    }
                        
                    if(isADraw == true && isAWinner == false)
                    {
                        Console.WriteLine("The game has finished with a draw.");
                        Console.WriteLine("Enter anything to restart the game or 'q' if you want to quit.");
                        string input = Console.ReadLine();
                        if (input == "q")
                            Environment.Exit(0);
                        else
                        {
                            ResetTheGame();
                            goto START;
                        }
                    }
                }
                else
                {
                    AGAIN:
                    Console.Write("\nChoose a field you'd like to mark with O (Enter a number 1-9):  ");
                    ChooseAField();
                    int error = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] != chosenField)
                                error++;
                        }

                    }
                    if (error != 9)
                    {
                        SetAFieldToO(chosenField);
                        CheckIfThereISAWinner();
                        CheckIfThereIsADraw();
                        Console.Clear();
                        Refresh();
                    }

                    else
                    {
                        Console.Clear();
                        Refresh();
                        Console.WriteLine("An error occured. Please try again.");
                        goto AGAIN;
                    }
                    if (isAWinner == true)
                    {
                        Console.WriteLine("Player O has won! Congratulations!");
                        Console.WriteLine("Enter anything to restart the game or 'q' if you want to quit.");
                        string input = Console.ReadLine();
                        if (input == "q")
                            Environment.Exit(0);
                        else
                        {
                            ResetTheGame();
                            goto START;
                        }
                    }
                        
                    if (isADraw == true && isAWinner == false)
                    {
                        Console.WriteLine("The game has finished with a draw.");
                        Console.WriteLine("Enter anything to restart the game or 'q' if you want to quit.");
                        string input = Console.ReadLine();
                        if (input == "q")
                            Environment.Exit(0);
                        else
                        {
                            ResetTheGame();
                            goto START;
                        }
                    }                        
                }

                counter++;
            }

            Console.ReadLine();
        }
    }
}
