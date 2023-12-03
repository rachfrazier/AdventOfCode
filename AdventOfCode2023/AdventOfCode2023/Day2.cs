namespace AdventOfCode2023;

internal record SetOfCubes(int Red, int Green, int Blue);

public static class Day2
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;

    public static int SumIDsOfValidGames(List<string> input)
    {
        int sum = 0;
        foreach (string line in input)
        {
            string[] splitOnColon = line.Split(':');
            int gameID = int.Parse(splitOnColon[0].Split(' ')[1]);
            string[] setsOfCubes = splitOnColon[1].Split(';');
            if (IsSetsOfCubesPossible(setsOfCubes))
            {
                sum += gameID;
            }
        }

        return sum;
    }

    internal static List<SetOfCubes> GetMinPossibleSetOfCubesPerGame(List<string> input)
    {
        List<SetOfCubes> minSets = new();
        foreach (string line in input)
        {
            string[] splitOnColon = line.Split(':');
            string[] setsOfCubes = splitOnColon[1].Split(';');
            minSets.Add(GetMinPossibleSetOfCubes(setsOfCubes));
        }

        return minSets;
    }

    private static bool IsSetsOfCubesPossible(string[] setsOfCubes)
    {
        foreach (string set in setsOfCubes)
        {
            string[] cubes = set.Split(',');
            foreach (string cube in cubes)
            {
                string[] numberToColor = cube.Trim().Split(' ');
                if (int.Parse(numberToColor[0]) > GetMaxPossibleGivenColor(numberToColor[1]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static SetOfCubes GetMinPossibleSetOfCubes(string[] setsOfCubes)
    {
        Dictionary<string, int> minNumOfCubes = new Dictionary<string, int>
        {
            { "red", int.MinValue },
            { "green", int.MinValue },
            { "blue", int.MinValue }
        };

        foreach (string set in setsOfCubes)
        {
            string[] cubes = set.Split(',');
            foreach (string cube in cubes)
            {
                string[] numberToColor = cube.Trim().Split(' ');
                int numberValOfCube = int.Parse(numberToColor[0]);
                minNumOfCubes[numberToColor[1]] = 
                    Math.Max(numberValOfCube, minNumOfCubes[numberToColor[1]]);
            }
        }

        ZeroOutAnyMinValues(minNumOfCubes);
        return new SetOfCubes(minNumOfCubes["red"], minNumOfCubes["green"], minNumOfCubes["blue"]);
    }

    private static void ZeroOutAnyMinValues(Dictionary<string, int> minNumOfCubes)
    {
        foreach (KeyValuePair<string, int> kvp in minNumOfCubes)
        {
            if (kvp.Value == int.MinValue)
            {
                minNumOfCubes[kvp.Key] = 0;

            }
        }
    }

    private static int GetMaxPossibleGivenColor(string color) =>
        color switch
        {
            "red" => MaxRed,
            "green" => MaxGreen,
            "blue" => MaxBlue,
            _ => throw new InvalidOperationException("Unexpected color value")
        };
}
