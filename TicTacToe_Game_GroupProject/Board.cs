using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Board
    {
        private string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public string[] BoardState => board;

        public bool IsValidMove(string userInput)
        {
            if (int.TryParse(userInput, out int move) && move >= 1 && move <= 9)
            {
                return board[move - 1] != "X" && board[move - 1] != "O";
            }
            return false;
        }

        public void MakeMove(string userInput, string currentPlayerSymbol)
        {
            int move = int.Parse(userInput);
            board[move - 1] = currentPlayerSymbol;
        }

        public void Display()
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("--+--+--");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("--+--+--");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        public void ResetBoard()
        {
            board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        }

    }
}
