#include "pch.h"

#include "KeyPadSolver.h"

namespace AdventOfCode::CY2016::Tests::Day2
{

	class KeyPadSolverTest : public ::testing::Test
	{
	protected:
		KeyPadSolverTest() : keypadSolver(this->input)
		{
		}

		std::vector<std::string> input =
		{
			{ "ULL" },
			{ "RRDDD" },
			{ "LURDL" },
			{ "UUUUD" }
		};

		KeyPadSolver keypadSolver;
	};
	
	TEST_F(KeyPadSolverTest, PartOneTestCase)
	{
		std::string actual = keypadSolver.FindBathroomCode();
		EXPECT_EQ(actual, "1985");
	}
	
	TEST_F(KeyPadSolverTest, PartTwoTestCase)
	{
		std::string actual = keypadSolver.FindFancyBathroomCode();
		EXPECT_EQ(actual, "5DB3");
	}
}