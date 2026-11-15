#include "pch.h"

#include "RoomDecryptor.h"
#include <map>

struct RoomDecryptorTestData
{
	RoomDecryptorTestData(
		const std::string& encryptedLine,
		const std::map<unsigned int, unsigned int>& arrayInput,
		unsigned int sectorID,
		const std::string& checksum,
		bool isValidRoom)
	{
		this->encryptedLine = encryptedLine;
		this->expectedOutput.sectorID = sectorID;
		this->expectedOutput.checksum = checksum;
		this->isValidRoom = isValidRoom;

		for (const auto& kvp : arrayInput)
		{
			this->expectedOutput.numCharacters[kvp.first] = kvp.second;
		}
	}

	std::string encryptedLine;
	DecryptedLine expectedOutput;
	bool isValidRoom;
};

class RoomDecryptorTest : public ::testing::TestWithParam<RoomDecryptorTestData>
{
protected:
	RoomDecryptorTest() : roomDecryptor({ "" }) {}
	RoomDecryptor roomDecryptor;

	DecryptedLine DecryptLineInternal(const std::string& encryptedLine)
	{
		return roomDecryptor.DecryptLine(encryptedLine);
	}

	bool IsValidRoomInternal(const DecryptedLine& line)
	{
		return roomDecryptor.IsValidRoom(line);
	}
};

TEST_P(RoomDecryptorTest, DecryptLineReturnsExpectedObject)
{
	const RoomDecryptorTestData& data = GetParam();

	EXPECT_EQ(DecryptLineInternal(data.encryptedLine), data.expectedOutput);
}

TEST_P(RoomDecryptorTest, IsValidRoomReturnsExpectedResult)
{
	const RoomDecryptorTestData& data = GetParam();

	EXPECT_EQ(IsValidRoomInternal(data.expectedOutput), data.isValidRoom);
}

INSTANTIATE_TEST_CASE_P(
	DecryptLine,
	RoomDecryptorTest,
	::testing::Values(
		RoomDecryptorTestData("aaaaa-bbb-z-y-x-123[abxyz]",
			{ { 'a' - DecryptedLine::ASCII_a, 5 },
			  { 'b' - DecryptedLine::ASCII_a, 3 },
			  { 'x' - DecryptedLine::ASCII_a, 1 },
			  { 'y' - DecryptedLine::ASCII_a, 1 },
			  { 'z' - DecryptedLine::ASCII_a, 1 } },
			123, "abxyz", true),
		RoomDecryptorTestData("a-b-c-d-e-f-g-h-987[abcde]",
			{ { 'a' - DecryptedLine::ASCII_a, 1 },
			  { 'b' - DecryptedLine::ASCII_a, 1 },
			  { 'c' - DecryptedLine::ASCII_a, 1 },
			  { 'd' - DecryptedLine::ASCII_a, 1 },
			  { 'e' - DecryptedLine::ASCII_a, 1 },
			  { 'f' - DecryptedLine::ASCII_a, 1 },
			  { 'g' - DecryptedLine::ASCII_a, 1 },
			  { 'h' - DecryptedLine::ASCII_a, 1 } },
			987, "abcde", true),
		RoomDecryptorTestData("not-a-real-room-404[oarel]",
			{ { 'n' - DecryptedLine::ASCII_a, 1 },
			  { 'o' - DecryptedLine::ASCII_a, 3 },
			  { 't' - DecryptedLine::ASCII_a, 1 },
			  { 'a' - DecryptedLine::ASCII_a, 2 },
			  { 'r' - DecryptedLine::ASCII_a, 2 },
			  { 'e' - DecryptedLine::ASCII_a, 1 },
			  { 'l' - DecryptedLine::ASCII_a, 1 },
			  { 'm' - DecryptedLine::ASCII_a, 1 } },
			404, "oarel", true),
		RoomDecryptorTestData("totally-real-room-200[decoy]",
			{ { 't' - DecryptedLine::ASCII_a, 2 },
			  { 'o' - DecryptedLine::ASCII_a, 3 },
			  { 'a' - DecryptedLine::ASCII_a, 2 },
			  { 'l' - DecryptedLine::ASCII_a, 3 },
			  { 'y' - DecryptedLine::ASCII_a, 1 },
			  { 'r' - DecryptedLine::ASCII_a, 2 },
			  { 'e' - DecryptedLine::ASCII_a, 1 },
			  { 'm' - DecryptedLine::ASCII_a, 1 } },
			200, "decoy", false))
);

TEST(RoomDecryptorTests, GetSectorIDSumOfRealRoomsReturnsCorrectResultPartOne)
{
	std::vector<std::string> input
	{
		"aaaaa-bbb-z-y-x-123[abxyz]",
		"a-b-c-d-e-f-g-h-987[abcde]",
		"not-a-real-room-404[oarel]",
		"totally-real-room-200[decoy]"
	};
	RoomDecryptor roomDecryptor(input);

	EXPECT_EQ(roomDecryptor.GetSectorIDSumOfRealRooms(), 1514);
}