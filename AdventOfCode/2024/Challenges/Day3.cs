using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024;
internal class Day3
{

}

internal class MultiplerTokenizer
{
	private static Regex multiplerRegex = 
		new(@"mul\([0-9]*,[0-9]*\)");

	public MultiplerTokenizer(string input)
	{
		this.Tokens = multiplerRegex.Matches(input).Select(m => m.Value).ToList();
	}

	public List<string> Tokens { get; }

	public int GetSumOfMultipledTokens()
	{
		int totalSum = 0;

		foreach (string token in this.Tokens)
		{
			(int first, int second) = ParseTokenForMultiplers(token);
			totalSum += first * second;
		}

		return totalSum;
	}

	internal (int First, int Second) ParseTokenForMultiplers(string token)
	{
		int indexOfFirstPar = token.IndexOf('(');
		int indexOfComma = token.IndexOf(',');
		int indexOfLastPar = token.IndexOf(')');
		return
			(int.Parse(token.Substring(indexOfFirstPar + 1, indexOfComma - 1 - indexOfFirstPar)),
			int.Parse(token.Substring(indexOfComma + 1, indexOfLastPar - 1 - indexOfComma)));
	}
}