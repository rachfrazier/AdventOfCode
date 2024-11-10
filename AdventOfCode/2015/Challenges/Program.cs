using AdventOfCode2015;

//FloorCalculator calculator = new(File.ReadAllText("inputs/day1input.txt"));
//Console.WriteLine($"Final floor is {calculator.CalculateFinalFloor()}");
//Console.WriteLine($"First time visiting basement occurs at position {calculator.FindFirstBasementVisitPosition()}");

//List<string> day2input = new((await File.ReadAllTextAsync("inputs/day2input.txt").ConfigureAwait(false)).Split('\n'));
//Console.WriteLine(Day2.SolvePartOne(day2input.Where(i => !string.IsNullOrEmpty(i)).ToList()));
//Console.WriteLine(Day2.SolvePartTwo(day2input.Where(i => !string.IsNullOrEmpty(i)).ToList()));

Day3 day3 = new();
Console.WriteLine(day3.SolvePresentMap(File.ReadAllText("inputs/day3input.txt")));