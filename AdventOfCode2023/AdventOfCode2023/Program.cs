// See https://aka.ms/new-console-template for more information
/*
The newly-improved calibration document consists of lines of text; each line originally contained
a specific calibration value that the Elves now need to recover. On each line, the calibration value
can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.

For example:

1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet
In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.

Consider your entire calibration document. What is the sum of all of the calibration values?
 * 
 * 
 */
using AdventOfCode2023;

//// Day 1
//List<string> dayOneInput = new List<string>(await File.ReadAllLinesAsync("inputs/day1input.txt").ConfigureAwait(false));

//int GetDayOneSolution(Func<string, (char, char)> partToExecute)
//{
//    int sum = 0;
//    foreach (string line in dayOneInput)
//    {
//        (char First, char Second) result = partToExecute(line);
//        sum += Day1.ConvertDigitsToCombinedNumber(result.First, result.Second);
//    }

//    return sum;
//}

//Console.WriteLine($"Final sum for part 1 is {GetDayOneSolution(Day1.ExtractNumbers)}");
//Console.WriteLine($"Final sum for part 2 is {GetDayOneSolution(Day1.ExtractNumbersP2)}");

//// Day 2
//List<string> dayTwoInput = new List<string>(await File.ReadAllLinesAsync("inputs/day2input.txt").ConfigureAwait(false));
//Console.WriteLine(Day2.SumIDsOfValidGames(dayTwoInput));
//int partTwoSum = 0;
//List<SetOfCubes> minSetsOfCubes = Day2.GetMinPossibleSetOfCubesPerGame(dayTwoInput);
//foreach (SetOfCubes set in minSetsOfCubes)
//{
//    partTwoSum += (set.Red * set.Green * set.Blue);
//}
//Console.WriteLine($"Sum for part two is {partTwoSum}");

//// Day 3
//List<string> input = File.ReadLines("inputs/day3input.txt").ToList();
//Console.WriteLine($"Sum of part numbers: {Day3.SumPartNumbers(input)}");
//Console.WriteLine($"Sum of gear numbers: {Day3.SumGearNumbers(input)}");

// Day 4
List<string> day4Input = File.ReadLines("inputs/day4input.txt").ToList();
Console.WriteLine($"Sum is {Day4.CalculateScratchcardPoints(day4Input)}");
Console.WriteLine($"Total scratch cards are {Day4.CaculateTotalScratchCards(day4Input)}");