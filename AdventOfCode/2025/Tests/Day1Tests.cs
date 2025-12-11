namespace AoC._2025.Tests;

[TestClass]
public class Day1Tests
{
	private SafeDial safeDial;

	[TestInitialize]
	public void TestInitialize()
	{
		this.safeDial = new SafeDial();
	}

	[TestMethod]
	[DataRow(10, 40)]
	[DataRow(50, 0)]
	[DataRow(60, 90)]
	[DataRow(255, 95)]
	public void RotateLeft_GivenRotations_SetsCurrentValueCorrectly(int rotation, int expected)
	{
		safeDial.RotateLeft(rotation);
		Assert.AreEqual(expected, safeDial.currentPosition);
	}

	[TestMethod]
	[DataRow(10, 60)]
	[DataRow(50, 0)]
	[DataRow(49, 99)]
	[DataRow(60, 10)]
	[DataRow(255, 5)]
	public void RotateRight_GivenRotations_SetCurrentValueCorrectly(int rotation, int expected)
	{
		safeDial.RotateRight(rotation);
		Assert.AreEqual(expected, safeDial.currentPosition);
	}

	[TestMethod]
	public void GetDoorPassword_AfterRotationSequence_ReturnsExpectedResult()
	{
		safeDial.RotateLeft(68);
		safeDial.RotateLeft(30);
		safeDial.RotateRight(48);
		safeDial.RotateLeft(5);
		safeDial.RotateRight(60);
		safeDial.RotateLeft(55);
		safeDial.RotateLeft(1);
		safeDial.RotateLeft(99);
		safeDial.RotateRight(14);
		safeDial.RotateLeft(82);
		Assert.AreEqual(expected: 3u, safeDial.GetDoorPassword());
	}

	[TestMethod]
	public void PuzzleSolver_SolveWithTestInputForPart1_ReturnsExpectedValue()
	{
		string input = "L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82\n";
		PuzzleSolver solver = new();
		Assert.AreEqual(expected: 3u, solver.Solve(input));
	}

	[TestMethod]
	public void PuzzleSolver_SolveWithTestInputForPart2_ReturnsExpectedValue()
	{
		string input = "L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82\n";
		PuzzleSolver solver = new();
		Assert.AreEqual(expected: 6u, solver.Solve2(input));
	}
}