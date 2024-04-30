using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp
{
    public class Board
    {
        private readonly List<string> _words;
        private string _word;
        private string _wordUpCase;

        private readonly HashSet<char> _guessedLetters;
        private readonly HashSet<char> _enteredLetters;
        private readonly Random _rnd;

        public Board(string path)
        {
            _rnd = new Random();
            _guessedLetters = new HashSet<char>();
            _enteredLetters = new HashSet<char>();
            _words = new List<string>();

            ResourceLoader.LoadWords(path, ref _words);
        }

        public void NextWord()
        {
            var index = _rnd.Next() % _words.Count;
            _word = _words[index];
            _wordUpCase = _word.ToUpper();
        }

        public bool Check(char letter, out bool repeat)
        {
            repeat = false;

            var letterUp = char.ToUpper(letter);
            if (_enteredLetters.Contains(letterUp))
            {
                repeat = true;
                return true;
            }

            _enteredLetters.Add(letterUp);

            if (!_wordUpCase.Contains(letterUp))
            {
                return false;
            }

            _guessedLetters.Add(letterUp);
            return true;
        }

        public string GetWord()
        {
            var result = new StringBuilder();
            foreach (var c in _word)
            {
                var guessed = _guessedLetters.Contains(char.ToUpper(c));
                result.Append(guessed ? c.ToString() : ".");
            }

            return result.ToString();
        }

        public string RevealWord => _word;

        public bool Completed()
        {
            var count = _wordUpCase.Count(letter => _guessedLetters.Contains(letter));
            return count == _wordUpCase.Length;
        }

        public void Restore()
        {
            _enteredLetters.Clear();
            _guessedLetters.Clear();
        }
    }
}