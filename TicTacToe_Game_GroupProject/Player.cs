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

        // Metod för att ställa in spelarens namn
        public void SetPlayerNames()
        {
            Console.Write("Enter Player 1 name: ");
            string player1Name = Console.ReadLine()!; // "!" säger att vi ignorerar null-varningen

            if (string.IsNullOrWhiteSpace(player1Name))
            {
                player1Name = "Player 1"; // Säkerställ att namnet inte är tomt
            }

            Console.Write("Enter Player 2 name: ");
            string player2Name = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(player2Name))
            {
                player2Name = "Player 2";
            }

            players[0] = new Player(player1Name, "X");
            players[1] = new Player(player2Name, "O");
        }
        // Hämtar den aktuella spelaren
        public Player GetCurrentPlayer()
        {
            return players[currentPlayerIndex];
        }

        // Växla till nästa spelare
        public void SwitchPlayerTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Length; // Cykla genom spelarna
        }
    }
}