#include "RoomDecryptor.h"

#include <unordered_set>
#include <algorithm>
#include <map>
#include <iostream>
#include <utility>

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
	std::vector<std::pair<int, unsigned int>> sortedValuesByCount;
	for (int i = 0; i < 26; ++i)
	{
		if (line.numCharacters[i] > 0)
		{
			sortedValuesByCount.push_back({ i, line.numCharacters[i] });
		}
	}
	std::sort(sortedValuesByCount.begin(), sortedValuesByCount.end(), [](const auto& a, const auto& b) { return a.second > b.second; });
	int count = 0;
	for (const auto& value : sortedValuesByCount)
	{
		if (line.checksum.find(value.first + DecryptedLine::ASCII_a) == std::string::npos)
		{
			return false;
		}

		if (++count >= 5)
		{
			break;
		}
	}
	

	std::map<unsigned int, std::vector<char>> tiedItems;
	for (int i = 0; i < line.checksum.size() - 1; ++i)
	{
		const unsigned int& firstCount = line.GetAlphabeticalValue(line.checksum[i]);
		const unsigned int& secondCount = line.GetAlphabeticalValue(line.checksum[i + 1]);

		if (firstCount == secondCount)
		{
			if (std::find(tiedItems[firstCount].begin(), tiedItems[firstCount].end(), line.checksum[i]) == tiedItems[firstCount].end())
				tiedItems[firstCount].push_back(line.checksum[i]);
			if (std::find(tiedItems[firstCount].begin(), tiedItems[firstCount].end(), line.checksum[i + 1]) == tiedItems[firstCount].end())
				tiedItems[firstCount].push_back(line.checksum[i + 1]);
			if (!std::is_sorted(tiedItems[firstCount].begin(), tiedItems[firstCount].end()))
			{
				return false;
			}
		}
		else if (firstCount < secondCount)
		{
			return false;
		}
	}

	return true;
}