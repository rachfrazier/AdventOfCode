#pragma once

#include <string>
#include <vector>

class KeyPadSolver
{
public:
	KeyPadSolver(const std::vector<std::string>& instructions);
	std::string FindBathroomCode();
	std::string FindFancyBathroomCode();

private:
	std::vector<std::string> instructions;
	char keypad[3][3] = { { '1', '2', '3' },{ '4', '5', '6' },{ '7', '8', '9' } };
	char fancyKeypad[5][5] = {
	{ '0', '0', '1', '0', '0' },
	{ '0', '2', '3', '4', '0' },
	{ '5', '6', '7', '8', '9' }, 
	{ '0', 'A', 'B', 'C', '0'},
	{ '0', '0', 'D', '0', '0' }
	};
};
