namespace AoC._2024.Tests;

using AoC.Common;
using AdventOfCode2024;
using System.Linq;

[TestClass]
public class Day1Tests
{
	private List<string> input = new()
	{
		"3   4",
		"4   3",
		"2   5",
		"1   3",
		"3   9",
		"3   3"
	};

	[TestMethod]
	[DataRow(18102, 93258)]
	[DataRow(34171, 50404)]
	[DataRow(48236, 60718)]
	public void StringExtensions_Split_ReturnsCorrectNumbers(int first, int second)
	{
		string input = $"{first}   {second}";
		(string actualFirst, string actualSecond) = input.SplitIntoTuple("   ");
		Assert.AreEqual(first, int.Parse(actualFirst));
		Assert.AreEqual(second, int.Parse(actualSecond));
	}

	[TestMethod]
	public void DistanceMeasure_OnConstruction_CorrectlyConstructsLists()
	{
		DistanceMeasure measure = new(this.input);
		Assert.IsTrue(measure.firstList.SequenceEqual(new List<int> { 3, 4, 2, 1, 3, 3 }));
		Assert.IsTrue(measure.secondList.SequenceEqual(new List<int> { 4, 3, 5, 3, 9, 3 }));
	}

	[TestMethod]
	public void DistanceMeasure_FindTotalDistance_ReturnsCorrectValue()
	{
		DistanceMeasure measure = new(this.input);
		Assert.AreEqual(11, measure.FindTotalDistance());
	}
}