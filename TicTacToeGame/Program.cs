using System;
using System.Text;
using TDD_UnitTest.TicTacToe;

namespace TicTacToeGame
{
    class Program
    {
        private static Game game = new Game();

        static void Main(string[] args)
        {
            Console.WriteLine(GetPrintableState());

            while(game.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                game.MakeMove(index);

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }
            Console.WriteLine(game.ToString());
            Console.Read();
        }

        private static string GetPrintableState()
        {
            var sb = new StringBuilder();

            sb.AppendLine("______________________");
            for (int i = 1; i <= 7; i+= 3)
            {
                sb.AppendLine("      |       |       |");
                sb.AppendLine($"  {GetPrintableChar(i)}   |   {GetPrintableChar(i + 1)}   |   {GetPrintableChar(i + 2)}   |");
                sb.AppendLine("______|_______|_______|");
            }
            return sb.ToString();
        }

        private static object GetPrintableChar(int index)
        {
            State state = game.GetState(index);
            if (state == State.Unset) return index.ToString();
            return state == State.Cross ? "X" : "O";
        }
    }
}
