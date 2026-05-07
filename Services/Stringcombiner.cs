using _6LetterWords.Interfaces;
using System.Numerics;

namespace _6LetterWords.Services
{
    public class Stringcombiner : IStringCombiner
    {
        string[] _fileStrings = Array.Empty<string>();
        List<string> _alreadyPrinted;
        int _maxLetters;
        int _line = 0;

        public Stringcombiner(string[] fileStrings,int maxLetters)
        {
               _fileStrings = fileStrings;
            _alreadyPrinted = new List<string>();
            _maxLetters = maxLetters;
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
            List<string> validWords = new List<string>();
            validWords = _fileStrings.Where(x => x.Length + part.Length <= _maxLetters && !_alreadyPrinted.Contains(x)).ToList();

            for (int x = 0; x < validWords.Count; x++)
            {
                string word = part + validWords[x];
                string word2 = validWords[x] + part;

                if (validWords.Contains(word) && !_alreadyPrinted.Contains(word))
                {
                    _line++;
                    PrintService.print(part, validWords[x], word, _line);
                    _alreadyPrinted.Add(word);

                    if (_fileStrings.Contains(word) && word.Length < _maxLetters)
                    {
                        ValidWords(word);
                    }
                    if (_fileStrings.Contains(word2) && word2.Length < _maxLetters)
                    {
                        ValidWords(word2);
                    }
                }
            }
        }
    }
}
