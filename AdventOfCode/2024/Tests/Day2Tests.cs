using AdventOfCode2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2024.Tests;

[TestClass]
public class Day2Tests
{
	private ReportSafetyInspector inspector;

	public Day2Tests()
	{
		List<string> input = new()
		{
			"7 6 4 2 1",
			"1 2 7 8 9",
			"9 7 6 2 1",
			"1 3 2 4 5",
			"8 6 4 4 1",
			"1 3 6 7 9"
		};
		this.inspector = new(input);
	}


	[TestMethod]
	public void AreAllLevelsIncreasing_GivenAllIncreasing_ReturnsTrue()
	{
		Assert.IsTrue(this.inspector.AreAllLevelsIncreasing(new List<int> { 1, 3, 6, 7, 9 }));
	}

	[TestMethod]
	public void AreAllLevelsIncreasing_GivenSomeDecreasing_ReturnsFalse()
	{
		Assert.IsFalse(this.inspector.AreAllLevelsIncreasing(new List<int> { 1, 3, 2, 4, 5 }));
	}

	[TestMethod]
	public void AreAllLevelsIncreasing_GivenLevelsAtSameValue_ReturnsFalse()
	{
		Assert.IsFalse(this.inspector.AreAllLevelsIncreasing(new List<int> { 8, 6, 4, 4, 1 }));
	}

	[TestMethod]
	public void AreAllLevelsDecreasing_GivenAllDecreasing_ReturnsTrue()
	{
		Assert.IsTrue(this.inspector.AreAllLevelsDecreasing(new List<int> { 7, 6, 4, 2, 1 }));
	}

	[TestMethod]
	public void AreAllLevelsDecreasing_GivenSomeDecreasing_ReturnsFalse()
	{
		Assert.IsFalse(this.inspector.AreAllLevelsDecreasing(new List<int> { 1, 3, 2, 4, 5 }));
	}

	[TestMethod]
	public void AreAllLevelsDecreasing_GivenLevelsAtSameValue_ReturnsFalse()
	{
		Assert.IsFalse(this.inspector.AreAllLevelsDecreasing(new List<int> { 8, 6, 4, 4, 1 }));
	}


	[TestMethod]
	public void AreLevelDiffsWithinRange_GivenLevelsWithinRange_ReturnsTrue()
	{
		Assert.IsTrue(this.inspector.AreLevelDiffsWithinRange(new List<int> { 7, 6, 4, 2, 1 }));
	}

	[TestMethod]
	public void AreLevelDiffsWithinRange_GivenTwoLevelsWithSameValue_ReturnsFalse()
	{
		Assert.IsFalse(this.inspector.AreLevelDiffsWithinRange(new List<int> { 8, 6, 4, 4, 1 }));
	}

	[TestMethod]
	public void AssertLevelDiffWithinRange_GivenLevelsOutsideRange_ReturnsFalse()
	{
		Assert.IsFalse(this.inspector.AreLevelDiffsWithinRange(new List<int> { 1, 2, 7, 8, 9 }));
	}

	[TestMethod]
	public void GetTotalSafeLevels_GivenInput_ReturnsCorrectNumber()
	{
		Assert.AreEqual(2, this.inspector.GetTotalSafeLevels());
	}
}
