using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015;

internal class InputParser(string input)
{
    public Vector3 ExtractVector()
    {
        string[] result = input.Split('x');
        return new Vector3(int.Parse(result[0]), int.Parse(result[1]), int.Parse(result[2]));
    }
}

internal class Rectangle(Vector3 dimensions)
{
    float length => dimensions.X;
    float width => dimensions.Y;
    float height => dimensions.Z;

    public float CalculateSurfaceArea() =>
        2 * length * width + 2 * width * height + 2 * height * length;

    public float GetSmallestSideArea()
    {
        float[] multiplicities = { length * width, width * height, height * length };
        return multiplicities.Min();
    }

    public float CalculateVolume() => length * width * height;

    public float GetSmallestRibbonLength() => this.CalculateVolume() + this.GetSmallestPerimeter();

    public float GetSmallestPerimeter()
    {
        float[] perimeters = { (2 * length) + (2* width), (2 * height) + (2 * width), (2 * length) + (2 * height) };
        return perimeters.Min();
    }
}

internal class Day2
{
    public static float SolvePartOne(List<string> input)
    {
        float totalSquareFeet = 0.0f;
        foreach(string line in input)
        {
            Rectangle rectangle = new Rectangle(new InputParser(line).ExtractVector());
            totalSquareFeet += rectangle.CalculateSurfaceArea() + rectangle.GetSmallestSideArea();
        }

        return totalSquareFeet;
    }

    public static float SolvePartTwo(List<string> input)
    {
        float totalRibbonLength = 0.0f;
        foreach(string line in input)
        {
            Rectangle rectangle = new Rectangle(new InputParser(line).ExtractVector());
            totalRibbonLength += rectangle.GetSmallestRibbonLength();
        }

        return totalRibbonLength;
    }
}
