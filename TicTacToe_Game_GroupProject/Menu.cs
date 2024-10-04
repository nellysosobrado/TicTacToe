using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Menu
    {
        // Visar startmenyn
        public void ShowMenu()
        {
            DisplayTitle(); // Visa spelets titel

            // Piltangentnavigering för menyn
            NavigateMenu();
        }

        // Metod för att visa den centrerade "TIC TAC TOE"-titeln och placera den närmare mitten
        static void DisplayTitle()
        {
            // Behåll din originalrubrik här
            string title = @"
   ______  __   ______       ______  ______   ______       ______  ______   ______    
  /\__  _\/\ \ /\  ___\     /\__  _\/\  __ \ /\  ___\     /\__  _\/\  __ \ /\  ___\   
  \/_/\ \/\ \ \\ \ \____    \/_/\ \/\ \  __ \\ \ \____    \/_/\ \/\ \ \/\ \\ \  __\   
     \ \_\ \ \_\\ \_____\      \ \_\ \ \_\ \_\\ \_____\      \ \_\ \ \_____\\ \_____\ 
      \/_/  \/_/ \/_____/       \/_/  \/_/\/_/ \/_____/       \/_/  \/_____/ \/_____/ 
";

            Console.ForegroundColor = ConsoleColor.Yellow;  // Set title color to Cyan
            // Flytta rubriken till mitten, men utan att ta för mycket plats
            int windowHeight = Console.WindowHeight;
            int windowWidth = Console.WindowWidth;
            int topPadding = (windowHeight / 3); // Flytta rubriken lite ovanför mitten

            // Skriver ut tomma rader för att centrera vertikalt
            for (int i = 0; i < topPadding; i++)
            {
                Console.WriteLine(); // Skapa tomma rader för att skjuta ner rubriken
            }

            // Räkna ut antalet mellanslag som behövs för att centrera texten horisontellt
            string[] titleLines = title.Split('\n');
            foreach (string line in titleLines)
            {
                int padding = (windowWidth - line.Length) / 2; // Beräkna hur många mellanslag som behövs
                Console.WriteLine(new string(' ', padding) + line); // Skriv ut linjen med mellanslag
            }

            Console.ResetColor();  // Återställ färgen till standard
        }

        // Piltangentnavigering och highlight-funktion
        private void NavigateMenu()
        {
            int selectedOption = 0;
            string[] menuOptions = { "Start Game", "Exit" };

            while (true)
            {
                // Visa menyalternativen och markera valt alternativ
                DisplayMenuOptions(menuOptions, selectedOption);

                // Läs in tangenttryckningar från användaren
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption == 0) ? menuOptions.Length - 1 : selectedOption - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption == menuOptions.Length - 1) ? 0 : selectedOption + 1;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // Bekräfta valet med "Enter"
                    HandleMenuSelection(selectedOption);
                    break;
                }
            }
        }

        // Visar menyalternativen och markerar valt alternativ utan att highlighta hela raden
        private void DisplayMenuOptions(string[] options, int selectedOption)
        {
            Console.Clear(); // Rensa skärmen
            DisplayTitle(); // Visa rubriken igen

            int windowWidth = Console.WindowWidth;

            // Skriv ut menyalternativen och markera det valda alternativet
            for (int i = 0; i < options.Length; i++)
            {
                int padding = (windowWidth - options[i].Length) / 2;

                // Skriv ut mellanslagen separat, utan highlight
                Console.Write(new string(' ', padding));

                // Highlight enbart texten
                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.White; // Markera valt alternativ med vit färg
                    Console.BackgroundColor = ConsoleColor.DarkGray; // Lägg till bakgrund för highlight
                    Console.Write(options[i]); // Skriv ut texten för highlight
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Övriga alternativ är i cyan
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(options[i]); // Skriv ut de andra alternativen utan highlight
                }

                // Återställ färgerna för nästa rad
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // Hanterar valet av menyalternativ
        private void HandleMenuSelection(int selectedOption)
        {
            if (selectedOption == 0)
            {
                Console.Clear();
                DisplayCenteredText("Starting the game...", ConsoleColor.Green);
                ShowLoadingBar(); // Visa en animerad laddningsbar

                Console.Clear(); // Rensa konsolen efter laddningen
                Game game = new Game();
                game.Start(); // Starta spelet
            }
            else if (selectedOption == 1)
            {
                Console.Clear();
                DisplayCenteredText("Exiting...", ConsoleColor.Red);
                Environment.Exit(0); // Avsluta programmet
            }
        }

        private void ShowLoadingBar()
        {
            int total = 50; // Total längd på laddningsbaren
            int windowWidth = Console.WindowWidth; // Hämta konsolens bredd

            // Centrera och visa laddningstexten
            string loadingText = "Loading...";
            int paddingText = (windowWidth - loadingText.Length) / 2;
            Console.SetCursorPosition(paddingText, Console.CursorTop); // Sätt textens position
            Console.WriteLine(loadingText);

            // Centrera och visa laddningsbaren
            int paddingBar = (windowWidth - total) / 2;
            Console.SetCursorPosition(paddingBar, Console.CursorTop); // Sätt laddningsbarens position
            Console.Write("["); // Start på laddningsbaren

            for (int i = 0; i < total; i++)
            {
                Console.Write("="); // Lägg till ett steg i laddningsbaren
                Thread.Sleep(50); // Fördröjning för att skapa laddningseffekten (50 ms per steg)
            }

            Console.WriteLine("]"); // Avsluta laddningsbaren

            // Centrera och visa "Loading complete!" texten
            string completeText = "Loading complete!";
            int paddingCompleteText = (windowWidth - completeText.Length) / 2;
            Console.SetCursorPosition(paddingCompleteText, Console.CursorTop); // Sätt positionen för "Loading complete!"
            Console.WriteLine(completeText);

            Thread.Sleep(1000); // Pausa lite efter att laddningen är klar
        }

        // Visar centrerad text med färg
        private void DisplayCenteredText(string text, ConsoleColor color)
        {
            int windowWidth = Console.WindowWidth;
            int padding = (windowWidth - text.Length) / 2; // Beräkna hur många mellanslag som behövs
            Console.ForegroundColor = color; // Sätt färg på texten
            Console.WriteLine(new string(' ', padding) + text); // Skriv ut texten med mellanslag
            Console.ResetColor(); // Återställ färgen till standard
        }
    }
}
