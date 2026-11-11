#include "TriangleSolver.h"
#include <iostream>
#include <sstream>
#include <array>

TriangleSolver::TriangleSolver(const std::vector<std::string>& triangleData)
{
	this->triangleData = triangleData;

	this->triangles.reserve(triangleData.size());
	std::transform(triangleData.begin(), triangleData.end(), std::back_inserter(this->triangles), [](const std::string& line) {
		std::istringstream iss(line);
		int a, b, c;
		iss >> a >> b >> c;
		return Triangle(a, b, c);
	});
}

unsigned int TriangleSolver::GetPossibleTrianglesCount() const
{
	unsigned int possibleTriangles = 0;
	for (const Triangle& triangle : this->triangles)
	{
		if (triangle.sortedSides[0] + triangle.sortedSides[1] > triangle.sortedSides[2])
		{
			++possibleTriangles;
		}
	}

	return possibleTriangles;
}

std::array<int, 3> SplitTriangleData(const std::string& line)
{
	std::array<int, 3> triangleComponents;
	std::istringstream iss(line);
	iss >> triangleComponents[0] >> triangleComponents[1] >> triangleComponents[2];
	return triangleComponents;
}

unsigned int TriangleSolver::GetPossibleVerticalTrianglesCount()
{
	// Truthfully the faster / more efficient way of doing this would be to process the data as it's being read in from the file,
	// but alas... Trying to maintain reusability, and there's not a strong need to be hyper efficient here
	this->triangles.clear();

	for (int i = 0; i < this->triangleData.size(); i += 3)
	{
		std::array<int, 3> firstRow = SplitTriangleData(this->triangleData[i]);
		std::array<int, 3> secondRow = SplitTriangleData(this->triangleData[i + 1]);
		std::array<int, 3> thirdRow = SplitTriangleData(this->triangleData[i + 2]);

		this->triangles.push_back(Triangle(firstRow[0], secondRow[0], thirdRow[0]));
		this->triangles.push_back(Triangle(firstRow[1], secondRow[1], thirdRow[1]));
		this->triangles.push_back(Triangle(firstRow[2], secondRow[2], thirdRow[2]));		
	}

	return this->GetPossibleTrianglesCount();
}