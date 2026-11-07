#pragma once

struct Point
{
	int x = 0;
	int y = 0;

	auto operator<=>(const Point& other) const = default;
};

struct Grid2D
{
	int row = 0;
	int column = 0;

	auto operator<=>(const Grid2D& other) const = default;
};