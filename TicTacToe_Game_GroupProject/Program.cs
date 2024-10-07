
namespace TicTacToe_Game_GroupProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Visa första sidan
            FirstPage startPage = new FirstPage();
            startPage.Display();

            // Skapa en instans av Meny-klassen och visa menyn
            Menu menu = new Menu();
            menu.ShowMenu();

        }
    }
}
