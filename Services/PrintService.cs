using _6LetterWords.Extensions;
using Serilog;


namespace _6LetterWords.Services
{
    public static class PrintService
    {
        public static void print(string firstWord, string secondWord, string result, int line)
        {
			try
			{
                ConsoleExtension.WriteLine($"{line.ToString()}: {firstWord} + {secondWord} = {result}");
            }
			catch (Exception ex)
			{
                Log.Error(ex.Message, ex);
			}   
        }
    }
}
