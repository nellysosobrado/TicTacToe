namespace TicTacToe_Game_GroupProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TIC TAC TOE"); //title

            //Variables, to store data inside
            string player1 = "x";
            string player2 = "o";
            string currentPlayer = player1; //variable to change 

            //Displays the GameBoard, buttons 
            string button1 = "7";
            string button2 = "8";
            string button3 = "9";
            string button4 = "4";
            string button5 = "5";
            string button6 = "6";
            string button7 = "1";
            string button8 = "2";
            string button9 = "3";

            Console.WriteLine();
            Console.WriteLine($"{button1}|{button2}|{button3}|");
            Console.WriteLine($"______");
            Console.WriteLine($"{button4}|{button5}|{button6}|");
            Console.WriteLine($"______");
            Console.WriteLine($"{button7}|{button8}|{button9}|");

            //List, to keep track of players choises(inputs)
            List<string> playerHistory = new List<string>(); //Empty string list

            int gameCounter = 0;//Keeps track of rounds being played

            for (int i = 0; i <= 9; i++) //Loops only 9 times because there's only 9 buttons
            {
                gameCounter++;

                if (i == 9) //Checks if all 9 buttons has been used
                {
                    Console.WriteLine("9 rounds has been played");
                    Console.ReadKey();

                }

                // Display the current game board
                //each button is a variable, so it's changable depending on which player is playing
                Console.Clear();
                Console.WriteLine($"{button1}|{button2}|{button3}");
                Console.WriteLine($"_____");
                Console.WriteLine($"{button4}|{button5}|{button6}");
                Console.WriteLine($"_____");
                Console.WriteLine($"{button7}|{button8}|{button9}");


                // Display the current player’s turn
                Console.WriteLine($"\nGame Counter: {gameCounter}");
                Console.WriteLine($"\nPlayer {currentPlayer}'s turn");
                Console.WriteLine("Select a number from 1 through 9:");

                //User input
                Console.Write("\nChoice:");
                string userinput = Console.ReadLine();

                //checks if input has bgeen choosen before
                if (playerHistory.Contains(userinput))
                {
                    Console.WriteLine($"'{userinput}' has already been taken. Try again");
                    gameCounter--; //Removes the turn
                    continue;
                }

                playerHistory.Add(userinput);//User inputs being added into the last



                Console.WriteLine();
                //Switch, checks user input depending on which number they submited
                switch (userinput)
                {
                    case "1":
                        button7 = currentPlayer;
                        break;
                    case "2":
                        button8 = currentPlayer;
                        break;
                    case "3":
                        button9 = currentPlayer;
                        break;
                    case "4":
                        button4 = currentPlayer;
                        break;
                    case "5":
                        button5 = currentPlayer;
                        break;
                    case "6":
                        button6 = currentPlayer;
                        break;
                    case "7":
                        button1 = currentPlayer;
                        break;
                    case "8":
                        button2 = currentPlayer;
                        break;
                    case "9":
                        button3 = currentPlayer;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number, between 1-9");
                        i--; //removes the counting, so it doesnt show as a turn
                        continue;

                }//End of switch


                //If-statements, taking care of who's turns it is
                if (currentPlayer == player1)
                {
                    currentPlayer = player2;
                }
                else
                {
                    currentPlayer = player1;
                }


            }//End of for-loop

        }
    }
}
