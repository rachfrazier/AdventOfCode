using AdventOfCode2015;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015Tests;

[TestClass]
public class Day3Tests
{
	[TestMethod]
	[DataRow(1, 0, 1, 0)]
	[DataRow(0, 1, 0, 1)]
	[DataRow(-1, 0, -1, 0)]
	[DataRow(0, -1, 0, -1)]
	public void VisitHouse_GivenDirection_AdjustsCurrentPositionCorrectly(
		int newX, int newY, int expectedX, int expectedY)
	{
		PresentMap presentMap = new();
		presentMap.VisitHouse(new Point(newX, newY));
		Assert.AreEqual(new Point(expectedX, expectedY), presentMap.currentPosition);
	}

	[TestMethod]
	public void VisitHouse_GivenNewHouse_AddsHouseToMap()
	{
		PresentMap presentMap = new();
		Point expectedPosition = new Point(1, 0);
		presentMap.VisitHouse(expectedPosition);
		Assert.IsTrue(presentMap.visitedHouses.ContainsKey(expectedPosition));
		Assert.AreEqual(1, presentMap.visitedHouses[expectedPosition]);
	}

	[TestMethod]
	public void VisitHouse_GivenExistingHouse_IncrementsExistingPresentCount()
	{
		PresentMap presentMap = new();
		presentMap.VisitHouse(new Point(1, 0));
		presentMap.VisitHouse(new Point(-1, 0));
		Point startingLocation = new(0, 0);
		Assert.AreEqual(2, presentMap.visitedHouses[startingLocation]);
	}

	[TestMethod]
	[DataRow(">", 2)]
	[DataRow("^>v<", 4)]
	[DataRow("^v^v^v^v^v", 2)]
	public void SolvePresentMap_GivenInput_ReturnsCorrectNumberOfHousesVisted(string input, int expectedCount)
	{
		Day3 day3 = new();
		int actual = day3.SolvePresentMap(input);
		Assert.AreEqual(expectedCount, actual);
	}
}
