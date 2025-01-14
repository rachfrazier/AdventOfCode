﻿using System.Runtime.CompilerServices;

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
}
