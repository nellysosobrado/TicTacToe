using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    
    public class Game
    {
        private Board board = new Board(); // Använder din Board-klass
        private ErrorManager errorManager = new ErrorManager(); // Lägg till en instans av ErrorManager

        public void Start()// Startar spelet
        {
            string currentPlayer = "1"; // Spelare 1 startar
            bool isGameRunning = true;

            // Spelets huvudloop
            while (isGameRunning)
            {
                string marker = GetMarker(currentPlayer); // Hämta markör baserat på spelare
                bool validMove = board.NavigateAndMakeMove(marker, out string errorMessage);

                if (!validMove)
                {
                    board.Display(currentPlayer, marker, errorMessage);
                    //errorManager.DisplayErrorMessage(errorMessage, 10, 20); // Exempel på placering av felmeddelandet
                    Console.ReadKey(); // Vänta på att användaren trycker på en knapp för att se meddelandet
                    currentPlayer = (currentPlayer == "1") ? "2" : "1"; // Växla spelare
                    continue; // Hoppa över resten av loopen för att gå direkt till nästa spelare
                }

                board.Display(currentPlayer, marker); // Visa brädan

                if (CheckForWinner())
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    isGameRunning = false;
                }
                else if (IsBoardFull())
                {
                    Console.WriteLine("It's a draw!");
                    isGameRunning = false;
                }
                else
                {
                    // Växla spelare efter ett giltigt drag
                    currentPlayer = SwitchPlayer(currentPlayer);
                }
            }
        }
        // Växlar till nästa spelare
        private string SwitchPlayer(string currentPlayer)
        {
            return currentPlayer == "1" ? "2" : "1";
        }

        // Hämtar markör baserat på spelare
        private string GetMarker(string currentPlayer)
        {
            return currentPlayer == "1" ? "X" : "O";
        }

        private bool CheckForWinner()
        {
            int[,] winningCombinations = {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                int a = winningCombinations[i, 0];
                int b = winningCombinations[i, 1];
                int c = winningCombinations[i, 2];

                if (board.BoardState[a] == board.BoardState[b] &&
                    board.BoardState[b] == board.BoardState[c] &&
                    board.BoardState[a] != " ")
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsBoardFull()
        {
            return board.BoardState.All(s => s == "X" || s == "O");
        }
    }
}
