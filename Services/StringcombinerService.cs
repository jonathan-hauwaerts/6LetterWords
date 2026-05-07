using _6LetterWords.Interfaces;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.Numerics;

namespace _6LetterWords.Services
{
    public class StringcombinerService : IStringCombiner
    {
        string[] _fileStrings = Array.Empty<string>();
        List<string> _alreadyPrinted;
        int _maxLetters;
        int _line = 0;
        List<string> _usedWords;

        public StringcombinerService(string[] fileStrings, int maxLetters)
        {
            _fileStrings = fileStrings;
            _alreadyPrinted = new List<string>();
            _maxLetters = maxLetters;
            _usedWords = new List<string>();
        }

        public void PrintCombinations()
        {
            for (int i = 0; i < _fileStrings.Length; i++)
            {
                ValidWords(_fileStrings[i]);
            }
        }
        private void ValidWords(string part)
        {
            List<string> validCombinations = new List<string>();
            validCombinations = _fileStrings.Where(x => x.Length + part.Length <= _maxLetters && !_alreadyPrinted.Contains(x) && x != part && !string.IsNullOrWhiteSpace(x)).ToList();

            for (int x = 0; x < validCombinations.Count; x++)
            {
                string word = "";
                word = part + validCombinations[x];

                var wordFound = _fileStrings.Any(x => x.StartsWith(word));

                PrintWord(part, validCombinations[x], word);
                _usedWords.Add(word);
                recursion(word);
            }
        }

        private void PrintWord(string part, string part2, string word)
        {
            if (_fileStrings.Contains(word) && !_alreadyPrinted.Contains(word))
            {
                _line++;
                PrintService.print(part,part2, word, _line);
                _alreadyPrinted.Add(word);
            }
        }

        private void recursion(string word)
        {
            if (_fileStrings.Any(x => x.StartsWith(word)) && word.Length < _maxLetters && !_alreadyPrinted.Contains(word) && !_usedWords.Contains(word))
            {
                ValidWords(word);
            }
        }
    }
}
