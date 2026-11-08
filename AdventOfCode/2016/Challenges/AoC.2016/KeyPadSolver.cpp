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

std::string KeyPadSolver::FindFancyBathroomCode()
{
	std::stringstream code;
	Grid2D currentPosition{2, 0};
	
	for (const std::string& instructionSet : this->instructions)
	{
		for (const char instruction : instructionSet)
		{
			Grid2D newPosition = currentPosition;
			switch (instruction)
			{
			case 'U':
				newPosition.row = std::max(0, currentPosition.row - 1);
				break;
			case 'D':
				newPosition.row = std::min(4, currentPosition.row + 1);
				break;
			case 'L':
				newPosition.column = std::max(0, currentPosition.column - 1);
				break;
			case 'R':
				newPosition.column = std::min(4, currentPosition.column + 1);
				break;
			default:
				break;
			}
			
			if (this->fancyKeypad[newPosition.row][newPosition.column] != '0')
			{
				currentPosition = newPosition;
			}
		}

		code.put(this->fancyKeypad[currentPosition.row][currentPosition.column]);
	}

	return code.str();
}