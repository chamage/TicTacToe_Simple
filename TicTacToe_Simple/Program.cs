using System;

class TicTacToe
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char player = 'X';
    static char computer = 'O';

    static void Main()
    {
        int moves = 0;
        bool playerTurn = true;

        while (true)
        {
            Console.Clear();
            DisplayBoard();

            if (CheckWin(player))
            {
                Console.WriteLine("Player wins!");
                break;
            }
            else if (CheckWin(computer))
            {
                Console.WriteLine("Computer wins!");
                break;
            }
            else if (moves == 9)
            {
                Console.WriteLine("It's a draw!");
                break;
            }

            if (playerTurn)
            {
                Console.Write("Enter your move (1-9): ");
                int move = int.Parse(Console.ReadLine()) - 1;
                int row = move / 3;
                int col = move % 3;

                if (board[row, col] != 'X' && board[row, col] != 'O')
                {
                    board[row, col] = player;
                    playerTurn = false;
                    moves++;
                }
                else
                {
                    Console.WriteLine("Invalid move! Try again.");
                }
            }
            else
            {
                ComputerMove();
                playerTurn = true;
                moves++;
            }
        }

        Console.ReadLine();
    }

    static void DisplayBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void ComputerMove()
    {
        Random rand = new Random();
        int move;
        int row, col;

        do
        {
            move = rand.Next(9);
            row = move / 3;
            col = move % 3;
        } while (board[row, col] == 'X' || board[row, col] == 'O');

        board[row, col] = computer;
    }

    static bool CheckWin(char c)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == c && board[i, 1] == c && board[i, 2] == c)
                return true;
        }

        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == c && board[1, i] == c && board[2, i] == c)
                return true;
        }

        if (board[0, 0] == c && board[1, 1] == c && board[2, 2] == c)
            return true;
        if (board[0, 2] == c && board[1, 1] == c && board[2, 0] == c)
            return true;

        return false;
    }
}
