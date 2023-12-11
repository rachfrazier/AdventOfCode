using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023;

public static class Day3
{
    private static List<char> Symbols =
        new List<char>{ ',', ':', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '/', '\\', };

    private static char[] Digits = new char[]{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public static int SumPartNumbers(List<string> lines)
    {
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
        if (previousLine != null && 
            DoesAdjacentLineContainSymbol(
                previousLine,
                startIndex == 0 ? 0 : startIndex - 1,
                endIndex == previousLine.Length - 1 ? endIndex : endIndex + 1))
        {
            return true;
        }
        if (startIndex - 1 > 0 && Symbols.Contains(currentLine[startIndex - 1]))
        {
            return true;
        } 
        if (endIndex + 1 < currentLine.Length - 1 && Symbols.Contains(currentLine[endIndex + 1]))
        {
            return true;
        }
        if (nextLine != null &&
            DoesAdjacentLineContainSymbol(
                nextLine,
                startIndex == 0 ? 0 : startIndex - 1,
                endIndex == nextLine.Length - 1 ? endIndex : endIndex + 1))
        {
            return true;
        }

        return false;
    }

    internal static bool DoesAdjacentLineContainSymbol(string line, int startIndex, int endIndex)
    {
        for (int i = startIndex; i < endIndex + 1; ++i)
        {
            if (Symbols.Contains(line[i]))
            {
                return true;
            }
        }

        return false;
    }
}
