#pragma once

struct Point
{
	int x = 0;
	int y = 0;

	auto operator<=>(const Point& other) const = default;
};