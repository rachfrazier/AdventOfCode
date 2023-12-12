namespace AdventOfCodeTests;

using AdventOfCode2023;

[TestClass]
public class Day4Tests
{
    [TestMethod]
    [DataRow("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 41, 48, 83, 86, 17})]
    [DataRow("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 13, 32, 20, 16, 61})]
    [DataRow("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", new int[] { 1, 21, 53, 59, 44 })]
    [DataRow("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", new int[] { 41, 92, 73, 84, 69 })]
    [DataRow("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", new int[] { 87, 83, 26, 28, 32 })]
    [DataRow("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", new int[] { 31, 18, 13, 56, 72 })]
    public void ParseInput_FromSampleInput_RetrievesWinningNumbersCorrectly(string input, int[] expected)
    {
        CollectionAssert.AreEqual(expected, Day4.ParseInput(input).WinningNumbers.ToArray());
    }

    [TestMethod]
    [DataRow("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 83, 86, 6, 31, 17, 9, 48, 53 })]
    [DataRow("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 61, 30, 68, 82, 17, 32, 24, 19 })]
    [DataRow("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", new int[] { 69, 82, 63, 72, 16, 21, 14, 1 })]
    [DataRow("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", new int[] { 59, 84, 76, 51, 58, 5, 54, 83 })]
    [DataRow("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", new int[] { 88, 30, 70, 12, 93, 22, 82, 36 })]
    [DataRow("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", new int[] { 74, 77, 10, 23, 35, 67, 36, 11 })]
    public void ParseInput_FromSampleInput_RetrievesScorecardNumbersCorrectly(string input, int[] expected)
    {
        CollectionAssert.AreEqual(expected, Day4.ParseInput(input).ScorecardNumbers.ToArray());
    }

    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(2, 2)]
    [DataRow(3, 4)]
    [DataRow(4, 8)]
    public void CalculateScore_GivenInput_ReturnsCorrectValue(int count, int expected)
    {
        Assert.AreEqual(expected, Day4.CalculateScore(count));
    }
}
