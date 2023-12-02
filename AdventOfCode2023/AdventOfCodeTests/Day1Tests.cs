
namespace AdventOfCodeTests;

using AdventOfCode2023;
using System.Runtime.CompilerServices;

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
        List<string> input = new(await File.ReadAllLinesAsync("input.txt").ConfigureAwait(false));
        Assert.IsTrue(Day1.DoAllInputHaveAtLeastOneDigit(input));
    }

    [TestMethod]
    [DataRow('1', '2', 12)]
    [DataRow('3', '8', 38)]
    [DataRow('7', '7', 77)]
    public void ConvertDigitsToCombinedNumber_WithValidNumbers_ReturnsCorrectNumber(char first, char second, int expected)
    {
        Assert.AreEqual(Day1.ConvertDigitsToCombinedNumber(first, second), expected);
    }

}