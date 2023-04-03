using GuessNumberGameNet6;
using GuessNumberGameNet6.Interfaces;
using GuessNumberGameNet6.Services;
using NUnit.Framework;
using Moq;

namespace TestGame;

public class GameManagerTests
{
    private readonly GameManager _manager;
    private readonly Mock<IConsoleIo> _communicationMock = new();
    private readonly Mock<IValidator> _validatorMock = new();

    private int UserNumber = 50;
    private string LastWrite = null;

    public GameManagerTests()
    {
        this._manager = new GameManager(this._communicationMock.Object, _validatorMock.Object);
    }

    private void ProcessWrite(string input)
    {
        LastWrite = input;
    }

    private string ProcessRead()
    {
        if (LastWrite == Messages.UserInput)
        {
            return UserNumber.ToString();
        }
        
        if (LastWrite == Messages.NoEnterLesser)
        {
            UserNumber--;
            return UserNumber.ToString();
        }

        if (LastWrite == Messages.NoEnterGreater)
        {
            UserNumber++;
            return UserNumber.ToString();
        }

        return "";
    }

    [Test, Timeout(2000)]
    public void DoWork_AskUserInput_ReturnedYouWin() 
    {

        int UserNumberDummy;
       
        this._validatorMock.Setup(x => x.ParseInputAsInt(It.IsAny<string>(), out UserNumberDummy))
            .Returns((string input, out int UserNumber) => int.TryParse(input, out UserNumber));
        
        this._communicationMock.Setup(x => x.WriteLine(It.IsAny<object>()))
            .Callback((object input) => ProcessWrite((string)input));

        this._communicationMock.Setup(x => x.ReadLine())
            .Returns(() => ProcessRead());

        this._manager.DoWork();


        this._validatorMock.Verify(x => x.ParseInputAsInt(It.IsAny<string>(), out UserNumberDummy), Times.AtLeastOnce);

        this._communicationMock.Verify(x => x.WriteLine(Messages.UserInput), Times.AtLeastOnce);
        this._communicationMock.Verify(x => x.WriteLine(Messages.YouWin), Times.AtLeastOnce);
        this._communicationMock.Verify(x => x.WriteLine(Messages.PlayAgain), Times.AtLeastOnce);

    }
}