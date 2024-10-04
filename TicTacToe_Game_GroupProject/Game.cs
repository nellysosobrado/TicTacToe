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
        private string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public string[] BoardState => board;

        public void Start()
        {
            string currentPlayer = "1";
            bool isGameRunning = true;

            // Spelets huvudloop
            while (isGameRunning)
            {
                // Visa brädan och aktuell spelares tur
                Display(currentPlayer);

                // Be spelaren välja en ruta
                CenterText($"Player {currentPlayer}, choose a number between 1-9: ");
                string userInput = Console.ReadLine();

                // Kontrollera om draget är giltigt
                if (IsValidMove(userInput))
                {
                    // Utför draget och byta spelare
                    MakeMove(userInput, currentPlayer == "1" ? "X" : "O");

                    // Kolla om någon vinner eller om det blir oavgjort
                    if (CheckForWinner())
                    {
                        Display(currentPlayer); // Visa brädan en sista gång
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        isGameRunning = false;
                    }
                    else if (IsBoardFull())
                    {
                        Display(currentPlayer); // Visa brädan en sista gång
                        Console.WriteLine("It's a draw!");
                        isGameRunning = false;
                    }
                }
                else
                {
                    // Om ogiltigt drag, visa meddelande och hoppa över till nästa spelare
                    Console.WriteLine($"Invalid move by Player {currentPlayer}. Skipping to the next player's turn.");
                    Console.ReadKey(); // Vänta på knapptryckning för att låta spelaren se meddelandet
                }

                // Växla spelare, oavsett om inmatningen var giltig eller ej
                currentPlayer = (currentPlayer == "1") ? "2" : "1";
            }
        }

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

        public void Display(string currentPlayer)
        {
            Console.Clear(); // Rensa konsolen innan varje visning

            // Flytta ner texten för att lämna utrymme för att brädan hamnar i mitten
            int emptyLinesBeforeBoard = (Console.WindowHeight - 15) / 2; // 15 rader för spelplan och raminformation
            for (int i = 0; i < emptyLinesBeforeBoard; i++)
            {
                Console.WriteLine(); // Tomma rader för att centrera i höjdled
            }

            // Centrera rubriken för aktuell spelare och instruktionen
            CenterText($"Player {currentPlayer}'s turn");
            CenterText("Choose a number between 1-9");
            Console.WriteLine(); // Extra rad för separation

            // Rama in brädan och gör den större med raka linjer
            CenterText("╔═════╦═════╦═════╗");
            CenterText($"║  {FormatCell(board[6])}  ║  {FormatCell(board[7])}  ║  {FormatCell(board[8])}  ║");
            CenterText("╠═════╬═════╬═════╣");
            CenterText($"║  {FormatCell(board[3])}  ║  {FormatCell(board[4])}  ║  {FormatCell(board[5])}  ║");
            CenterText("╠═════╬═════╬═════╣");
            CenterText($"║  {FormatCell(board[0])}  ║  {FormatCell(board[1])}  ║  {FormatCell(board[2])}  ║");
            CenterText("╚═════╩═════╩═════╝");
            Console.WriteLine(); // Extra rad för separation
        }

        private string FormatCell(string cell)
        {
            // Ger färg beroende på om det är X eller O
            if (cell == "X")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (cell == "O")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White; // Standardfärg för tomma celler
            }

            string formattedCell = $"{cell}"; // Behåll cellens värde
            Console.ResetColor(); // Återställ färgen för att inte påverka resten av texten
            return formattedCell;
        }

        private void CenterText(string text)
        {
            // Hämta konsolens bredd och räkna ut var texten ska börja
            int windowWidth = Console.WindowWidth;
            int centeredPosition = (windowWidth - text.Length) / 2;
            Console.SetCursorPosition(centeredPosition, Console.CursorTop); // Sätt textens position
            Console.WriteLine(text);
        }

        public void ResetBoard()
        {
            board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        }

        // Kolla om det finns en vinnare
        private bool CheckForWinner()
        {
            // Indexen för vinnande kombinationer
            int[,] winningCombinations = {
        { 0, 1, 2 }, // Rad 1
        { 3, 4, 5 }, // Rad 2
        { 6, 7, 8 }, // Rad 3
        { 0, 3, 6 }, // Kolumn 1
        { 1, 4, 7 }, // Kolumn 2
        { 2, 5, 8 }, // Kolumn 3
        { 0, 4, 8 }, // Diagonal 1
        { 2, 4, 6 }  // Diagonal 2
    };

            // Gå igenom alla vinnarkombinationer
            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                int a = winningCombinations[i, 0];
                int b = winningCombinations[i, 1];
                int c = winningCombinations[i, 2];

                // Kolla om alla tre värden är lika och inte är ett nummer
                if (board[a] == board[b] && board[b] == board[c])
                {
                    return true;
                }
            }

            return false;
        }

        // Kolla om brädan är full
        private bool IsBoardFull()
        {
            return board.All(s => s == "X" || s == "O");
        }
    }
}
