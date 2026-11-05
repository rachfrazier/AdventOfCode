#include "pch.h"

#include "DirectionParser.h"

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
		DirectionParserTestData{ "R2, L3",{ { false, 2 },{ true, 3 } } },
		DirectionParserTestData{ "R2, R2, R2",{ { false, 2 },{ false, 2 },{ false, 2 } } },
		DirectionParserTestData{ "R5, L5, R5, R3",{ { false, 5 },{ true, 5 },{ false, 5 },{ false, 3 } } })
);

int main(int argc, char** argv)
{
	testing::InitGoogleTest(&argc, argv);
	return RUN_ALL_TESTS();
}