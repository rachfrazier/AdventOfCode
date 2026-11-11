#include "pch.h"

#include "TriangleSolver.h"

TEST(TriangleSolverTests, GetPossibleTriangleCount_WithPartOneData_ReturnsExpectedResult)
{
	TriangleSolver triangleSolver({ "5 10 25" });
	EXPECT_EQ(triangleSolver.GetPossibleTrianglesCount(), 0);
}

TEST(TriangleSolverTests, GetPossibleVerticalTriangleCount_WithPartTwoTestData_ReturnsExpectedResult)
{
	TriangleSolver triangleSolver(
	{
		{ "101 301 501" },
		{ "102 302 502" },
		{ "103 303 503" },
		{ "201 401 601" },
		{ "201 402 602" },
		{ "201 403 603" }
	});
	EXPECT_EQ(triangleSolver.GetPossibleVerticalTrianglesCount(), 6);
}