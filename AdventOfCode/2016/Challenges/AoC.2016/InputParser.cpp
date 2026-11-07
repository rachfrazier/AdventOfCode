#include "InputParser.h"

#include <fstream>

using namespace AdventOfCode::Common;

std::vector<std::string> InputParser::GetAllLines(const std::string_view& fileName, char delimiter)
{
	std::vector<std::string> lines;
	std::ifstream file(fileName.data());
	if (!file.is_open())
	{
		return lines;
	}
	
	std::string line;
	while (std::getline(file, line))
	{
		lines.push_back(line);
	}

	return lines;
}

void InputParser::TrimWhitespace(std::string& line)
{
	size_t whiteSpacePos = line.find(' ');
	if (whiteSpacePos != std::string::npos)
	{
		line.erase(line.begin());
	}
}
