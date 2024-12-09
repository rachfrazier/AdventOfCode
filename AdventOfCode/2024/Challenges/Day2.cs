using AoC.Common;

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
			if (AreLevelsSafe(report))
			{
				++totalSafe;
			}
		}

		return totalSafe;
	}

	public int GetTotalSafeLevelsWithProblemDampener()
	{
		int totalSafe = 0;
		foreach (List<int> report in reports)
		{
			if (AreLevelsSafe(report))
			{
				++totalSafe;
				continue;
			}

			for (var i = 0; i < report.Count(); i++)
			{
				List<int> newReport = new(report);
				newReport.RemoveAt(i);
				if (AreLevelsSafe(newReport))
				{
					++totalSafe;
					break;
				}
			}
		}

		return totalSafe;
	}

	internal bool AreLevelsSafe(List<int> report) =>
		AreLevelDiffsWithinRange(report) &&
		(AreAllLevelsDecreasing(report) || AreAllLevelsIncreasing(report));

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
			if (!IsWithinRange(diff))
			{
				return false;
			}
		}

		return true;
	}

	private bool IsWithinRange(int diff) => diff >= 1 && diff <= 3;
}
