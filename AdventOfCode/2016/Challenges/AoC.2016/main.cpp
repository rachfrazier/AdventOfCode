#include <iostream>

#include "DirectionParser.h"
#include "InputParser.h"
#include "KeyPadSolver.h"

void ExecuteDayOne()
{
	DirectionParser parser;
	std::vector<Direction> directions = parser.ParseInputForDirections(parser.ReadInput());
	StreetGrid grid(directions);
	std::cout << "Part One answer: " << grid.CalculateShortestPath() << std::endl;
	std::cout << "Part Two answer: " << grid.CalculateShortestPathToRealBunnyHQ() << std::endl;
}

void ExecuteDayTwo()
{
	std::vector<std::string> instructions = AdventOfCode::Common::InputParser::GetAllLines("inputs/day2input.txt", '\n');
	KeyPadSolver keypadSolver(instructions);
	std::cout << "Bathroom code is " << keypadSolver.FindBathroomCode() << std::endl;
}

int main(int argc, char** argv)
{
	if (argc > 1)
	{
		switch (*(argv[1]))
		{
		case '1':
			ExecuteDayOne();
			break;
		case '2':
			ExecuteDayTwo();
			break;
		default:
			ExecuteDayOne();
			break;
		}
	}

	return 0;
}