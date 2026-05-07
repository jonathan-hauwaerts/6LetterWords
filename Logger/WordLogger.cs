using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6LetterWords.Logger
{
    public static class WordLogger
    {
        private static List<string> _lines = new List<string>();
        public static void WriteLine(string message)
        {
            _lines.Add(message);
        }

        public static void save()
        {
            try
            {
                string path = $"Logs/{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-WordLogs.txt";
                File.WriteAllLines(path, _lines);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            
        }
    }
}
