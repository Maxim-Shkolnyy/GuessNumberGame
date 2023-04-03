using GuessNumberGameNet6.Services;

namespace GuessNumberGameNet6;

internal class Program
{
    static void Main(string[] args)
    {
        GameManager gm = new GameManager(new ConsoleIo(), new Validator());
        gm.DoWork();
    }
}