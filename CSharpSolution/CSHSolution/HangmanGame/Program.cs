using System;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the HangMan Game!");
            HangmanGame game = new HangmanGame();

            string word = game.GenerateWord();

            Console.WriteLine($"the word consists of {word.Length} letters");
            Console.WriteLine("Try to guess the word in Russian Language");
            Console.WriteLine("Press any Key to Start the Game");
            Console.ReadLine();

            while (game.GameStatus == GameStatus.InProgress)
            {
                //Console.Clear();
                Console.WriteLine("Pick a Letter");
                char c = Console.ReadLine().ToCharArray()[0];

                string curState = game.GuessLetter(c);
                Console.WriteLine("****************\nGuessing word:");
                Console.WriteLine(curState);

                Console.WriteLine($"Remaining tries = {game.RemainingTries}");
                Console.WriteLine($"Tried letters: {game.TriedLetters}");
                //Console.WriteLine("****************\nGuessing word:");

            }

            if (game.GameStatus == GameStatus.Lost)
            {
                Console.WriteLine($"You are hanged.\nThe word was: {game.Word}");
            }
            else if (game.GameStatus == GameStatus.Won)
            {
                Console.WriteLine("\n###################");
                Console.WriteLine("#You Won! Congrats#");
                Console.WriteLine("###################");
            }

            Console.ReadKey();
        }
    }
}
