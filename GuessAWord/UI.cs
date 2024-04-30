using System;

namespace MyApp
{
    public static class UI
    {
        public static void ShowStartDialog()
        {
            Console.WriteLine();
            Console.WriteLine("[1] - Start");
            Console.WriteLine("[2] - Exit");
            Console.WriteLine("-----------");
        }

        public static void ShowGuessDialog()
        {
            Console.WriteLine("Enter a character");
        }

        public static void ShowStartWordInfo(string word, Health health)
        {
            Console.Clear();
            new Graphics().Show(health);
            Console.WriteLine($"Somebody wants to eat your pizza! To save your food try to guess this [{word}] word. You have {health.Value} tries");
        }

        public static void ShowWordInfo(string word, Health health, bool guessed = false)
        {
            Console.Clear();
            new Graphics().Show(health);
            Console.WriteLine($"{(guessed ? "Correct!" : "No such character in the word")} [{word}] tries left {health.Value}");
            
        }
        
        public static void ShowRepeatLetter(char letter, string word, Health health)
        {
            Console.Clear();
            new Graphics().Show(health);
            Console.WriteLine($"'{letter}' has already been entered. [{word}] tries left {health.Value}");
        }

        public static void ShowFail(string word, Health health)
        {
            Console.Clear();
            new Graphics().Show(health);
            Console.WriteLine($"Game over! The hidden word was [{word}] Try again ?");
        }

        public static void ShowSuccess(string word)
        {
            Console.WriteLine($"Win! You guessed a word: [{word}]");
        }
    }
}