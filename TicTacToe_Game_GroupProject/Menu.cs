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
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            Console.WriteLine(
                "\n1.Start Game" +
                "\n2.Exit");
        }//End if ShowMenu()
        
        public int GetMenuChoice()
        {
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int choice)) //Checks if it's a number
            {
                if(choice >0 && choice < 10) // checks if the input is valid button number (1-9)
                {
                    return choice;
                }
                else//if it's a number that is not in the board, it will give error
                {
                    Console.WriteLine($"'{input}' does not exist. Please enter a valid button");
                    return choice;

                }

            }
            else
            {
                Console.WriteLine($"'{input}' is not a valid number");
                return 0; 
            }
        }

    }
}
