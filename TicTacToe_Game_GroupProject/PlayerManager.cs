using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    public class PlayerManager
    {

       private Player player1;
        private Player player2;
        private Player currentPlayer;

        // Ställer in spelarna utan namn-inmatning
        public void PlayerDetails()
        {
            player1 = new Player("Player 1", "X");
            player2 = new Player("Player 2", "O");
            currentPlayer = player1; // Starta med spelare 1
        }

        // Returnerar den aktuella spelaren
        public Player GetCurrentPlayer()
        {
            return currentPlayer;
        }

        // Växlar mellan spelarna
        public void PlayerOrder()
        {
            currentPlayer = currentPlayer == player1 ? player2 : player1;
        }
    }
}
