using System;
using System.Collections.Generic;
using System.Text;

namespace _6LetterWords.Services
{
    public static class PrintService
    {
        public static void print(string firstWord, string secondWord, string result, int line)
        {
            Console.WriteLine($"{line.ToString()}: {firstWord} + {secondWord} = {result}");
        }
    }
}
