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

List<string> input = new List<string>(await File.ReadAllLinesAsync("input.txt").ConfigureAwait(false));
int sum = 0;
foreach (string line in input)
{
    (char First, char Second) result = Day1.ExtractNumbers(line);
    int numberVal = Day1.ConvertDigitsToCombinedNumber(result.First, result.Second);
    sum += numberVal;
}

Console.WriteLine($"Final sum is {sum}");
