#include "RoomDecryptor.h"

RoomDecryptor::RoomDecryptor(const std::vector<std::string>& encryptedLines) : encryptedLines(encryptedLines) {}

unsigned int RoomDecryptor::GetSectorIDSumOfRealRooms()
{
	unsigned int total = 0;
	for (const std::string& line : this->encryptedLines)
	{
		DecryptedLine decryptedLine = this->DecryptLine(line);
		if (this->IsValidRoom(decryptedLine))
		{
			total += decryptedLine.sectorID;
		}
	}

	return total;
}

std::string ExtractChecksum(const std::string& line)
{
	int beginSquareBracketIndex = line.find_first_of('[');
	int endSquareBracketIndex = line.find_first_of(']');
	return line.substr(beginSquareBracketIndex + 1, endSquareBracketIndex - beginSquareBracketIndex - 1);
}

DecryptedLine RoomDecryptor::DecryptLine(const std::string& line) const
{

	DecryptedLine decryptedLine;
	decryptedLine.checksum = ExtractChecksum(line);
	for (int i = 0; i < line.size(); ++i)
	{
		if (line[i] >= DecryptedLine::ASCII_a && line[i] <= DecryptedLine::ASCII_z)
		{
			decryptedLine.numCharacters[line[i] - DecryptedLine::ASCII_a]++;
		}
		else if (line[i] == '-')
		{
			continue;
		}
		else
		{
			int beginSquareBracketIndex = line.find_first_of('[');
			decryptedLine.sectorID = std::stoi(line.substr(i, beginSquareBracketIndex - i));
			break;
		}
	}

	return decryptedLine;
}

bool RoomDecryptor::IsValidRoom(const DecryptedLine& line) const
{
	for (int i = 0; i < line.checksum.size() - 1; ++i)
	{
		if (line.GetAlphabeticalValue(line.checksum[i]) < line.GetAlphabeticalValue(line.checksum[i + 1]))
		{
			return false;
		}
	}

	return true;
}