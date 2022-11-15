using NUnit.Framework;
using YahtzeeWithNUnit.Models;

namespace YahtzeeWithNUnit;

[TestFixture]
public class YahtzeeTests
{
    private static YahtzeeGame Setup()
    {
        var players = new List<Player>();
        players.Add(new Player("TestPlayer1"));
        players.Add(new Player("TestPlayer2"));

        return new YahtzeeGame(players);
    }

    //Yahtzee
    [Test]
    public void YahtzeeTest()
    {
        var game = Setup();

        foreach (var die in game.Dice)
        {
            die.CurrentFace = 5;
        }

        Assert.AreEqual("Yahtzee", game.RankRoll(game.Dice));
    }
    
    
    //Four of a kind
    [Test]
    public void FourOfAKindTest()
    {
        var game = Setup();

        game.Dice[0].CurrentFace = 4;
        game.Dice[1].CurrentFace = 4;
        game.Dice[2].CurrentFace = 4;
        game.Dice[3].CurrentFace = 4;
        game.Dice[4].CurrentFace = 5;

        Assert.AreEqual("Four of a kind", game.RankRoll(game.Dice));
    }
    
    //Full house (Three of a kind, plus a pair of another kind)
    [Test]
    public void FullHouseTest()
    {
        var game = Setup();

        game.Dice[0].CurrentFace = 4;
        game.Dice[1].CurrentFace = 4;
        game.Dice[2].CurrentFace = 4;
        game.Dice[3].CurrentFace = 5;
        game.Dice[4].CurrentFace = 5;

        Assert.AreEqual("Full House", game.RankRoll(game.Dice));
    }
    
    //Three of a kind
    [Test]
    public void ThreeOfAKindTest()
    {
        var game = Setup();

        game.Dice[0].CurrentFace = 4;
        game.Dice[1].CurrentFace = 4;
        game.Dice[2].CurrentFace = 4;
        game.Dice[3].CurrentFace = 5;
        game.Dice[4].CurrentFace = 3;

        Assert.AreEqual("Three of a kind", game.RankRoll(game.Dice));
    }

    //Two pair
    [Test]
    public void TwoPairTest()
    {
        var game = Setup();

        game.Dice[0].CurrentFace = 4;
        game.Dice[1].CurrentFace = 4;
        game.Dice[2].CurrentFace = 5;
        game.Dice[3].CurrentFace = 5;
        game.Dice[4].CurrentFace = 3;

        Assert.AreEqual("Two pair", game.RankRoll(game.Dice));
    }
    
    //One pair
    [Test]
    public void OnePairTest()
    {
        var game = Setup();

        game.Dice[0].CurrentFace = 4;
        game.Dice[1].CurrentFace = 4;
        game.Dice[2].CurrentFace = 3;
        game.Dice[3].CurrentFace = 2;
        game.Dice[4].CurrentFace = 1;

        Assert.AreEqual("One pair", game.RankRoll(game.Dice));
    }
    
    //One of a kind
    [Test]
    public void OneOfAKindTest()
    {
        var game = Setup();

        game.Dice[0].CurrentFace = 5;
        game.Dice[1].CurrentFace = 4;
        game.Dice[2].CurrentFace = 3;
        game.Dice[3].CurrentFace = 2;
        game.Dice[4].CurrentFace = 1;

        Assert.AreEqual("One of a kind", game.RankRoll(game.Dice));
    }
}