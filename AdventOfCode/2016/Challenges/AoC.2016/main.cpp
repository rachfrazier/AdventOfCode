#include "DirectionParser.h"
#include <iostream>

int main()
{
	DirectionParser parser;
	std::vector<Direction> directions = parser.ParseInputForDirections(parser.ReadInput());
	StreetGrid grid(directions);
	std::cout << grid.CalculateShortestPath() << std::endl;
	return 0;
}