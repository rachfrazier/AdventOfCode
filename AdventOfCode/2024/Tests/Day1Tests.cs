namespace AoC._2024.Tests;

using AoC.Common;
using AdventOfCode2024;
using System.Linq;

[TestClass]
public class Day1Tests
{
	private DistanceMeasure distanceMeasure;
	private List<string> input = new()
	{
		"3   4",
		"4   3",
		"2   5",
		"1   3",
		"3   9",
		"3   3"
	};

	[TestInitialize]
	public void TestInit()
	{
		this.distanceMeasure = new(input);
	}

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
		Assert.IsTrue(this.distanceMeasure.firstList.SequenceEqual(new List<int> { 3, 4, 2, 1, 3, 3 }));
		Assert.IsTrue(this.distanceMeasure.secondList.SequenceEqual(new List<int> { 4, 3, 5, 3, 9, 3 }));
	}

	[TestMethod]
	public void DistanceMeasure_FindTotalDistance_ReturnsCorrectValue()
	{
		Assert.AreEqual(11, this.distanceMeasure.FindTotalDistance());
	}

	[TestMethod]
	[DataRow(3, 9)]
	[DataRow(4, 4)]
	[DataRow(2, 0)]
	[DataRow(1, 0)]
	public void CalculateAndStoreSimilarityScore_GivenNumber_ReturnsCorrectScore(int value, int expectedScore)
	{
		this.distanceMeasure.CalculateAndStoreSimilarityScore(value);
		Assert.AreEqual(expectedScore, this.distanceMeasure.similarityScores[value]);
	}

	[TestMethod]
	public void FindTotalSimilarityScore_GivenInput_ReturnsCorrectScore()
	{
		Assert.AreEqual(31, this.distanceMeasure.FindTotalSimilarityScore());
	}
}