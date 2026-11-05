#pragma once

#include <vector>

struct Direction
{
	bool turnLeft = true;
	int numberSteps = 0;

	bool operator==(const Direction& other) const
	{
		return this->turnLeft == other.turnLeft && this->numberSteps == other.numberSteps;
	}
};

class StreetGrid
{
public:


private:
	std::vector<Direction> directions;
};