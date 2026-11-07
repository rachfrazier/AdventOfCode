#include "DirectionParser.h"

#include <fstream>
#include <sstream>
#include "InputParser.h"

std::string DirectionParser::ReadInput()
{
	std::ifstream stream("inputs/day1input.txt");
	if (!stream.is_open())
	{
		return "File could not be found";
	}

	std::string content((std::istreambuf_iterator<char>(stream)), std::istreambuf_iterator<char>());
	return content;
}

std::vector<Direction> DirectionParser::ParseInputForDirections(const std::string& input)
{
	std::vector<Direction> directions;

	std::istringstream lineSegment(input);
	for (std::string line; std::getline(lineSegment, line, ',');)
	{
		AdventOfCode::Common::InputParser::TrimWhitespace(line);

		Direction direction;
		if (line[0] == 'R')
		{
			direction.turnLeft = false;
		}

		direction.numberSteps = std::stoi(line.substr(1, line.size()));
		directions.push_back(direction);
	}

	return directions;
}
