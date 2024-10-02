using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    internal class WinDrawLossChecker
    {
        public bool CheckWinner(string[] buttons, string player)
        {
            int[][] winningCombinations = new int[][]
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };

            foreach (var combo in winningCombinations)
            {
                if (buttons[combo[0]] == player && buttons[combo[1]] == player && buttons[combo[2]] == player)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
