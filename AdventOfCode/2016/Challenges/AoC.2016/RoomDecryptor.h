#pragma once

#include <array>
#include <string>
#include <vector>

struct DecryptedLine
{
	static const unsigned int ASCII_a = 97;
	static const unsigned int ASCII_z = 122;

	std::array<unsigned int, 26> numCharacters{ 0 };
	unsigned int sectorID = 0;
	std::string checksum{};

	bool operator==(const DecryptedLine& other) const
	{
		return this->numCharacters == other.numCharacters && this->sectorID == other.sectorID && this->checksum == other.checksum;
	}

	const unsigned int& GetAlphabeticalValue(const char letter) const
	{
		return this->numCharacters[letter - ASCII_a];
	}
};

class RoomDecryptor
{
public:
	RoomDecryptor(const std::vector<std::string>& encryptedLines);
	unsigned int GetSectorIDSumOfRealRooms();

private:
	friend class RoomDecryptorTest;
	DecryptedLine DecryptLine(const std::string& line) const;
	bool IsValidRoom(const DecryptedLine& line) const;

	std::vector<std::string> encryptedLines;
};