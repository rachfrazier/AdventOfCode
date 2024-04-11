using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023;

namespace AdventOfCodeTests;

[TestClass]
public class Day3Tests
{
    [TestMethod]
    [DataRow("...$.*....", 0, 4)]
    public void DoesAdjacentLineContainSymbols_WithLinesWithSymbols_ReturnsTrue(string line, int startIndex, int endIndex)
    {
        Assert.IsTrue(Day3.DoesAdjacentLineContainSymbol(line, startIndex, endIndex).HasSymbol);
    }

    [TestMethod]
    [DataRow("..592.....", 5, 9)]
    public void DoesAdjacentLineContainsSymbols_WithLinesWithNoSymbols_ReturnsFalse(string line, int startIndex, int endIndex)
    {
        Assert.IsFalse(Day3.DoesAdjacentLineContainSymbol(line, startIndex, endIndex).HasSymbol);
    }

    [TestMethod]
    [DataRow("..592.....", 2, 4)]
    [DataRow("..35...633", 7, 9)]
    public void GetLastIndexOfNumber_OnValidNumber_ReturnsCorrectIndex(string line, int startIndex, int expectedIndex)
    {
        Assert.AreEqual(expectedIndex, Day3.GetLastIndexOfNumber(line, startIndex));
    }

    [TestMethod]
    [DataRow(null, "467..114..", "...*......", 0, 2)]
    [DataRow("...*......", "..35..633.", "......#...", 2, 3)]
    [DataRow("...*......", "..35..633.", "......#...", 6, 8)]
    [DataRow("..592.....", ".......755", "...$..*...", 7, 9)]
    public void IsNumberAPartNumber_WithPartNumber_ReturnsTrue(string? previousLine, string currentLine, string? nextLine, int startIndex, int endIndex)
    {
        Assert.IsTrue(Day3.IsNumberAPartNumber(previousLine, currentLine, nextLine, startIndex, endIndex));
    }

    [TestMethod]
    [DataRow(null, "467..114..", "...*......", 5, 7)]
    [DataRow("617*......", ".....+.58.", "..592.....", 7, 8)]
    public void IsNumberAPartNumber_WithNoPartNumber_ReturnsFalse(string? previousLine, string currentLine, string? nextLine, int startIndex, int endIndex)
    {
        Assert.IsFalse(Day3.IsNumberAPartNumber(previousLine, currentLine, nextLine, startIndex, endIndex));
    }
}
