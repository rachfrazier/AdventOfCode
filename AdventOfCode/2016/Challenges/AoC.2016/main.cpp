#include "DirectionParser.h"
#include <iostream>

int main()
{
	DirectionParser parser;
	std::vector<Direction> directions = parser.ParseInputForDirections(parser.ReadInput());
	StreetGrid grid(directions);
	std::cout << "Part One answer: " << grid.CalculateShortestPath() << std::endl;
	std::cout << "Part Two answer: " << grid.CalculateShortestPathToRealBunnyHQ() << std::endl;
	return 0;
}