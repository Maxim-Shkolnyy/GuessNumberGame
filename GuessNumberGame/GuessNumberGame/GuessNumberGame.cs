using GuessNumberGameNet6.Services;

namespace GuessNumberGameNet6;

public class GuessNumberGame
{
    public int RandomNumber { get; set; }
    public int UserNumber { get; set; }

    public GuessNumberGame()
    {
        RandomNumber = DoRandom();
    }

    public GuessNumberGameResult MatchingInput(int userInput)
    {
        if (RandomNumber == userInput)
        {
            return GuessNumberGameResult.Equal;
        }

        if (userInput < RandomNumber)
        {
            return GuessNumberGameResult.Height;
        }
        return GuessNumberGameResult.Less;
    }

    private int DoRandom()
    {
        Random rnd = new Random();
        int random = rnd.Next(1, 101);
        return random;
    }
}