using _6LetterWords.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6LetterWords.Extensions
{
    public static class ConsoleExtension
    {
        public static void WriteLine(string message) 
        { 
            Console.WriteLine(message);
            WordLogger.WriteLine(message);
        }
    }
}
