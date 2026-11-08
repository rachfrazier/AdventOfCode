using AdventOfCode2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015Tests;

[TestClass]
public class Day4Tests
{
	private Day4 day4 = new();

	[TestMethod]
	[DataRow("000001dbbfa")]
	[DataRow("000006136ef")]
	public void IsValidHash_GivenValidHash_ReturnsTrue(string input)
	{
		Assert.IsTrue(day4.IsValidHash(input));
	}

	[TestMethod]
	[DataRow("100006136ef")]
	[DataRow("010006136ef")]
	[DataRow("001006136ef")]
	[DataRow("000106136ef")]
	[DataRow("000016136ef")]
	public void IsValidHash_GivenInvalidHash_ReturnsFalse(string input)
	{
		Assert.IsFalse(day4.IsValidHash(input));
	}
}
