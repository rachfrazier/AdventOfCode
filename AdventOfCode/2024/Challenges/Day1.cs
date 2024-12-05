using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024;

using AoC.Common;

internal class DistanceMeasure
{
	internal List<int> firstList = new();
	internal List<int> secondList = new();
	internal Dictionary<int, int> similarityScores = new();

	public DistanceMeasure(IEnumerable<string> input)
	{
		foreach (string line in input)
		{
			(string first, string second) = line.SplitIntoTuple("   ");
			this.firstList.Add(int.Parse(first));
			this.secondList.Add(int.Parse(second));
		}
	}

	public int FindTotalDistance()
	{
		this.firstList.Sort();
		this.secondList.Sort();
		int totalDistance = 0;
		for (int i = 0; i < firstList.Count; ++i)
		{
			totalDistance += Math.Abs(firstList[i] - secondList[i]);
		}

		return totalDistance;
	}

	public int FindTotalSimilarityScore()
	{
		this.firstList.Sort();
		this.secondList.Sort();

		int totalScore = 0;
		for (int i = 0; i < firstList.Count; ++i)
		{
			if (!this.similarityScores.ContainsKey(firstList[i]))
			{
				this.CalculateAndStoreSimilarityScore(firstList[i]);
			}

			totalScore += this.similarityScores[firstList[i]];
		}

		return totalScore;
	}

	internal void CalculateAndStoreSimilarityScore(int value)
	{
		int numberOfOccurences = this.secondList.Where(i => i == value).Count();
		this.similarityScores.Add(value, numberOfOccurences * value);
	}
}
