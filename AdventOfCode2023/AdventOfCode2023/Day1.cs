
namespace AdventOfCode2023;

public static class Day1
{
    const uint zeroAscii = 48;
    const uint nineAscii = 57;

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
}
