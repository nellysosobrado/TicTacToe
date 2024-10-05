using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FirstPage
{
    public void Display()
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        Random rand = new Random();

        string title = @"
  _________  ___  ________          _________  ________  ________     
|\___   ___\\  \|\   ____\        |\___   ___\\   __  \|\   ____\    
\|___ \  \_\ \  \ \  \___|        \|___ \  \_\ \  \|\  \ \  \___|    
     \ \  \ \ \  \ \  \                \ \  \ \ \   __  \ \  \       
      \ \  \ \ \  \ \  \____            \ \  \ \ \  \ \  \ \  \____  
       \ \__\ \ \__\ \_______\           \ \__\ \ \__\ \__\ \_______\
        \|__|  \|__|\|_______|            \|__|  \|__|\|__|\|_______|
                         _________  ________  _______                
                        |\___   ___\\   __  \|\  ___ \               
                        \|___ \  \_\ \  \|\  \ \   __/|              
                             \ \  \ \ \  \\\  \ \  \_|/__            
                              \ \  \ \ \  \\\  \ \  \_|\ \           
                               \ \__\ \ \_______\ \_______\          
                                \|__|  \|_______|\|_______|     

Press any key to continue..
";

        Console.Clear();

        for (int frame = 0; frame < 30; frame++) // Display 30 frames of stars
        {
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true); // Consume the key press
                break; // Exit the animation loop early if the user presses a key
            }

            Console.Clear();

            // Draw the stars
            for (int i = 0; i < 100; i++) // Draw 100 stars per frame
            {
                int x = rand.Next(0, width);
                int y = rand.Next(0, height);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = (rand.Next(0, 10) < 3) ? ConsoleColor.Yellow : ConsoleColor.White; // Blinking effect
                Console.Write("*");
            }

            // Draw the title with blinking stars
            int windowHeight = Console.WindowHeight;
            int windowWidth = Console.WindowWidth;
            int topPadding = (windowHeight / 3);
            string[] titleLines = title.Split('\n');

            Console.SetCursorPosition(0, topPadding);
            foreach (string line in titleLines)
            {
                int padding = (windowWidth - line.Length) / 2;
                Console.Write(new string(' ', padding));
                foreach (char c in line)
                {
                    if (c == ' ')
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        if (rand.Next(0, 10) < 2) // 20% chance to make a star blink
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write('*');
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(c);
                        }
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
            Thread.Sleep(600); // Pause to create animation effect
        }
    }
}
