using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class ErrorManager
    {
        // Hanterar och returnerar ett felmeddelande baserat på en ogiltig tangent
        public string HandleInvalidKey()
        {
            return "Invalid key. Use 'Arrows' keys to move. Press any key to continue";
        }

        // Hanterar och returnerar ett felmeddelande baserat på en upptagen ruta
        public string HandleInvalidMove()
        {
            return "Slot is already taken. Next players turn. Press any key to contineu";
        }

        // Visa felmeddelande i konsolen
        public void DisplayErrorMessage(string errorMessage, int leftPadding, int topPadding)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(leftPadding-20, topPadding);
            Console.Write(errorMessage);
            Console.ResetColor();
        }
    }
}
