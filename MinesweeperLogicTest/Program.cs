using MinesweeperBackend;
namespace MinesweeperLogicTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minesweeper Logic test");
            MinesweeperBackend.Minesweeper ms = new MinesweeperBackend.Minesweeper(10,10);
        }
    }
}