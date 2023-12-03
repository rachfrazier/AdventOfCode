
namespace AdventOfCodeTests;

using AdventOfCode2023;

[TestClass]
public class Day1Tests
{
    [TestMethod]
    [DataRow('0')]
    [DataRow('1')]
    [DataRow('2')]
    [DataRow('3')]
    [DataRow('4')]
    [DataRow('5')]
    [DataRow('6')]
    [DataRow('7')]
    [DataRow('8')]
    [DataRow('9')]
    public void IsCharacterSingleDigit_WithValidDigits_ReturnsTrue(char letter) =>
        Assert.IsTrue(Day1.IsCharacterSingleDigit(letter));

    [TestMethod]
    [DataRow('/')]
    [DataRow(':')]
    public void IsCharacterSingleDigit_WithInvalidDigits_ReturnsFalse(char letter) =>
        Assert.IsFalse(Day1.IsCharacterSingleDigit(letter));

    [TestMethod]
    public void ExtractNumbers_WithOnlyTwoNumbers_GetsBothNumbers()
    {
        (char First, char Second) result = Day1.ExtractNumbers("ad1dsja2js");
        Assert.AreEqual(result.First, '1');
        Assert.AreEqual(result.Second, '2');
    }

    [TestMethod]
    public void ExtractNumbers_WithOnlyMultipleNumbers_GetsOnlyFirstAndLastDigit()
    {
        (char First, char Second) result = Day1.ExtractNumbers("ad1d3jk35j6sja2js");
        Assert.AreEqual(result.First, '1');
        Assert.AreEqual(result.Second, '2');
    }

    [TestMethod]
    public void ExtractNumbers_WithOnlyOneNumber_ReturnsSameNumberForFirstAndSecond()
    {
        (char First, char Second) result = Day1.ExtractNumbers("ad1dsjajs");
        Assert.AreEqual(result.First, '1');
        Assert.AreEqual(result.Second, '1');
    }

    [TestMethod]
    public async Task InputFile_AllValues_ContainAtLeastOneNumber()
    {
        List<string> input = new(await File.ReadAllLinesAsync("day1input.txt").ConfigureAwait(false));
        Assert.IsTrue(Day1.DoAllInputHaveAtLeastOneDigit(input));
    }

    [TestMethod]
    [DataRow('1', '2', 12)]
    [DataRow('3', '8', 38)]
    [DataRow('7', '7', 77)]
    public void ConvertDigitsToCombinedNumber_WithValidNumbers_ReturnsCorrectNumber(char first, char second, int expected) =>
        Assert.AreEqual(Day1.ConvertDigitsToCombinedNumber(first, second), expected);

    [TestMethod]
    [DataRow("two1nine", '2', '9')]
    [DataRow("eightwothree", '8', '3')]
    [DataRow("abcone2threexyz", '1', '3')]
    [DataRow("xtwone3four", '2', '4')]
    [DataRow("4nineeightseven2", '4', '2')]
    [DataRow("zoneight234", '1', '4')]
    [DataRow("7pqrstsixteen", '7', '6')]
    [DataRow("eightwo", '8', '2')]
    [DataRow("oneight", '1', '8')]
    [DataRow("threeight", '3', '8')]
    [DataRow("fiveight", '5', '8')]
    [DataRow("sevenine", '7', '9')]
    [DataRow("twone", '2', '1')]
    [DataRow("2bk", '2', '2')]
    [DataRow("voneightznktfvmxlhnine1seven4z", '1', '4')]
    public void ExtractNumbersP2_WithSampleValues_ReturnsExpectedNumber(string original, char expectedFirst, char expectedSecond)
    {
        (char first, char second) result = Day1.ExtractNumbersP2(original);
        Assert.AreEqual(expectedFirst, result.first);
        Assert.AreEqual(expectedSecond, result.second);
    }
}