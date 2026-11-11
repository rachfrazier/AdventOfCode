#pragma once

#include <vector>
#include <string>
#include <set>
#include <algorithm>

struct Triangle
{
	Triangle(int a, int b, int c)
	{
		if (a > b) std::swap(a, b);
		if (b > c) std::swap(b, c);
		if (a > b) std::swap(a, b); // Ensure 'a' is still smaller than the new 'b'

		sortedSides[0] = a;
		sortedSides[1] = b;
		sortedSides[2] = c; 
	}

	int sortedSides[3];
};

class TriangleSolver
{
public:
	TriangleSolver(const std::vector<std::string>& triangleData);
	unsigned int GetPossibleTrianglesCount() const;
	unsigned int GetPossibleVerticalTrianglesCount();

private:
	std::vector<Triangle> triangles;
	std::vector<std::string> triangleData;
};