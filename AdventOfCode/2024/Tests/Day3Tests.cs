using AdventOfCode2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2024.Tests;

[TestClass]
public class Day3Tests
{
	private MultiplerTokenizer tokenizer;

	[TestInitialize]
	public void InitTest()
	{
		this.tokenizer = new("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))mul(454,218)");
	}

	[TestMethod]
	public void GetAllValidMultiplierSegments_GivenString_ReturnsCorrectNumberOfTokenizedPieces()
	{
		Assert.IsTrue(this.tokenizer.Tokens.Count == 5);
	}

	[TestMethod]
	[DataRow("mul(2,4)", 2, 4)]
	[DataRow("mul(5,5)", 5, 5)]
	[DataRow("mul(11,8)", 11, 8)]
	[DataRow("mul(131,810)", 131, 810)]
	public void ParseTokenForMultiplers_GivenValidString_ReturnsCorrectValues(string input, int expectedFirst, int expectedSecond)
	{
		(int actualFirst, int actualSecond) = this.tokenizer.ParseTokenForMultiplers(input);
		Assert.AreEqual(expectedFirst, actualFirst);
		Assert.AreEqual(expectedSecond, actualSecond);
	}

	[TestMethod]
	public void GetSumOfMultipledTokens_GivenInput_ReturnsCorrectValue()
	{
		Assert.AreEqual(99133, this.tokenizer.GetSumOfMultipledTokens());
	}

	[TestMethod]
	[DataRow("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", "xmul(2,4)&mul[3,7]!^do()?mul(8,5))")]
	[DataRow("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)un?mul(8,5))", "xmul(2,4)&mul[3,7]!^")]
	public void ParseOutDisabledSegments_GivenInput_ReturnsCorrectParsedString(string input, string expected)
	{
		string parsed = this.tokenizer.ParseOutDisabledSegments(input);
		Assert.AreEqual(expected, parsed);
	}
}
