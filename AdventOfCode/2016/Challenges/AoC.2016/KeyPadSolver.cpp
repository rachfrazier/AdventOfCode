#include "KeyPadSolver.h"

#include <sstream>

#include "CommonDataObjects.h"

KeyPadSolver::KeyPadSolver(const std::vector<std::string>& instructions) : instructions(instructions) {}

std::string KeyPadSolver::FindBathroomCode()
{
	std::stringstream code;
	Grid2D currentPosition{ 1,1 };

	for (const std::string& instructionSet : this->instructions)
	{
		for (const char instruction : instructionSet)
		{
			switch (instruction)
			{
			case 'U':
				currentPosition.row = std::max(0, currentPosition.row - 1);
				break;
			case 'D':
				currentPosition.row = std::min(2, currentPosition.row + 1);
				break;
			case 'L':
				currentPosition.column = std::max(0, currentPosition.column - 1);
				break;
			case 'R':
				currentPosition.column = std::min(2, currentPosition.column + 1);
				break;
			default:
				break;
			}
		}

		code.put(this->keypad[currentPosition.row][currentPosition.column]);
	}

	return code.str();
}