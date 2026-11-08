using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024;
internal class XMASFinder(List<string> input)
{
	public int CountAllXMASOccurrences()
	{
		return this.CountAllXMASOccurrences();
	}

	internal int CountAllHorizonalOccurrences()
	{
		Regex regex = new("XMAS|SAMX");
		int totalHorizontalOccurrences = 0;
		foreach (string line in input)
		{
			totalHorizontalOccurrences += regex.Matches(line).Count();
		}

		return totalHorizontalOccurrences;
	}
}
