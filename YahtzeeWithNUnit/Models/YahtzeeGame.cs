﻿namespace YahtzeeWithNUnit.Models;

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

        /*if (IsFourOfAKind(dice))
        {
            return "Four of a kind";
        }
        
        if (IsThreeOfAKind(dice))
        {
            return "Three of a kind";
        }
        
        if (IsFullHouse(dice))
        {
            return "Full House";
        }
        
        if (IsTwoPair(dice))
        {
            return "Two Pair";
        }
        
        if (IsOnePair(dice))
        {
            return "One Pair";
        }
        
        if (IsOneOfAKind(dice))
        {
            return "One of a kind";
        }*/

        throw new InvalidDataException("Couldn't Rank Dice");
    }

    private bool IsYahtzee(Die[] dice)
    {
        return dice.All(die => die.CurrentFace.Equals(dice[0].CurrentFace));
    }

    private bool IsFourOfAKind(Die[] dice)
    {
        throw new NotImplementedException();
    }
    
    private bool IsThreeOfAKind(Die[] dice)
    {
        throw new NotImplementedException();
    }
    
    private bool IsFullHouse(Die[] dice)
    {
        throw new NotImplementedException();
    }
    
    private bool IsTwoPair(Die[] dice)
    {
        throw new NotImplementedException();
    }
    
    private bool IsOnePair(Die[] dice)
    {
        throw new NotImplementedException();
    }
    
    private bool IsOneOfAKind(Die[] dice)
    {
        throw new NotImplementedException();
    }
}