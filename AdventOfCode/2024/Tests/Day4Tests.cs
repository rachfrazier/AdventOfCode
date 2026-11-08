
using AdventOfCode2024;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2024.Tests;

[TestClass]
public class Day4Tests
{
	private readonly List<string> testInput = new()
	{
		"MMMSXXMASM",
		"MSAMXMSMSA",
		"AMXSXMAAMM",
		"MSAMASMSMX",
		"XMASAMXAMM",
		"XXAMMXXAMA",
		"SMSMSASXSS",
		"SAXAMASAAA",
		"MAMMMXMMMM",
		"MXMXAXMASX",
	};

	private XMASFinder finder;

	[TestInitialize]
	public void TestInitialize()
	{
		this.finder = new(testInput);
	}


	[TestMethod]
	public void CountAllHorizonalOccurrences_GivenInput_CountsAllBackwardsAndForwardOccurrences()
	{
		Assert.AreEqual(5, this.finder.CountAllHorizonalOccurrences());
	}
}
