using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_Game_GroupProject;

namespace TicTacToe_Game_GroupProject
{
    public class Game
    {
        private Board board = new Board(); //instants variabel av klassen Board för att få möjlighet at använda dess methoder
        private int[][] winningCombinations = new int[][] // Definierar vinstkombinationer
        {
            new int[] { 0, 1, 2 },
            new int[] { 3, 4, 5 },
            new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 },
            new int[] { 1, 4, 7 },
            new int[] { 2, 5, 8 },
            new int[] { 0, 4, 8 },
            new int[] { 2, 4, 6 }
        };


        public void Start()
        {
            string currentPlayer = "1"; // Spelare 1 startar
            bool isGameRunning = true;

            // Spelets huvudloop
            while (isGameRunning)
            {
                string marker = GetMarker(currentPlayer); // Hämta markör baserat på spelare
                bool validMove = board.NavigateAndMakeMove(marker, out string errorMessage); //Anropar methoden i klassen board för att navigera

                //Ifstatements undersöker om spel move är valdi eller ej
                if (!validMove)
                {
                    // Om draget var ogiltigt, visa brädet med felmeddelande och växla spelare
                    board.Display(currentPlayer, marker, errorMessage);
                    Console.ReadKey(); // Vänta på att användaren trycker på en knapp
                    currentPlayer = SwitchPlayer(currentPlayer);
                    continue; // Hoppa över resten av loopen för att gå direkt till nästa spelare
                }

                board.Display(currentPlayer, marker); // Visa brädan

                // Kolla om någon har vunnit
                if (CheckWinner(marker))
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

        // Kontrollerar om en spelare har vunnit
        private bool CheckWinner(string playerSymbol)
        {
            foreach (var combo in winningCombinations)
            {
                if (board.BoardState[combo[0]] == playerSymbol &&
                    board.BoardState[combo[1]] == playerSymbol &&
                    board.BoardState[combo[2]] == playerSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        // Växlar till nästa spelare
        private string SwitchPlayer(string currentPlayer)
        {
            if (currentPlayer == "1")
            {
                return "2";
            }
            else
            {
                return "1";
            }
        }

        // Hämtar markör baserat på spelare
        private string GetMarker(string currentPlayer) // Tilldelar Spelare 1 = X , Spelare 2 = O
        {
            if (currentPlayer == "1")
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

        // Kolla om brädan är full
        private bool IsBoardFull()
        {
            return board.BoardState.All(s => s == "X" || s == "O");
        }
    }
}
