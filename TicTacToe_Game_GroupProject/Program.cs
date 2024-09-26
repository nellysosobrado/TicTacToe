namespace TicTacToe_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TIC TAC TOE");

            string[] buttons = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string player1 = "X";
            string player2 = "O";
            string currentPlayer = player1;
            int gameCounter = 0;
            bool gameOn = true;

            while (gameOn)
            {
                Console.Clear();
                DisplayBoard(buttons);
                Console.WriteLine("Round: " + gameCounter);
                Console.WriteLine($"\nPlayer {currentPlayer}'s turn:");
                Console.WriteLine("Choose a number between 1-9");
                string userInput = Console.ReadLine();

                if (IsValidMove(userInput, buttons))
                {
                    //users valid input will be added, and their tag will replace the gameboard number to either x/o
                    MakeMove(userInput, buttons, currentPlayer);
                    gameCounter++;

                    //Checks: WINNER/DRAW
                    if (CheckWinner(buttons, currentPlayer))
                    {
                        DisplayBoard(buttons);
                        Console.WriteLine($"\nplayer {currentPlayer} wins!");
                        gameOn = false;
                    }
                    else if (gameCounter == 9)
                    {
                        DisplayBoard(buttons);
                        Console.WriteLine("\nDraw!");
                        gameOn = false;
                    }
                    else //Swaps turns
                    {
                        currentPlayer = currentPlayer == player1 ? player2 : player1;
                    }
                }
                else //If enter a text, error message will show in console
                {
                    Console.WriteLine($"'{userInput}' is not a valid input. " +
                        $"\nPlayer '{currentPlayer}' will be skipped." +
                        $"\nPress any key to continue");

                    //Swaps turns
                    if (currentPlayer == player1)
                    {
                        currentPlayer = player2;
                    }
                    else
                    {
                        currentPlayer = player1;
                    }
                    Console.ReadKey();


                }
            }
        }

        //Checks users input
        static bool IsValidMove(string userInput, string[] buttons)
        {
            if (int.TryParse(userInput, out int move))
            {
                if (move >= 1 && move <= 9)
                {
                    return buttons[move - 1] != "X" && buttons[move - 1] != "O";
                }
                else
                {
                    Console.WriteLine($"'{userInput}' is not a valid input betwen 1-9");
                }
            }
            return false;
        }

        //Updates game board
        static void MakeMove(string userInput, string[] buttons, string currentPlayer)
        {
            int move = int.Parse(userInput);
            buttons[move - 1] = currentPlayer;//The player declares into index, so the number will be changed and be replaced with either x/o
        }


        static void DisplayBoard(string[] buttons)
        {
            Console.WriteLine($"{buttons[0]}|{buttons[1]}|{buttons[2]}");
            Console.WriteLine("--+--+--");
            Console.WriteLine($"{buttons[3]}|{buttons[4]}|{buttons[5]}");
            Console.WriteLine("--+--+--");
            Console.WriteLine($"{buttons[6]}|{buttons[7]}|{buttons[8]}");
        }

        //Checks if there's a winner
        static bool CheckWinner(string[] buttons, string player)
        {
            int[][] winningCombinations = new int[][] //Jagged array = creates multiple new arrays with different elements
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

            foreach (var combo in winningCombinations)//loops trough the array
            {
                if (buttons[combo[0]] == player && buttons[combo[1]] == player && buttons[combo[2]] == player) //Checks if there's any win-combo
                {
                    return true;
                }
            }
            return false;
        }
    }
}
