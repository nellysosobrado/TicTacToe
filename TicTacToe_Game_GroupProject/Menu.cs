﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Menu
    {
        
        public void ShowMenu()//Metod som visar upp hela meny sidan 
        {
            DisplayTitle(); // Visa spelets titel

            NavigateMenu();//Metod för att navigera med arrow keys
        }
        static void DisplayTitle()
        {
            //ASCII rubrik. För att undvika manuellt skriva radbrytning, tilldelas den som en string med @
            //@ tilldelar rubriken exakt som den är i string variabeln
  
            string title = @"                      
 /'\_/`\                             
/\      \      __     ___    __  __  
\ \ \__\ \   /'__`\ /' _ `\ /\ \/\ \ 
 \ \ \_/\ \ /\  __/ /\ \/\ \\ \ \_\ \
  \ \_\\ \_\\ \____\\ \_\ \_\\ \____/
   \/_/ \/_/ \/____/ \/_/\/_/ \/___/ 
                               
";

            Console.ForegroundColor = ConsoleColor.Yellow; //Gul rubrik

            //Centrera rubriken
            CenterTextVertically();//Anroppar method som centrerar vertikalt i console
            CenterText(title); //Anropar metod som centrerar Rubriken i console

            //Återställ färgen tillbacka
            Console.ResetColor();

        }
        static void CenterTextVertically() //Method för att centrera text i mitten på konsolfönstret
        {
            int windowHeight = Console.WindowHeight; // Höjden på console
            int topPadding = (windowHeight / 3); // Uträkning på vart mitten befinner sig i comssole

            for(int i = 0; i<topPadding; i++)//Centrerar texten genom att trycka ut tomma rader så att texten hamnas längre ned i fönstret
            {
                Console.WriteLine();
            }
        }
        static void CenterText(string text) //Texten placeras i mitten från vänster till höger i cosnolfönstret (horisontellt)
        {
            int windowWidht = Console.WindowWidth; // Console bredden
            string[] lines = text.Split('\n'); //Splitar på varje rad som är en ny rad, och lagrras i arrayn

            foreach(string line in lines)
            {
                int padding = (windowWidht - line.Length) / 2;//7Beräknar mellanslag för centrering horistonellt
                Console.WriteLine(new string(' ', padding) + line); //skriver ut varje rad
            }
        }
        

        // Piltangentnavigering och highlight-funktion
        private void NavigateMenu()
        {
            int selectedOption = 0;//markerar det första alternativet
            string[] menuOptions = { "Start Game", "Exit" };//De olika alternativen i en string array

            while (true)
            {
                // Visa menyalternativen och markera valt alternativ
                DisplayMenuOptions(menuOptions, selectedOption);


                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Användarens intryck avläses
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    // Använd en vanlig if-else-struktur för att hantera uppåt-pilens navigation
                    if (selectedOption == 0)
                    {
                        selectedOption = menuOptions.Length - 1;
                    }
                    else
                    {
                        selectedOption--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    // Använd en vanlig if-else-struktur för nedåt-pilens navigation också
                    if (selectedOption == menuOptions.Length - 1)
                    {
                        selectedOption = 0;
                    }
                    else
                    {
                        selectedOption++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter) // Bekräfta valet med "Enter"
                {
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

        private void HandleMenuSelection(int selectedOption)//Hanterar användarens 'selected 'input
 
        {
            if (selectedOption == 0) //Första meny alternativet 
            {
                Console.Clear();
                DisplayCenteredText("Starting the game...", ConsoleColor.Green);
                ShowLoadingDots(); // Visa en animerad laddningsbar

                Console.Clear(); // Rensa konsolen efter laddningen
                Game game = new Game();
                game.Start(); // Starta spelet
            }
            else if (selectedOption == 1) //Andra alternativet
            {
                Console.Clear();
                DisplayCenteredText("Exiting...", ConsoleColor.Red);
                return; // Avsluta programmet
            }
        }

        private void ShowLoadingDots() // Metod som visar transition mellan Menu till Game sidan
        {
            string loadingText = "Loading";
            int dotCount = 3; // Antalet prickar som ska visas
            int delay = 500; // Fördröjning i millisekunder (0.5 sekunder)
            int totalCycles = 5; // Hur länge animationen ska köras (antal cykler)

            // Beräkna längden på den längsta strängen ("Loading...")
            int maxTextLength = loadingText.Length + dotCount;

            // Centrera texten baserat på den längsta strängen och spara markörens position
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            int cursorTop = Console.CursorTop; // Spara nuvarande radposition

            for (int cycle = 0; cycle < totalCycles; cycle++) // Loopar 5 gånger
            {
                for (int dots = 0; dots <= dotCount; dots++) // Loop för att visa prickar
                {
                    // Beräkna centrering baserat på den maximala längden ("Loading...")
                    int padding = (windowWidth - maxTextLength) / 2;

                    // Flytta markören till ursprunglig position innan vi skriver om texten
                    Console.SetCursorPosition(padding, cursorTop); // Flytta markören till rätt position

                    // Skriv ut texten med rätt antal prickar
                    Console.Write(loadingText + new string('.', dots));

                    Thread.Sleep(delay); // Vänta lite innan nästa cykel

                    // Rensa raden genom att skriva ut tomma mellanslag på samma ställe
                    Console.SetCursorPosition(padding, cursorTop); // Gå tillbaka till samma rad
                    Console.Write(new string(' ', maxTextLength)); // Rensa texten
                }
            }

            // När laddningen är klar, visa "Have Fun :D!" på en ny rad
            Console.SetCursorPosition((windowWidth - "Have Fun :D!".Length) / 2, cursorTop + 1); // Flytta markören nedåt och centrera "Have Fun :D!"
            Console.WriteLine("Have Fun :D!");

            Thread.Sleep(1000); // Pausa en kort stund efter att laddningen är klar
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
