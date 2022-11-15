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

        game.RankRoll(game.Dice);
    }
    
    
    //Four of a kind
    
    
    //Three of a kind
    
    
    //Full house (Three of a kind, plus a pair of another kind)
    
    
    //Two pair
    
    
    //One pair
    
    
    //One of a kind
}