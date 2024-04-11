using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015Tests;

using AdventOfCode2015;

[TestClass]
public class Day1Tests
{
    [TestMethod]
    [DataRow("(())", 0)]
    [DataRow("()()", 0)]
    [DataRow("(((", 3)]
    [DataRow("(()(()(", 3)]
    [DataRow("))(((((", 3)]
    [DataRow("())", -1)]
    [DataRow("))(", -1)]
    [DataRow(")))", -3)]
    [DataRow(")())())", -3)]
    public void FloorCalculator_WithSequenceOfParenthesis_ReturnsCorrectFloor(string puzzleText, int expectedFloorCount)
    {
        FloorCalculator calculator = new(puzzleText);
        Assert.AreEqual(expectedFloorCount, calculator.CalculateFinalFloor());
    }

    [TestMethod]
    [DataRow(")", 1)]
    [DataRow("()())", 5)]
    public void FloorCalculator_WithBasementFloorReached_ReturnsCorrectPosition(string puzzleText, int expectedPosition)
    {
        FloorCalculator calculator = new(puzzleText);
        Assert.AreEqual(expectedPosition, calculator.FindFirstBasementVisitPosition());
    }

    [TestMethod]
    [DataRow("(")]
    [DataRow("(((((((")]
    [DataRow("()()")]
    public void FloorCalculator_WithNoBasementFloorReached_ThrowsException(string puzzleText)
    {
        FloorCalculator calculator = new(puzzleText);
        Assert.ThrowsException<Exception>(() => calculator.FindFirstBasementVisitPosition());
    }
}

