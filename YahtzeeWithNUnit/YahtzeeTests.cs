using NUnit.Framework;
using YahtzeeWithNUnit.Models;

namespace YahtzeeWithNUnit;

[TestFixture]
public class YahtzeeTests
{
    public YahtzeeGame Setup()
    {
        List<Player> players = new List<Player>();
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


    //Two pair
    
    
    //One pair
    
    
    //One of a kind
}