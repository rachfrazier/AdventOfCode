namespace AdventOfCode2023;

public static class Day4
{
    public static int CalculateScratchcardPoints(List<string> input)
    {
        int sum = 0;
        foreach (string line in input)
        {
            (List<int> WinningNumbers, List<int> ScorecardNumbers) parsedInput = ParseInput(line);
            IEnumerable<int> matches = parsedInput.WinningNumbers.Intersect(parsedInput.ScorecardNumbers);
            if (matches.Any())
            {
                sum += CalculateScore(matches.Count());
            }
        }

        return sum;
    }

    public static int CaculateTotalScratchCards(List<string> input)
    {
        int[] dupes = new int[input.Count];
        for (int i = 0; i < dupes.Length; ++i)
        {
            dupes[i]++;
        }

        for(int i = 0; i <input.Count; ++i)
        {
            for (int j = 0; j < dupes[i]; ++j)
            {
                (List<int> WinningNumbers, List<int> ScorecardNumbers) parsedInput = ParseInput(input[i]);
                IEnumerable<int> matches = parsedInput.WinningNumbers.Intersect(parsedInput.ScorecardNumbers);
                for(int k = 0; k < matches.Count(); ++k)
                {
                    if (i == dupes.Length - 1)
                    {
                        continue;
                    }
                    dupes[i + 1 + k]++;
                }
            }
        }

        return dupes.Sum();
    }

    internal static int CalculateScore(int numMatches)
    {
        int score = 1;
        for (int i = 1; i < numMatches; ++i)
        {
            score *= 2;
        }

        return score;
    }

    internal static (List<int> WinningNumbers, List<int> ScorecardNumbers) ParseInput(string cardLine)
    {
        string[] splitResult = cardLine.Split('|');
        string winningSegment = splitResult[0].Split(':')[1];
        string scorecardSegment = splitResult[1];
        List<int> winningNumbers = ExtractNumbersFromString(winningSegment);
        List<int> scorecardNumbers = ExtractNumbersFromString(scorecardSegment);
        return (winningNumbers, scorecardNumbers);
    }

    internal static List<int> ExtractNumbersFromString(string input)
    {
        List<int> numbersList = new();
        string[] numbers = input.Trim().Split(' ');
        foreach(string number in numbers)
        {
            if (string.IsNullOrEmpty(number))
            {
                continue;
            }
            numbersList.Add(int.Parse(number.Trim()));
        }

        return numbersList;
    }
}
