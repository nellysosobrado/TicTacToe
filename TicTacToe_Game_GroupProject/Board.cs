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

        public void Display(string currentPlayer)
        {
            Console.Clear(); // Rensa konsolen innan varje visning

            // Ställ in Unicode-stöd för konsolen
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Anpassa fönsterstorleken för att rymma brädan
            Console.SetWindowSize(50, 20);

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

    }
}
