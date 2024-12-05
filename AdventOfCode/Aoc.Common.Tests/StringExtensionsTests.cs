namespace AoC.Common.Tests;

using AoC.Common;

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
}