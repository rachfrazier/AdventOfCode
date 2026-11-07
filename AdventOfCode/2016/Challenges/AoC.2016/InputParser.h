#pragma once

#include <vector>
#include <string>

namespace AdventOfCode::Common
{
	class InputParser
	{
	public:
		static std::vector<std::string> GetAllLines(const std::string_view& fileName, char delimiter);
		static void TrimWhitespace(std::string& line);
	};
}