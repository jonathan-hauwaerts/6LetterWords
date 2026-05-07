using System;
using System.Collections.Generic;
using System.Text;

namespace _6LetterWords.Services
{
    public static class DocumentReaderService
    {
        public static string[] Readfile(string fileName)
        {
            string[] words = Array.Empty<string>();

            if (File.Exists($"Documents\\{fileName}"))
            {
                words = File.ReadAllLines($"Documents\\{fileName}").ToArray();
            }

            return words;
        }
    }
}
