
using _6LetterWords.Services;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//string[] files = config.GetSection("WordFile");
var files = config.GetSection("WordFile").Get<List<string>>();
int maxLetters = config.GetSection("MaxLetters").Get<int>();

foreach(string file in files)
{
    string[] words = DocumentReaderService.Readfile(file);

    Stringcombiner stringcombiner = new Stringcombiner(words,maxLetters);

    stringcombiner.PrintCombinations();
}

Console.WriteLine("End of application");
Console.ReadLine();