namespace YahtzeeWithNUnit.Models;

public class YahtzeeGame
{
    private const int NumberOfDice = 5;

    private int _currentPlayer = 0;

    public Die[] Dice { get; } = new Die[NumberOfDice];
    
    private List<Player> _players;


    public YahtzeeGame(List<Player> players)
    {
        for (var i = 0; i < NumberOfDice; i++)
        {
            Dice[i] = new Die();
        }

        _players = players;
    }

    public string RankRoll(Die[] dice)
    {
        if (IsYahtzee(dice))
        {
            return "Yahtzee";
        }

        if (IsFourOfAKind(dice))
        {
            return "Four of a kind";
        }
                
        if (IsFullHouse(dice))
        {
            return "Full House";
        }
        
        if (IsThreeOfAKind(dice))
        {
            return "Three of a kind";
        }

        if (IsTwoPair(dice))
        {
            return "Two pair";
        }
        
        if (IsOnePair(dice))
        {
            return "One pair";
        }
        
        if (IsOneOfAKind(dice))
        {
            return "One of a kind";
        }

        throw new InvalidDataException("Couldn't Rank Dice");
    }

    private bool IsYahtzee(Die[] dice)
    {
        return dice.All(die => die.CurrentFace.Equals(dice[0].CurrentFace));
    }

    private bool IsFourOfAKind(Die[] dice)
    {
        var matchingList = dice.Where(die => die.CurrentFace == dice[0].CurrentFace).ToList();

        return matchingList.Count >= 4;
    }
    
    private bool IsFullHouse(Die[] dice)
    {
        var matchingList = dice.Where(die => die.CurrentFace == dice[0].CurrentFace).ToList();

        var otherList = dice.ToList().Except(matchingList).ToList();

        return matchingList.Count == 3 && otherList.All(die => die.CurrentFace.Equals(otherList[0].CurrentFace));
    }
    
    private bool IsThreeOfAKind(Die[] dice)
    {
        var matchingList = dice.Where(die => die.CurrentFace == dice[0].CurrentFace).ToList();

        var otherList = dice.ToList().Except(matchingList).ToList();

        return matchingList.Count == 3 && !otherList.All(die => die.CurrentFace.Equals(otherList[0].CurrentFace));
    }

    private bool IsTwoPair(Die[] dice)
    {
        var matchingList = dice.Where(die => die.CurrentFace == dice[0].CurrentFace).ToList();

        var otherMatchingList = dice.Except(matchingList)
            .Where(die => die.CurrentFace.Equals(dice.Except(matchingList).ToList()[0].CurrentFace)).ToList();

        return matchingList.Count == 2 && otherMatchingList.Count == 2;
    }
    
    private bool IsOnePair(Die[] dice)
    {
        var matchingList = dice.Where(die => die.CurrentFace == dice[0].CurrentFace).ToList();
        
        return matchingList.Count == 2;
    }
    
    private bool IsOneOfAKind(Die[] dice)
    {
        var matchingList = dice.Where(die => die.CurrentFace == dice[0].CurrentFace).ToList();

        return matchingList.Count <= 1;
    }
}