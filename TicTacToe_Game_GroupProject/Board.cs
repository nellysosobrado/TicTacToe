using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Board
    {
        //Instans variablar av klassen board
        private string[] board = { " ", " ", " ", " ", " ", " ", " ", " ", " " };

        private int currentRow = 0;
        private int currentCol = 0;

        private ErrorManager errorManager = new ErrorManager(); // Instans av ErrorManager.cs klassen för att anroppa felhanteringarna

        //Instans properties för att avläsa klassen board, public för att andra klasser ska nå
        public string[] BoardState//Avläser spelbrädan
        {
            get
            {
                return board; 
            }
        }
        //CurrentRow & CurrentCol, begränsar användarens navigation inom brädan. Navigationen stannar inom bräddan
        public int CurrentRow
        {
            get
            {
                if (currentRow < 0)
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
                if(currentCol>2)
                {
                    return 2;
                }
                else
                {
                    return currentCol;
                }
            }
        }




        public bool IsValidMove(int index)
        {
            return board[index] != "X" && board[index] != "O";
        }

        public void MakeMove(int index, string currentPlayerSymbol)
        {
            board[index] = currentPlayerSymbol;
        }

        public void Display(string currentPlayer, string symbol, string errorMessage = "")
        {
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int topPadding = (windowHeight - 9) / 2;
            int leftPadding = (windowWidth - 23) / 2;

            CenterText($"Player {currentPlayer} turn ({symbol})", leftPadding, topPadding - 2);
            CenterText("Use 'arrow' keys to move. Press 'ENTER' to select a slot", leftPadding - 17, topPadding + 9);
            CenterText("Press 'Escape' to Quit", leftPadding, topPadding + 10);

            for (int row = 0; row < 3; row++)
            {
                SetCursorPositionCentered(leftPadding, topPadding + row * 2);
                Console.WriteLine("╔═════╦═════╦═════╗");
                SetCursorPositionCentered(leftPadding, topPadding + row * 2 + 1);
                Console.Write("║");

                for (int col = 0; col < 3; col++)
                {
                    int index = row * 3 + col;

                    if (row == CurrentRow && col == CurrentCol)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    string cell = board[index];
                    Console.Write($"  {cell}  ");
                    Console.ResetColor();
                    Console.Write("║");
                }
                Console.WriteLine();
            }

            SetCursorPositionCentered(leftPadding, topPadding + 6);
            Console.WriteLine("╚═════╩═════╩═════╝");

            if (!string.IsNullOrEmpty(errorMessage))
            {
                errorManager.DisplayErrorMessage(errorMessage, leftPadding, topPadding + 7); // Använder ErrorManager för att visa felmeddelande
            }
        }

        private void SetCursorPositionCentered(int leftPadding, int topPadding)
        {
            Console.SetCursorPosition(leftPadding, topPadding);
        }

        private void CenterText(string text, int leftPadding, int topPadding)
        {
            Console.SetCursorPosition(leftPadding, topPadding);
            Console.WriteLine(text);
        }

        public void ResetBoard()
        {
            board = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        }

        public bool NavigateAndMakeMove(string currentPlayerSymbol, out string errorMessage) //Hanterar navigationen på brädan
        {
            ConsoleKey key;
            errorMessage = "";

            do//Kör igenom hela koden en gång, och därefter kollar villkorent
            {
                //Undersöker vem det är som spelar
                string currentPlayer;
                if (currentPlayerSymbol=="X")
                {
                    currentPlayer = "1";
                }
                else
                {
                    currentPlayer = "2";
                }
                Display(currentPlayer, currentPlayerSymbol, errorMessage);


                int index = CurrentRow * 3 + CurrentCol;
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentRow > 0) currentRow--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentRow < 2) currentRow++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentCol > 0) currentCol--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentCol < 2) currentCol++;
                        break;
                    case ConsoleKey.Enter:
                        if (IsValidMove(index))
                        {
                            MakeMove(index, currentPlayerSymbol);
                            return true;
                        }
                        else
                        {
                            errorMessage = errorManager.HandleInvalidMove(); // Använder ErrorManager för att hämta felmeddelande
                            return false;
                        }
                    default:
                        errorMessage = errorManager.HandleInvalidKey(); // Använder ErrorManager för att hämta felmeddelande
                        return false;
                }

            } while (key != ConsoleKey.Escape); //Om användarens intryck input inte är  esape)

            return false;
        }
    }
}
