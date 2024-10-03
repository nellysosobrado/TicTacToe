using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Menu
    {
        //Displays start page
        public void ShowMenu()
        {
            DisplayTitle(); // Visa spelets titel

            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Exit");

            int choice = GetMenuChoice();

            if (choice == 1)
            {
                Console.WriteLine("Starting the game...");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(); // Vänta på att användaren ska trycka på en knapp innan spelet startar
                Game game = new Game();
                game.Start(); // Starta spelet
            }
            else if (choice == 2)
            {
                Console.WriteLine("Exiting...");
            }
        }
        // Method to display the "TIC TAC TOE" title
        static void DisplayTitle()
        {
            // ASCII Art or simple text for "TIC TAC TOE"
            string title = @"
   ______  __   ______       ______  ______   ______       ______  ______   ______    
  /\__  _\/\ \ /\  ___\     /\__  _\/\  __ \ /\  ___\     /\__  _\/\  __ \ /\  ___\   
  \/_/\ \/\ \ \\ \ \____    \/_/\ \/\ \  __ \\ \ \____    \/_/\ \/\ \ \/\ \\ \  __\   
     \ \_\ \ \_\\ \_____\      \ \_\ \ \_\ \_\\ \_____\      \ \_\ \ \_____\\ \_____\ 
      \/_/  \/_/ \/_____/       \/_/  \/_/\/_/ \/_____/       \/_/  \/_____/ \/_____/ 
                                                                                     
";

            Console.ForegroundColor = ConsoleColor.Yellow;  // Set title color to Cyan
            Console.WriteLine(title);  // Print the title
            Console.ResetColor();  // Reset color back to default
        }


        //Method, starts the game

        // Hämtar och validerar användarens menyval
        private int GetMenuChoice()
        {
            while (true)
            {
                Console.WriteLine("Enter your choice (1 or 2):");
                string input = Console.ReadLine().Trim();

                if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 to start the game or 2 to exit.");
                }
            }
        }
    }
}
