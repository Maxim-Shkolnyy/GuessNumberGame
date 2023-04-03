namespace GuessNumberGameNet6.Interfaces;

public interface IValidator
{
    public bool ParseInputAsInt(string input, out int inputNumber);
}