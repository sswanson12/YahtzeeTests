namespace YahtzeeWithNUnit.Models;

public class Die
{
    private const int NumSides = 6;

    public int RollDie()
    {
        return new Random().Next(1, NumSides + 1);
    }
}