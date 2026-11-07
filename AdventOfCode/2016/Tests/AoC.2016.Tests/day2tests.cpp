#include "pch.h"

#include "KeyPadSolver.h"

namespace AdventOfCode::CY2016::Tests::Day2
{
	TEST(KeyPadSolverTests, FindBathroomCode_GivenTestInput_ReturnsExpectedResult)
	{
		std::vector<std::string> input =
		{
			{ "ULL" },
			{ "RRDDD" },
			{ "LURDL" },
			{ "UUUUD" }
		};

		KeyPadSolver keypadSolver(input);
		std::string actual = keypadSolver.FindBathroomCode();
		EXPECT_EQ(actual, "1985");
	}
}