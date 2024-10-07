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

        // Konstruktor för att skapa en spelare med namn och symbol
        public Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // Statisk metod för att hämta standardspelare
        public static Player[] CreateDefaultPlayers()
        {
            return new Player[]
            {
                new Player("Player 1", "X"),
                new Player("Player 2", "O")
            };
        }
    }

    public class PlayerManager
    {
        private Player[] players; // Array för att lagra spelare
        private int currentPlayerIndex = 0; // Index för den aktuella spelaren

        public PlayerManager()
        {
            players = Player.CreateDefaultPlayers(); // Skapa standardspelare
        }

        // Hämtar den aktuella spelaren
        public Player GetCurrentPlayer()
        {
            return players[currentPlayerIndex];
        }

        // Växla till nästa spelare
        public void SwitchPlayerTurn()
        {
            if (currentPlayerIndex == 0)
            {
                currentPlayerIndex = 1;
            }
            else
            {
                currentPlayerIndex = 0;
            }
        }
    }
}