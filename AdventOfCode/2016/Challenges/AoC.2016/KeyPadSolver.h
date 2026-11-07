#pragma once

#include <string>
#include <vector>

class KeyPadSolver
{
public:
	KeyPadSolver(const std::vector<std::string>& instructions);
	std::string FindBathroomCode();

private:
	std::vector<std::string> instructions;
	char keypad[3][3] = { { '1', '2', '3' },{ '4', '5', '6' },{ '7', '8', '9' } };
};