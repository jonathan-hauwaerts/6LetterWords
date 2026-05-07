
using _6LetterWords.Logger;
using _6LetterWords.Services;
using Microsoft.Extensions.Configuration;
using Serilog;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var log = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

//string[] files = config.GetSection("WordFile");
var files = config.GetSection("WordFile").Get<List<string>>();
int maxLetters = config.GetSection("MaxLetters").Get<int>();

foreach(string file in files)
{
    string[] words = Array.Empty<string>();
    try
    {
        words = DocumentReaderService.Readfile(file);
    }catch(Exception ex)
    {
        log.Error(ex.Message);
    }
    

    StringcombinerService stringcombiner = new StringcombinerService(words,maxLetters);

    stringcombiner.PrintCombinations();
}
try
{
    WordLogger.save();
}catch(Exception ex)
{
    log.Error(ex.Message);
}
Console.WriteLine("End of application");
Console.ReadLine();