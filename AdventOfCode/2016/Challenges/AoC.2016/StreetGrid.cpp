#include "StreetGrid.h"

StreetGrid::StreetGrid(const std::vector<Direction>& directions) : directions(directions) {};

int StreetGrid::CalculateShortestPath()
{
	int xPos = 0;
	int yPos = 0;

	// 0 - N, 1 - E, 2 - S, 3 - W
	int direction = 0;

	Direction previousDirection = directions[0];
	xPos += previousDirection.turnLeft ? -previousDirection.numberSteps : previousDirection.numberSteps;
	direction = previousDirection.turnLeft ? (direction + 3) % 4 : (direction + 1) % 4;

	for (int i = 1; i < directions.size(); ++i)
	{
		switch (direction)
		{
		case 0:
			xPos += directions[i].turnLeft ? -directions[i].numberSteps : directions[i].numberSteps;
			break;
		case 1:
			yPos += directions[i].turnLeft ? directions[i].numberSteps : -directions[i].numberSteps;
			break;
		case 2:
			xPos += directions[i].turnLeft ? directions[i].numberSteps : -directions[i].numberSteps;
			break;
		case 3:
			yPos += directions[i].turnLeft ? -directions[i].numberSteps : directions[i].numberSteps;
			break;
		default:
			break;
		}

		previousDirection = directions[i];
		direction = previousDirection.turnLeft ? (direction + 3) % 4 : (direction + 1) % 4;
	}

	return std::abs(xPos) + std::abs(yPos);
}