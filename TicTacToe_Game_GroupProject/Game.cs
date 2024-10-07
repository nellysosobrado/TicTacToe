﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_Game_GroupProject;

namespace TicTacToe_Game_GroupProject
{
    public class Game
    {
        private Board board = new Board(); // Använder din Board-klass
        private int[][] winningCombinations = new int[][] // Definierar vinstkombinationer
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

        // Startar spelet
        public void Start()
        {
            string currentPlayer = "1"; // Spelare 1 startar
            bool isGameRunning = true;

            // Spelets huvudloop
            while (isGameRunning)
            {
                string marker = GetMarker(currentPlayer); // Hämta markör baserat på spelare
                bool validMove = board.NavigateAndMakeMove(marker, out string errorMessage);

                if (!validMove)
                {
                    // Om draget var ogiltigt, visa meddelande och växla spelare
                    ShowInvalidMoveMessage(currentPlayer, marker, errorMessage);
                    currentPlayer = SwitchPlayer(currentPlayer);
                    continue; // Hoppa över resten av loopen för att gå direkt till nästa spelare
                }

                board.Display(currentPlayer, marker); // Visa brädan

                // Kolla om någon har vunnit
                if (CheckWinner(marker))
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    isGameRunning = false;
                }
                else if (IsBoardFull())
                {
                    Console.WriteLine("It's a draw!");
                    isGameRunning = false;
                }
                else
                {
                    // Växla spelare efter ett giltigt drag
                    currentPlayer = SwitchPlayer(currentPlayer);
                }
            }
        }

        // Kontrollerar om en spelare har vunnit
        private bool CheckWinner(string playerSymbol)
        {
            foreach (var combo in winningCombinations)
            {
                if (board.BoardState[combo[0]] == playerSymbol &&
                    board.BoardState[combo[1]] == playerSymbol &&
                    board.BoardState[combo[2]] == playerSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        // Växlar till nästa spelare
        private string SwitchPlayer(string currentPlayer)
        {
            return currentPlayer == "1" ? "2" : "1";
        }

        // Hämtar markör baserat på spelare
        private string GetMarker(string currentPlayer)
        {
            return currentPlayer == "1" ? "X" : "O";
        }

        // Visar meddelande vid ogiltigt drag
        private void ShowInvalidMoveMessage(string currentPlayer, string marker, string errorMessage)
        {
            Console.WriteLine($"Invalid move! Player {currentPlayer} will be skipped. Next player's turn.");
            board.Display(currentPlayer, marker, errorMessage);
            Console.ReadKey(); // Vänta på att användaren trycker på en knapp för att se meddelandet
        }

        // Kolla om brädan är full
        private bool IsBoardFull()
        {
            return board.BoardState.All(s => s == "X" || s == "O");
        }
    }
}
