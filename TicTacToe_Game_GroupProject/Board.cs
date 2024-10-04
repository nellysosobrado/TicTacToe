using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Board
    {
        private string[] board = { " ", " ", " ", " ", " ", " ", " ", " ", " " }; // Tomma rutor
        private int currentRow = 0;
        private int currentCol = 0;

        // Publika egenskaper för att kunna hämta currentRow och currentCol från Game-klassen
        public int CurrentRow => currentRow;
        public int CurrentCol => currentCol;

        public string[] BoardState => board;

        // Kontrollera om draget är giltigt
        public bool IsValidMove(int index)
        {
            return board[index] != "X" && board[index] != "O"; // Kontrollera att rutan är tom
        }

        // Genomför ett drag
        public void MakeMove(int index, string currentPlayerSymbol)
        {
            board[index] = currentPlayerSymbol; // Placera symbolen i rutan
        }

        // Visa brädan och eventuellt felmeddelande
        public void Display(string currentPlayer, string symbol, string errorMessage = "")
        {
            Console.Clear(); // Rensa konsolen innan varje visning

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            // Beräkna var vi ska börja skriva ut text och bräda för att centrera den
            int topPadding = (windowHeight - 9) / 2; // 9 rader för brädan
            int leftPadding = (windowWidth - 23) / 2; // 23 tecken bred

            // Centrera rubriken för aktuell spelare och instruktionen
            CenterText($"Player {currentPlayer} turn ({symbol})", leftPadding, topPadding - 2);

            // Rita upp brädan med highlight på den valda rutan
            for (int row = 0; row < 3; row++)
            {
                SetCursorPositionCentered(leftPadding, topPadding + row * 2);
                Console.WriteLine("╔═════╦═════╦═════╗");

                SetCursorPositionCentered(leftPadding, topPadding + row * 2 + 1);
                Console.Write("║");
                for (int col = 0; col < 3; col++)
                {
                    int index = row * 3 + col;

                    // Highlight rutan där markören är
                    if (row == currentRow && col == currentCol)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray; // Markera rutan
                    }

                    string cell = board[index]; // Cellens värde
                    Console.Write($"  {cell}  "); // Skriv ut cellens innehåll
                    Console.ResetColor(); // Återställ färger

                    Console.Write("║");
                }
                Console.WriteLine();
            }
            SetCursorPositionCentered(leftPadding, topPadding + 6);
            Console.WriteLine("╚═════╩═════╩═════╝");

            // Om det finns ett felmeddelande, visa det i röd färg under brädan
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.ForegroundColor = ConsoleColor.Red; // Sätt textfärgen till röd
                CenterText(errorMessage, leftPadding, topPadding + 8); // Placera meddelandet under brädan
                Console.ResetColor(); // Återställ färger
            }
        }

        // Sätt markören för att centrera text eller brädan
        private void SetCursorPositionCentered(int leftPadding, int topPadding)
        {
            Console.SetCursorPosition(leftPadding, topPadding);
        }

        // Centrera texten baserat på fönstrets bredd
        private void CenterText(string text, int leftPadding, int topPadding)
        {
            Console.SetCursorPosition(leftPadding, topPadding);
            Console.WriteLine(text);
        }

        public void ResetBoard()
        {
            board = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " }; // Tomma rutor
        }

        // Uppdaterad metod som kontrollerar draget och skickar ett felmeddelande om nödvändigt
        public bool NavigateAndMakeMove(string currentPlayerSymbol, out string errorMessage)
        {
            ConsoleKey key;
            errorMessage = ""; // Tomt felmeddelande

            do
            {
                Display(currentPlayerSymbol == "X" ? "1" : "2", currentPlayerSymbol, errorMessage); // Visa brädan och felmeddelande om det finns

                // Beräkna index för att sätta markören
                int index = currentRow * 3 + currentCol;

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentRow > 0) currentRow--; // Flytta uppåt
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentRow < 2) currentRow++; // Flytta nedåt
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentCol > 0) currentCol--; // Flytta vänster
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentCol < 2) currentCol++; // Flytta höger
                        break;
                    case ConsoleKey.Enter:
                        if (IsValidMove(index)) // Kontrollera om draget är giltigt när Enter trycks
                        {
                            MakeMove(index, currentPlayerSymbol); // Gör draget om giltigt
                            return true; // Returnera true om draget är giltigt och avsluta
                        }
                        else
                        {
                            // Ogiltigt drag, sätt felmeddelande
                            errorMessage = "Invalid move! The cell is already occupied.";
                            return false;
                        }
                }

            } while (key != ConsoleKey.Escape);

            return false; // Om ingen giltig input ges
        }
    }
}
