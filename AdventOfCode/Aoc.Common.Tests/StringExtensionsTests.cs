namespace AoC.Common.Tests;

using AoC.Common;
using System.Text.RegularExpressions;

[TestClass]
public class StringExtensionsTests
{
	[TestMethod]
	[DataRow(18102, 93258)]
	[DataRow(34171, 50404)]
	[DataRow(48236, 60718)]
	public void StringIntoTuple_GivenString_ReturnsCorrectNumbers(int first, int second)
	{
		string input = $"{first}   {second}";
		(string actualFirst, string actualSecond) = input.SplitIntoTuple("   ");
		Assert.AreEqual(first, int.Parse(actualFirst));
		Assert.AreEqual(second, int.Parse(actualSecond));
	}

	[TestMethod]
	public void ExtractNumbersFromString_GivenString_GetsAllNumbers()
	{
		string input = "7 6 4 2 1";
		Assert.IsTrue(input.ExtractNumbersFromString(" ").SequenceEqual(new List<int> { 7, 6, 4, 2, 1 }));
	}

	[TestMethod]
	public void SplitLinesIntoStringIntVals_GivenRegex_SplitsValuesCorrectly()
	{
		string input = "L4\nR389";
		List<(string Text, int Value)> actual = input.SplitLinesIntoStringIntVals("\n", new Regex("[A-Z]"));
		Assert.AreEqual(actual[0].Text, "L");
		Assert.AreEqual(actual[0].Value, 4);
		Assert.AreEqual(actual[1].Text, "R");
		Assert.AreEqual(actual[1].Value, 389);
	}
}