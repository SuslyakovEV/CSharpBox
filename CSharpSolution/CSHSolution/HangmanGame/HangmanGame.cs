using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HangmanGame
{
    public class HangmanGame
    {
        private readonly int allowedMisses;
        private bool[] openIndexes;
        private int triesCounter = 0;
        private string triedLetters;

        public GameStatus GameStatus { get; private set; } = GameStatus.NotStarted;

        public string Word { get; private set; }

        public string TriedLetters
        {
            get
            {
                var chars = triedLetters.ToCharArray();
                Array.Sort(chars);
                return new string(chars);
            }
        }

        public int RemainingTries
        { get
            {
                return allowedMisses - triesCounter;
            }
        }


        public HangmanGame(int allowedMisses = 6)
        {
            if(allowedMisses<5 || allowedMisses>8)
            {
                throw new ArgumentException("Number of allowed misses should be between 5 and 8");
                
            }

            this.allowedMisses = allowedMisses;
        }

        public string GenerateWord()
        {
            string[] words = File.ReadAllLines("WordsStockRus.txt");
            Random r = new Random(DateTime.Now.Millisecond);

            int randomIndex = r.Next(words.Length - 2);

            Word = words[randomIndex];

            openIndexes = new bool[Word.Length];

            GameStatus = GameStatus.InProgress;

            return Word;
        }

        public string GuessLetter(char letter)
        {
            if (triesCounter == allowedMisses)
            {
                throw new InvalidOperationException($"Exceeded the MAX misses number: {allowedMisses}");
            }

            if (GameStatus != GameStatus.InProgress)
            {
                throw new InvalidOperationException($"Inaproppriate status of the game: {GameStatus}");
            }

            bool openAny = false;
            string result = string.Empty;

            for (int i = 0; i<Word.Length; i++)
            {
                if (Word[i] == letter)
                {
                    openAny = true;
                    openIndexes[i] = true;
                }

                if (openIndexes[i])
                {
                    result += Word[i];
                }
                else
                {
                    result += "-";
                }
            }

            if (!openAny)
            {
                triesCounter++;
            }

            triedLetters += letter;

            if (IsWin())
            {
                GameStatus = GameStatus.Won;
            }
            else if(triesCounter==allowedMisses)
            {
                GameStatus = GameStatus.Lost;
            }

            return result;

        }

        private bool IsWin()
        {
            foreach (var cur in openIndexes)
            {
                if (cur == false)
                    return false;

            }
            return true;
        }
    }
}
