using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Game
    {
        private PlayerManager players;
        private Board board;
        private WinDrawLossChecker winnerChecker;

        public Game()
        {
            players = new PlayerManager();
            board = new Board();
            winnerChecker = new WinDrawLossChecker();
        }

        public void Start()
        {
            players.PlayerDetails();
            bool gameOn = true;
            int gameCounter = 0;

            while (gameOn)
            {
                Console.Clear();
                board.Display();
                Player currentPlayer = players.GetCurrentPlayer();
                Console.WriteLine($"Player {currentPlayer.Name}'s turn ({currentPlayer.Symbol})");
                Console.WriteLine("Choose a number between 1-9");

                string userInput = Console.ReadLine();

                if (board.IsValidMove(userInput))
                {
                    board.MakeMove(userInput, currentPlayer.Symbol);
                    gameCounter++;

                    if (winnerChecker.CheckWinner(board.BoardState, currentPlayer.Symbol))
                    {
                        board.Display();
                        Console.WriteLine($"\nPlayer {currentPlayer.Name} wins!");
                        gameOn = false;
                        AskToPlayAgain(ref gameOn, ref gameCounter);
                    }
                    else if (gameCounter == 9)
                    {
                        board.Display();
                        Console.WriteLine("\nIt's a draw!");
                        gameOn = false;
                        AskToPlayAgain(ref gameOn, ref gameCounter);
                    }
                    else
                    {
                        players.PlayerOrder(); // Växla spelare
                    }
                }
                else
                {
                    Console.WriteLine($"'{userInput}' is not a valid input." +
                        "\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // Frågar om spelarna vill spela igen
        private void AskToPlayAgain(ref bool gameOn, ref int gameCounter)
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain == "y")
            {
                board.ResetBoard();
                gameCounter = 0;
                gameOn = true;
            }
            else
            {
                Console.WriteLine("Thank you for playing!\nProgram is closing...");
            }
        }
    }
}
