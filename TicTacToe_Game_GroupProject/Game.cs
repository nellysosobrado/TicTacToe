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
        private Board board = new Board(); // Använder din Board-klass

        // Lägg till denna Start-metod om den saknas
        public void Start()
        {
            string currentPlayer = "1"; // Spelare 1 startar
            bool isGameRunning = true;
            string errorMessage = ""; // Hanterar felmeddelanden

            // Spelets huvudloop
            while (isGameRunning)
            {
                // Visa brädan och låt spelaren navigera och göra sitt drag
                bool validMove = board.NavigateAndMakeMove(currentPlayer == "1" ? "X" : "O", out errorMessage);

                if (!validMove)
                {

                    board.Display(currentPlayer, currentPlayer == "1" ? "X" : "O", errorMessage);
                    Console.ReadKey(); // Vänta på att användaren trycker på en knapp för att se meddelandet
                    currentPlayer = (currentPlayer == "1") ? "2" : "1"; // Växla spelare
                    continue; // Hoppa över resten av loopen för att gå direkt till nästa spelare
                }

                // Kolla om någon har vunnit eller om det blivit oavgjort
                if (CheckForWinner())
                {
                    board.Display(currentPlayer, currentPlayer == "1" ? "X" : "O"); // Visa brädan en sista gång
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    isGameRunning = false;
                }
                else if (IsBoardFull())
                {
                    board.Display(currentPlayer, currentPlayer == "1" ? "X" : "O"); // Visa brädan en sista gång
                    Console.WriteLine("It's a draw!");
                    isGameRunning = false;
                }

                // Växla spelare efter ett giltigt drag
                currentPlayer = (currentPlayer == "1") ? "2" : "1";
                errorMessage = ""; // Nollställ felmeddelandet för nästa runda
            }
        }

        // Övriga metoder som CheckForWinner och IsBoardFull ska också vara med här
        // Kolla om någon har vunnit
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

        // Kolla om brädan är full
        private bool IsBoardFull()
        {
            return board.BoardState.All(s => s == "X" || s == "O");
        }
        
    }
}
