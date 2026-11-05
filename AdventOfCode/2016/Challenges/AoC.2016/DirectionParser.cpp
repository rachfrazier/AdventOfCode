#include "DirectionParser.h"

#include <fstream>
#include <sstream>

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
		TrimWhitespace(line);

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

void DirectionParser::TrimWhitespace(std::string& line)
{
	size_t whiteSpacePos = line.find(' ');
	if (whiteSpacePos != std::string::npos)
	{
		line.erase(line.begin());
	}
}
