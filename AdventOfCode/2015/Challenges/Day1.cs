namespace AdventOfCode2015;

public record FloorCalculator(string PuzzleText)
{
    private const char GoUp = '(';
    private const char GoDown = ')';
    private const int BasementFloor = -1;

    public int CalculateFinalFloor() =>
        this.PuzzleText.Count(c => c == GoUp) - this.PuzzleText.Count(c => c == GoDown) ;

    public int FindFirstBasementVisitPosition()
    {
        int currentFloor = 0;
        for (int i = 0; i < PuzzleText.Length; ++i)
        {
            if (PuzzleText[i] == GoUp)
                ++currentFloor;
            else
                --currentFloor;

            if (currentFloor == BasementFloor)
            {
                return i + 1;
            }
        }

        throw new Exception("Basement floor not reached");
    }
}
