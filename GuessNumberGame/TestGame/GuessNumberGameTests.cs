using GuessNumberGameNet6;
using System;
using GuessNumberGameNet6.Services;
using NUnit.Framework;

namespace TestGame;

public class GuessNumberGameTests
{
    readonly GuessNumberGame gm = new();

    [Test]
    public void MatchingInput_MessageIsHeight()
    {
        Assert.AreEqual(gm.MatchingInput(0), GuessNumberGameResult.Height); 
    }

    [Test]

    public void MatchingInput_MessageIsLess()
    {
        Assert.AreEqual(gm.MatchingInput(101), GuessNumberGameResult.Less);
    }

    [Test]

    public void MatchingInput_MessageIsEqual()
    {
        gm.RandomNumber = 47;

        Assert.AreEqual(gm.MatchingInput(47), GuessNumberGameResult.Equal);
    }
}