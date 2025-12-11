using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AoC.Common;

public static class StringExtensions
{
	public static (string First, string Second) SplitIntoTuple(this string input, string separator)
	{
		string[] result = input.Split(separator);
		return (result[0], result[1]);
	}

	public static List<int> ExtractNumbersFromString(this string input, string separator)
	{
		string[] result = input.Split(separator);
		return result.Select(number => int.Parse(number)).ToList();
	}

	public static List<(string Text, int Value)> SplitLinesIntoStringIntVals(this string input, string separator, Regex regex)
	{
		string[] lines = input.Split(separator);
		List<(string Text, int Value)> result = new();
		foreach (string line in lines)
		{
			if (string.IsNullOrEmpty(line))
			{
				continue;
			}

			string[] splitLine = regex.Split(line);
			result.Add((regex.Match(line).Value, int.Parse(splitLine[1])));
		}

		return result;
	}
}
