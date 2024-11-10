using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015;

internal class Day3
{
	public int SolvePresentMap(string input)
	{
		PresentMap presentMap = new();
		foreach(char direction in input)
		{
			MoveHouse(presentMap, direction);
		}

		return presentMap.GetTotalNumberOfHousesVisited();
	}

	public int SolveRoboSantaPresentMap(string input)
	{
		PresentMap santaMap = new();
		PresentMap roboMap = new();

		for(int i = 0; i < input.Length; ++i)
		{
			if (i % 2 == 0)
			{
				MoveHouse(santaMap, input[i]);
			}
			else
			{
				MoveHouse(roboMap, input[i]);
			}
		}

		List<Point> allLocations = santaMap.GetAllVisitedHomeLocations();
		allLocations.AddRange(roboMap.GetAllVisitedHomeLocations());
		return allLocations.Distinct().Count();
	}

	private static void MoveHouse(PresentMap presentMap, char direction)
	{
		switch (direction)
		{
			case '^':
				presentMap.VisitHouse(new Point(0, 1));
				break;
			case 'v':
				presentMap.VisitHouse(new Point(0, -1));
				break;
			case '>':
				presentMap.VisitHouse(new Point(1, 0));
				break;
			case '<':
				presentMap.VisitHouse(new Point(-1, 0));
				break;
		}
	}
}

internal class PresentMap
{
	internal Point currentPosition = new(0, 0);
	internal Dictionary<Point, int> visitedHouses = new();

	internal PresentMap()
	{
		this.visitedHouses.Add(this.currentPosition, 1);
	}

	public void VisitHouse(Point newDirection)
	{
		this.currentPosition.X += newDirection.X;
		this.currentPosition.Y += newDirection.Y;
		try
		{
			visitedHouses[this.currentPosition]++;
		}
		catch (KeyNotFoundException)
		{
			visitedHouses.Add(this.currentPosition, 1);
		}
	}

	public int GetTotalNumberOfHousesVisited() => this.visitedHouses.Count;

	public List<Point> GetAllVisitedHomeLocations() => this.visitedHouses.Keys.ToList();
}
