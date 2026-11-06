#include "StreetGrid.h"
#include "CommonDataObjects.h"
#include <set>

StreetGrid::StreetGrid(const std::vector<Direction>& directions) : directions(directions) {};

int StreetGrid::CalculateShortestPath()
{
	Point location;

	// 0 - N, 1 - E, 2 - S, 3 - W
	int compassDirection = 0;

	Direction previousDirection;
	int i = 0;
	do
	{
		switch (compassDirection)
		{
		case 0:
			location.x += this->directions[i].turnLeft ? -this->directions[i].numberSteps : this->directions[i].numberSteps;
			break;
		case 1:
			location.y += this->directions[i].turnLeft ? this->directions[i].numberSteps : -this->directions[i].numberSteps;
			break;
		case 2:
			location.x += this->directions[i].turnLeft ? this->directions[i].numberSteps : -this->directions[i].numberSteps;
			break;
		case 3:
			location.y += this->directions[i].turnLeft ? -this->directions[i].numberSteps : this->directions[i].numberSteps;
			break;
		default:
			break;
		}

		previousDirection = this->directions[i];
		compassDirection = previousDirection.turnLeft ? (compassDirection + 3) % 4 : (compassDirection + 1) % 4;
	} while (++i < directions.size());

	return std::abs(location.x) + std::abs(location.y);
}

void WalkThePath(Point& hqLocation, std::set<Point>& visitedLocations, const Direction& direction, bool& foundDupe, int compassDir)
{
	for (int x = 0; x < direction.numberSteps; ++x)
	{
		switch (compassDir)
		{
		case 0:
			hqLocation.x += direction.turnLeft ? -1 : 1;
			break;
		case 1:
			hqLocation.y += direction.turnLeft ? 1 : -1;
			break;
		case 2:
			hqLocation.x += direction.turnLeft ? 1 : -1;
			break;
		case 3:
			hqLocation.y += direction.turnLeft ? -1 : 1;
			break;
		default:
			break;
		}

		if (!(visitedLocations.insert(hqLocation).second))
		{
			foundDupe = true;
			break;
		}
	}
}

int StreetGrid::CalculateShortestPathToRealBunnyHQ()
{
	Point hqLocation;
	std::set<Point> visitedLocations;
	visitedLocations.insert(hqLocation);

	// 0 - N, 1 - E, 2 - S, 3 - W
	int compassDirection = 0;

	Direction previousDirection;
	bool foundDupe = false;
	int i = 0;
	do
	{
		WalkThePath(hqLocation, visitedLocations, directions[i], foundDupe, compassDirection);
		if (foundDupe)
		{
			break;
		}

		previousDirection = this->directions[i];
		compassDirection = previousDirection.turnLeft ? (compassDirection + 3) % 4 : (compassDirection + 1) % 4;
	} while (++i < directions.size());

	return std::abs(hqLocation.x) + std::abs(hqLocation.y);
}