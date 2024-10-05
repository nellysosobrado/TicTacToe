
namespace TicTacToe_Game_GroupProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FirstPage Start=new FirstPage();
            Start.Display();

            // Skapa en instans av Game-klassen och starta spelet
            Menu game = new Menu();
            game.ShowMenu(); // Anropa spelets Start-metod
        }

        
    }
}
