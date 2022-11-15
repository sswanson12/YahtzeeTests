namespace YahtzeeWithNUnit.Models;

public class Die
{
    private const int NumSides = 6;
    
    public int CurrentFace { get; set; }

    public void RollDie()
    {
        CurrentFace = new Random().Next(1, NumSides + 1);
    }
}