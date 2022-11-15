namespace YahtzeeWithNUnit.Models;

public class Player
{
    public Player(string name)
    {
        Name = name;
    }

    private int Score { get; set; }
    
    private string Name { get; }
}