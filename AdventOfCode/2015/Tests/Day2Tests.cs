using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015Tests;

using AdventOfCode2015;
using System.Numerics;

[TestClass]
public class Day2Tests
{
    [TestMethod]
    [DataRow("2x3x4", 2, 3, 4)]
    [DataRow("1x1x10", 1, 1, 10)]
    [DataRow("10x14x20", 10, 14, 20)]
    public void GivenTestInput_ExtractValues_ReturnsCorrectNumbers(string input, int x, int y, int z)
    {
        Vector3 actual = new InputParser(input).ExtractVector();
        Assert.AreEqual(new Vector3(x, y, z), actual);
    }

    [TestMethod]
    [DataRow(2, 3, 4, 52)]
    [DataRow(1, 1, 10, 42)]
    public void Rectangle_CalculateSurfaceArea_ReturnsCorrectValue(float x, float y, float z, float expectedSurfaceArea)
    {
        Rectangle rectangle = new Rectangle(new Vector3(x, y, z));
        float actual = rectangle.CalculateSurfaceArea();
        Assert.AreEqual(expectedSurfaceArea, actual);
    }

    [TestMethod]
    [DataRow(2, 3, 4, 6)]
    [DataRow(1, 1, 10, 1)]
    [DataRow(2, 2, 4, 4)]
    public void Rectangle_GetSmallestSideArea_ReturnsCorrectValue(float x, float y, float z, float expectedSmallestSideArea)
    {
        Rectangle rectangle = new Rectangle(new Vector3(x, y, z));
        float actual = rectangle.GetSmallestSideArea();
        Assert.AreEqual(expectedSmallestSideArea, actual);
    }

    [TestMethod]
    [DataRow(2, 3, 4, 24)]
    [DataRow(1, 1, 10, 10)]
    public void Rectangle_CalculateVolume_ReturnsCorrectValue(float x, float y, float z, float expectedVolume)
    {
        Rectangle rectangle = new Rectangle(new Vector3(x, y, z));
        float actual = rectangle.CalculateVolume();
        Assert.AreEqual(expectedVolume, actual);
    }

    [TestMethod]
    [DataRow(2, 3, 4, 10)]
    [DataRow(1, 1, 10, 4)]
    public void Rectangle_GetSmallestPerimeter_ReturnsCorrectValue(float x, float y, float z, float expectedPerimeter)
    {
        Rectangle rectangle = new Rectangle(new Vector3(x, y, z));
        float actual = rectangle.GetSmallestPerimeter();
        Assert.AreEqual(expectedPerimeter, actual);
    }
}
