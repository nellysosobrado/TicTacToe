using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Board
    {
        //Instans variabler
        private string[] board = { " ", " ", " ", " ", " ", " ", " ", " ", " " }; 
        private int currentRow = 0;
        private int currentCol = 0;

       //Getters
        public int CurrentRow
        {
            get
            {
                if(currentRow <0)
                {
                    return 0;
                }
                else
                {
                    return currentRow;
                }
            }
        }

        public int CurrentCol
        {
            get
            {
                if(currentCol > 2)
                {
                    return 2;
                }
                else
                {
                    return currentCol;
                }
            }
        }

        //Trackear boardens innehåll
        public string[] BoardState
        {
            get
            {
                return board;
            }
        }

        //Undersöker input
        public bool IsValidMove(int index)
        {
            if (board[index] =="X" || board[index] =="O")
            {
                return false; //Invalid input
            }
            else
            {
                return true; //Tom 
            }
        }

        //User input blir markerad med dens Symbol "X" eller "O"
        public void MakeMove(int index, string currentPlayerSymbol)
        {
            board[index] = currentPlayerSymbol; // Placera symbolen i rutan
        }

        /// <summary>
        /// Method som visar upp bräddans innehåll
        /// </summary>
        /// <param name="currentPlayer">Player1 eller Player 2</param>
        /// <param name="symbol">Antingen "X" eller "O" beroende på vilken spelare det är</param>
        /// <param name="errorMessage">Felmeddelande i variabel, eftersom flexibelt att ändra</param>
        //Method som visar up brädans innehåll
        public void Display(string currentPlayer, string symbol, string errorMessage = "")
        {
            Console.Clear();

            //Variablar av consolens bred & höjd
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            //Uträkning vart mitten är på höjden & bredden deklareras in i nya variablar
            int topPadding = (windowHeight - 9) / 2; // 9 rader för brädan, Vertikalt
            int leftPadding = (windowWidth - 23) / 2; // 23 tecken bred Horisontell

            
            //Method, som justerar så att texten hamnar i mitten
            //leftPadding, justerar positionen på texten horisontellt
            //toppading, justerar veritkallt
            CenterText($"Player {currentPlayer} turn ({symbol})", leftPadding, topPadding - 2);
            CenterText($"Press 'Escape' to Quit", leftPadding, topPadding + 10);

            // Rita upp brädan med highlight på den valda rutan
            //Loopar igenom brädans row 3 gånger HORISTONELL
            for (int row = 0; row < 3; row++)
            {
                SetCursorPositionCentered(leftPadding, topPadding + row * 2);//Placerar navigationen beroende på vilken row loopen beffiner sig i
                Console.WriteLine("╔═════╦═════╦═════╗");

                SetCursorPositionCentered(leftPadding, topPadding + row * 2 + 1);//Beroende på row nummer placeras det i första horistonella raden
                Console.Write("║");

                for (int col = 0; col < 3; col++)//Loopar igenom brädan vertikallt
                {
                    int index = row * 3 + col;

                    // Highlight rutan där markören är
                    if (row == CurrentRow && col == CurrentCol)//Undersöker om användarens markör befinner sig i loopens "row"
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray; // Markera rutan
                    }

                    string cell = board[index]; // Cellens värde
                    Console.Write($"  {cell}  "); // Skriv ut cellens innehåll
                    Console.ResetColor(); // Återställ färger

                    Console.Write("║");
                }
                Console.WriteLine();//Ny rad skapas när alla tre kolumner har skapats, för att flytta ner markören
            }
            //skriver ut sista delen av bräddan
            SetCursorPositionCentered(leftPadding, topPadding + 6);
            Console.WriteLine("╚═════╩═════╩═════╝");

            switch (errorMessage)//Undersöker om variabeln innehåller felmeddelande
            {
                case null:
                case "":
                    break;
                default://Om variabeln innehåller något, mattas innehållet ut som felmeddelande
                    Console.ForegroundColor = ConsoleColor.Red; //Textens färg
                    CenterText(errorMessage, leftPadding, topPadding + 8); //Placerar felmeddelandet under bräddan
                    break;
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
                int index = CurrentRow * 3 + CurrentCol;

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
                    default:
                        // Ogiltig tangent, skippa spelaren och visa felmeddelande
                        errorMessage = "Invalid key! You will be skipped. Please use arrow keys to navigate.";
                        return false; // Skippa spelaren
                }

            } while (key != ConsoleKey.Escape);

            return false; // Om ingen giltig input ges
        }
    }
}
