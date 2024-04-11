namespace AdventOfCode2023;

public static class Day3
{
    private static List<char> Symbols =
        new List<char>{ ',', ':', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '/', '\\', };

    private static char[] Digits = new char[]{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    // third is number
    private static Dictionary<(string Line, int PositionIndex), List<int>> GearsNearNumbers = new();

    public static int SumPartNumbers(List<string> lines)
    {
        GearsNearNumbers.Clear();
        int sum = 0;
        for(int i = 0; i < lines.Count(); ++i)
        {
            sum += GetSumPartNumbersOfLine(
                i == 0 ? null : lines[i - 1],
                lines[i],
                i == lines.Count() - 1 ? null : lines[i + 1]);
        }

        return sum;
    }

    public static int SumGearNumbers(List<string> lines)
    {
        SumPartNumbers(lines);
        int sum = 0;
        foreach (var entry in GearsNearNumbers)
        {
            if (entry.Value.Count > 1)
            {
                sum += entry.Value.Aggregate((x, y) => x * y);
            }
        }
        return sum;
    }

    internal static bool ContainsGear(this string line) => line.Contains('*');

    internal static int GetSumPartNumbersOfLine(string? previousLine, string currentLine, string? nextLine)
    {
        int sum = 0;
        int i = 0;
        while (i != -1 || i >= currentLine.Length)
        {
            i = currentLine.IndexOfAny(Digits, i);
            if (i == -1)
            {
                break;
            }
            int endIndex = GetLastIndexOfNumber(currentLine, i);
            if (IsNumberAPartNumber(previousLine, currentLine, nextLine, i, endIndex))
            {
                sum += int.Parse(currentLine.Substring(i, endIndex + 1 - i));
            }

            i = endIndex + 1;
        }

        return sum;
    }

    internal static int GetLastIndexOfNumber(string currentLine, int startIndex)
    {
        int i = startIndex;
        for (; i < currentLine.Length; ++i)
        {
            if (!Digits.Contains(currentLine[i]))
            {
                return i - 1;
            }
        }

        // We reached the end of the array, so need one less than
        return i - 1;
    }

    internal static bool IsNumberAPartNumber(string? previousLine, string currentLine, string? nextLine, int startIndex, int endIndex)
    {
        bool hasSymbol = false;
        int numberVal = int.Parse(currentLine.Substring(startIndex, endIndex + 1 - startIndex));
        if (previousLine != null)
        {
            (bool hasSymbol, int? gearIndex) result = DoesAdjacentLineContainSymbol(
                previousLine,
                startIndex == 0 ? 0 : startIndex - 1,
                endIndex == previousLine.Length - 1 ? endIndex : endIndex + 1);
            if (result.hasSymbol)
            {
                hasSymbol = true;
                if (result.gearIndex != null)
                {
                    AddToExistingOrCreateNewToDictionary(previousLine, result.gearIndex.Value, numberVal);
                }
            }
        }
        if (startIndex - 1 > 0 && Symbols.Contains(currentLine[startIndex - 1]))
        {
            if (currentLine[startIndex - 1] == '*')
            {
                AddToExistingOrCreateNewToDictionary(currentLine, startIndex - 1, numberVal);
            }
            hasSymbol = true;
        } 
        if (endIndex + 1 < currentLine.Length - 1 && Symbols.Contains(currentLine[endIndex + 1]))
        {
            if (currentLine[endIndex + 1] == '*')
            {
                AddToExistingOrCreateNewToDictionary(currentLine, endIndex + 1, numberVal);
            }
            hasSymbol = true;
        }
        if (nextLine != null)
        {
            (bool hasSymbol, int? gearIndex) result = DoesAdjacentLineContainSymbol(
                nextLine,
                startIndex == 0 ? 0 : startIndex - 1,
                endIndex == nextLine.Length - 1 ? endIndex : endIndex + 1);
            if (result.hasSymbol)
            {
                hasSymbol = true;
                if (result.gearIndex != null)
                {
                    AddToExistingOrCreateNewToDictionary(nextLine, result.gearIndex.Value, numberVal);
                }
            }
        }

        return hasSymbol;
    }

    internal static (bool HasSymbol, int? GearIndex) DoesAdjacentLineContainSymbol(string line, int startIndex, int endIndex)
    {
        bool hasSymbol = false;
        int? gearIndex = null;
        for (int i = startIndex; i < endIndex + 1; ++i)
        {
            if (Symbols.Contains(line[i]))
            {
                hasSymbol = true;
                if (line[i] == '*')
                {
                    gearIndex = i;
                }
            }
        }

        return (hasSymbol, gearIndex);
    }

    private static void AddToExistingOrCreateNewToDictionary(string line, int gearIndex, int numberVal)
    {
        if (GearsNearNumbers.ContainsKey((line, gearIndex)))
        {
            GearsNearNumbers[(line, gearIndex)].Add(numberVal);
        }
        else
        {
            GearsNearNumbers.Add((line, gearIndex), new List<int> { numberVal });
        }
    }
}
