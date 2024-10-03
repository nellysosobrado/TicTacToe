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

        // Konstruktorn som initierar klasserna
        public Game()
        {
            players = new PlayerManager();
            board = new Board();
            winnerChecker = new WinDrawLossChecker();
        }

        // Startar spelet
        public void Start()
        {
            players.PlayerDetails(); // Sätter upp spelarna utan namn-inmatning
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

                // Kontrollerar användarens input
                if (board.IsValidMove(userInput))
                {
                    board.MakeMove(userInput, currentPlayer.Symbol);
                    gameCounter++;

                    // Kontrollerar om någon har vunnit
                    if (winnerChecker.CheckWinner(board.BoardState, currentPlayer.Symbol))
                    {
                        board.Display();
                        Console.WriteLine($"\nPlayer {currentPlayer.Name} wins!");
                        gameOn = false;
                    }
                    else if (gameCounter == 9)
                    {
                        board.Display();
                        Console.WriteLine("\n It's a draw!");
                        gameOn = false;
                    }
                    else
                    {
                        players.PlayerOrder(); // Växlar spelare
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
    }
}
