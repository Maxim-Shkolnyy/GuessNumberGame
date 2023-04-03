using GuessNumberGameNet6.Interfaces;
using GuessNumberGameNet6.Services;

namespace GuessNumberGameNet6;

public class GameManager
{
        
    private readonly IConsoleIo _consoleIo;
    private readonly IValidator _number;

    GuessNumberGame _guessNumberGame;

    public GameManager(IConsoleIo console, IValidator number)
    {
        this._consoleIo = console ?? throw new ArgumentNullException(nameof(console));
        this._number = number ?? throw new ArgumentNullException(nameof(number));
    }

    public void DoWork()
    {
        for (;;)
        {
            _guessNumberGame = new GuessNumberGame();
            _consoleIo.WriteLine(Messages.UserInput);

            for (;;)
            {
                int userNumber = ParsingInput();

                if (IsInputGuessed(userNumber))
                {
                    break;
                }
            }

            if (PlayAgain())
            {
                continue;
            }
            break;
        }
    }

    private void ConsoleMessages(GuessNumberGameResult res)
    {
        if (res != GuessNumberGameResult.Equal)
        {
            if (res == GuessNumberGameResult.Less)
                _consoleIo.WriteLine(Messages.NoEnterLesser);

            if (res == GuessNumberGameResult.Height)
                _consoleIo.WriteLine(Messages.NoEnterGreater);

            return;
        }
        _consoleIo.WriteLine(Messages.YouWin);
    }

    private int ParsingInput()
    {
        for (;;)
        {
            string userInput = _consoleIo.ReadLine();

            int userNumber;

            if (_number.ParseInputAsInt(userInput, out userNumber))
            {
                return userNumber;
            }
            _consoleIo.WriteLine(Messages.InputError);
        }
    }

    private bool PlayAgain()
    { 
        _consoleIo.WriteLine(Messages.PlayAgain);
        string input = _consoleIo.ReadLine();

        if (int.TryParse(input, out int d) & d == 1)
        {
            return true;
        }
        return false;
    }

    private bool IsInputGuessed(int userNumber)
    {
        var res = _guessNumberGame.MatchingInput(userNumber);

        ConsoleMessages(res);
        if (res == GuessNumberGameResult.Equal)
        {
            return true;
        }
        return false;
    }
}