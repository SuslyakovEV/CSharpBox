using System;
using System.Text;

namespace TicTacToeGame
{
    class Program
    {
        private static TicTacToeGame g = new TicTacToeGame();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tic Tac Toe Game\nPlease select index to set X, then select index to set O\n");
            Console.WriteLine(GetPrintableState());

            while (g.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Result : The Winner is {g.GetWinner()}");
            Console.ReadKey();

        }

        static string GetPrintableState()
        {
            var sb = new StringBuilder(); 
            for (int i=1; i<=7; i+=3)
            {
                sb.AppendLine("     |     |     |")
                    .AppendLine($"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  |")
                    .AppendLine("_____|_____|_____|");

            }

            return sb.ToString();
        }

        static string GetPrintableChar(int index)
        {
            State state = g.GetState(index);
            if (state == State.Unset)
                return index.ToString();

            return state == State.Cross ? "X" : "O";

        }
    }
}
  