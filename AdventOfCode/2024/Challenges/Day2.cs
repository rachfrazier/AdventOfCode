using AoC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024;
internal class ReportSafetyInspector
{
	private List<List<int>> reports = new();

	public ReportSafetyInspector(IEnumerable<string> reports)
	{
		this.reports.AddRange(reports.Select(r => r.ExtractNumbersFromString(" ")));
	}

	public int GetTotalSafeLevels()
	{
		int totalSafe = 0;
		foreach(List<int> report in reports)
		{
			if (AreLevelDiffsWithinRange(report) &&
				(AreAllLevelsDecreasing(report) || AreAllLevelsIncreasing(report)))
			{
				++totalSafe;
			}
		}

		return totalSafe;
	}

	internal bool AreAllLevelsIncreasing(List<int> levels)
	{
		for (int i = 0; i < levels.Count - 1; ++i)
		{
			if (levels[i + 1] <= levels[i])
			{
				return false;
			}
		}

		return true;
	}

	internal bool AreAllLevelsDecreasing(List<int> levels)
	{
		for (int i = 0; i < levels.Count - 1; ++i)
		{
			if (levels[i + 1] >= levels[i])
			{
				return false;
			}
		}

		return true;
	}

	internal bool AreLevelDiffsWithinRange(List<int> levels)
	{
		for (int i = 0; i < levels.Count - 1; ++i)
		{
			int diff = Math.Abs(levels[i + 1] - levels[i]);
			if (diff < 1 || diff > 3)
			{
				return false;
			}
		}

		return true;
	}
}
