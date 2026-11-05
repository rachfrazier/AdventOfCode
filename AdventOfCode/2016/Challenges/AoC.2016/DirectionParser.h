#pragma once

#include "StreetGrid.h"
#include <vector>
#include <string>

class DirectionParser
{
public:
	std::string ReadInput();
	std::vector<Direction> ParseInputForDirections(const std::string& input);

private:
	void TrimWhitespace(std::string& line);
};