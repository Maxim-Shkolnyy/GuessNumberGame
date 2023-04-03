using GuessNumberGameNet6.Interfaces;

namespace GuessNumberGameNet6.Services;

public class Validator : IValidator
{
    public bool ParseInputAsInt(string input, out int inputNumber)
    {
        return int.TryParse(input, out inputNumber);
    }
}