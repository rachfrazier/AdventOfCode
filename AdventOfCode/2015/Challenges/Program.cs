using AdventOfCode2015;

FloorCalculator calculator = new(File.ReadAllText("inputs/day1input.txt"));
Console.WriteLine($"Final floor is {calculator.CalculateFinalFloor()}");
Console.WriteLine($"First time visiting basement occurs at position {calculator.FindFirstBasementVisitPosition()}");
