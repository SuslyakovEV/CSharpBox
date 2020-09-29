using System;


namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who is gonna Play? \n1 - Human\n2 - Machine");
            int player = int.Parse(Console.ReadLine());

            Console.WriteLine("How many tries?");
            int tries = int.Parse(Console.ReadLine());

            GuessNumberGame game = new GuessNumberGame();

            switch (player)
            {
                case 1: game = new GuessNumberGame(maxTries: tries, guessingPlayer: GuessingPlayer.Human);
                    break;

                case 2: game = new GuessNumberGame(maxTries: tries, guessingPlayer: GuessingPlayer.Machine);
                    break;


            }
            
            Console.Clear();
            game.Start();


            Console.ReadKey();

        }
    } 
}
