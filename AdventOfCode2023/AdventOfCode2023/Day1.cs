
namespace AdventOfCode2023;

public static class Day1
{
    const uint zeroAscii = 48;
    const uint nineAscii = 57;

    private static Dictionary<string, char> NumberStrings = new Dictionary<string, char>
    {
        {"one", '1'},
        {"two", '2'},
        {"three", '3'},
        {"four", '4'},
        {"five", '5'},
        {"six", '6'},
        {"seven", '7'},
        {"eight", '8'},
        {"nine" , '9'}
    };

    public static bool IsCharacterSingleDigit(char letter) => letter >= zeroAscii && letter <= nineAscii;

    public static (char First, char Second) ExtractNumbers(string input)
    {
        char[] charArray = input.ToCharArray();
        char first = 'a';
        char? second = null;
        foreach (char letter in charArray)
        {
            if (IsCharacterSingleDigit(letter))
            {
                first = letter;
                break;
            }
        }

        for (int i = input.Length - 1; i >= 0; --i)
        {
            if (IsCharacterSingleDigit(charArray[i]))
            {
                second = charArray[i];
                break;
            }
        }

        if (second == null)
        {
            second = first;
        }

        return (first, second.Value);
    }

    public static (char First, char Second) ExtractNumbersP2(string input) =>
        ExtractNumbers(RewriteLine(input));
    public static char GetTrueFirstOccurringDigit(string originalLine, int indexOfFirstOccurringNumber, char valOfNumber)
    {
        Dictionary<int, char> letterDigits = GetMatchesToTextDigits(originalLine);
        if (letterDigits.Count == 0)
        {
            return valOfNumber;
        }

        int minIndex = letterDigits.Min(x => x.Key);
        if (minIndex < indexOfFirstOccurringNumber)
        {
            return letterDigits[minIndex];
        }

        return valOfNumber;
    }

    public static char GetTrueLastOccurringDigit(string originalLine, int indexOfLastOccurringNumber, char valOfNumber)
    {
        Dictionary<int, char> letterDigits = GetMatchesToTextDigits(originalLine);
        if (letterDigits.Count == 0)
        {
            return valOfNumber;
        }
        int maxIndex = letterDigits.Max(x => x.Key);
        if (maxIndex > indexOfLastOccurringNumber)
        {
            return letterDigits[maxIndex];
        }

        return valOfNumber;
    }

    public static int ConvertDigitsToCombinedNumber(char first, char second)
    {
        string finalNumber = $"{first}{second}";
        return int.Parse(finalNumber);
    }

    public static bool DoAllInputHaveAtLeastOneDigit(List<string> input)
    {
        foreach(string value in input)
        {
            char[] charArray = value.ToCharArray();
            bool containsLetter = false;
            foreach (char letter in charArray)
            {
                if (IsCharacterSingleDigit(letter))
                {
                    containsLetter = true;
                    break;
                }
            }

            if(!containsLetter)
            {
                return false;
            }    
        }

        return true;
    }

    private static Dictionary<int, char> GetMatchesToTextDigits(string line)
    {
        Dictionary<int, char> matches = new();
        foreach (var kvp in NumberStrings)
        {
            int index = line.ToLower().IndexOf(kvp.Key);
            if (index != -1)
            {
                matches.Add(index, kvp.Value);
            }
        }

        return matches;
    }

    private static string RewriteLine(string line) => line
    .Replace("eightwo", "82")
    .Replace("oneight", "18")
    .Replace("threeight", "38")
    .Replace("fiveight", "58")
    .Replace("sevenine", "79")
    .Replace("twone", "21")
    .Replace("one", "1")
    .Replace("two", "2")
    .Replace("three", "3")
    .Replace("four", "4")
    .Replace("five", "5")
    .Replace("six", "6")
    .Replace("seven", "7")
    .Replace("eight", "8")
    .Replace("nine", "9");
}
