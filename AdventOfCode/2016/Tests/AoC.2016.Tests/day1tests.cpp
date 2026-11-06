#include "pch.h"

#include "DirectionParser.h"
#include "StreetGrid.h"

namespace AdventOfCode::CY2016::TestData
{
	std::vector<Direction> firstRoute{ { false, 2 },{ true, 3 } };
	std::vector<Direction> secondRoute{ { false, 2 },{ false, 2 },{ false, 2 } };
	std::vector<Direction> thirdRoute{ { false, 5 },{ true, 5 },{ false, 5 },{ false, 3 } };
}

struct DirectionParserTestData
{
	std::string input;
	std::vector<Direction> expectedDirections;
};

class DirectionParserTest : public ::testing::TestWithParam<DirectionParserTestData> {};

TEST_P(DirectionParserTest, VerifyInputParsing)
{
	const DirectionParserTestData& data = GetParam();

	DirectionParser parser;
	std::vector<Direction> actualDirections = parser.ParseInputForDirections(data.input);
	EXPECT_EQ(actualDirections, data.expectedDirections);
}

INSTANTIATE_TEST_CASE_P(
	GivenValidInput_ReturnsExpectedData,
	DirectionParserTest,
	::testing::Values(
		DirectionParserTestData{ "R2, L3", AdventOfCode::CY2016::TestData::firstRoute },
		DirectionParserTestData{ "R2, R2, R2", AdventOfCode::CY2016::TestData::secondRoute },
		DirectionParserTestData{ "R5, L5, R5, R3", AdventOfCode::CY2016::TestData::thirdRoute })
);

struct StreetGridTestData
{
	std::vector<Direction> directions;
	int expectedPathDistance;
};

class StreetGridTest : public ::testing::TestWithParam<StreetGridTestData> {};

TEST_P(StreetGridTest, GivenTestData_ReturnsExpectedResult)
{
	const StreetGridTestData& data = GetParam();

	StreetGrid streetGrid(data.directions);
	int actualPath = streetGrid.CalculateShortestPath();
	EXPECT_EQ(actualPath, data.expectedPathDistance);
}

INSTANTIATE_TEST_CASE_P(
	StreetGridTests,
	StreetGridTest,
	::testing::Values(
		StreetGridTestData{ AdventOfCode::CY2016::TestData::firstRoute, 5 },
		StreetGridTestData{ AdventOfCode::CY2016::TestData::secondRoute, 2 },
		StreetGridTestData{ AdventOfCode::CY2016::TestData::thirdRoute, 12 })
);

TEST(CalculateShortestPathToRealBunnyHQ_GivenValidData_CalculatesCorrectDistance)
{
	StreetGridTestData data{ { { false, 8 },{ false, 4 },{ false, 4 },{ false, 8 } }, 4 };

	StreetGrid streetGrid(data.directions);
	int actualPath = streetGrid.CalculateShortestPathToRealBunnyHQ();
	EXPECT_EQ(actualPath, data.expectedPathDistance);
}


int main(int argc, char** argv)
{
	testing::InitGoogleTest(&argc, argv);
	return RUN_ALL_TESTS();
}