using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class Player
    {
        public string Name { get; set; } // Spelarens namn
        public string Symbol { get; set; } // Spelarens symbol (X eller O)

        // Konstruktor för att initialisera spelaren med namn och symbol
        public Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
