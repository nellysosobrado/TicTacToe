using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game_GroupProject
{
    internal class WinDrawLossChecker
    {
        public bool CheckWinner(string[] board, string playerSymbol)
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
                if (board[combo[0]] == playerSymbol && board[combo[1]] == playerSymbol && board[combo[2]] == playerSymbol)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
    
}
