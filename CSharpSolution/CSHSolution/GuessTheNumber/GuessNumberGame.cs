using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber
{

    public enum GuessingPlayer
    {
        Human,
        Machine
    }

    public class GuessNumberGame
    {
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayer guessingPlayer;

        public GuessNumberGame(int max = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessingPlayer = guessingPlayer;
        }

        public void Start()
        {
            if (guessingPlayer==GuessingPlayer.Human)
            {
                HumanGuesses();
            }
            else
            {
                MachineGuesses();
            }
        }

        private void HumanGuesses()
        {
            Random rand = new Random();
            int guessedNumber = rand.Next(0, max);

            int lastGuess = -1;
            int tries = 0;
            
            while(lastGuess!=guessedNumber && tries < maxTries)
            {
                Console.WriteLine("Guess the Number: ");
                lastGuess = int.Parse(Console.ReadLine());
                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("AWESOME! You Won!");
                    break;
                }
                else if (lastGuess < guessedNumber)
                {
                    Console.WriteLine("Almost. But my number is greater!");
                }
                else
                {
                    Console.WriteLine("Almost. But my number is less!");
                }

                tries++;

                if (tries == maxTries)
                {
                    Console.WriteLine("Sorry. You lost!\nGAME OVER");
                }
            }
        }

        private void MachineGuesses()
        {
            Console.WriteLine("Enter a Number that is going to be guessed by a computer");

            int guessedNumber = -1;
            while (guessedNumber == -1)
            {
                int parsedNumber = int.Parse(Console.ReadLine());
                if (parsedNumber >= 0 && parsedNumber <= this.max)
                {
                    guessedNumber = parsedNumber;
                }
            }

            int lastGuess = -1;
            int min = 0;
            int max = this.max;
            int tries = 0;

            while (lastGuess != guessedNumber && tries < maxTries)
            {
                lastGuess = (min + max) / 2;
                Console.WriteLine($"DId you guess this number - {lastGuess}?");
                Console.WriteLine("Y - Yes \nG - Your number is greater \nL - Your number is less");

                string answer = Console.ReadLine();

                if (answer=="Y" || answer=="y")
                {
                    Console.WriteLine("Great! I won!");
                    break;
                }

                else if (answer=="G" || answer=="g")
                {
                    min = lastGuess;
                }
                else
                {
                    max = lastGuess;
                }

                if(lastGuess==guessedNumber)
                {
                    Console.WriteLine("Do not cheat buddy :)\nI won");
                }

                tries++;
                if (tries==maxTries)
                {
                    Console.WriteLine("Oops, no tries anymore. I lost. \nThank you for the game");
                }
            }

        }
    }
}
