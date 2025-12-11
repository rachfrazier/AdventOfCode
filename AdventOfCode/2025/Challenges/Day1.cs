using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using AoC.Common;

namespace AoC._2025;
internal class SafeDial
{
	private const int MaxDialValue = 99;
	private const int MinDialValue = 0;

	private uint numRotationsLeftAtZero = 0;
	internal int currentPosition = 50;

	public uint GetDoorPassword() => this.numRotationsLeftAtZero;

	public void RotateRight(int rotation)
	{
		this.currentPosition += rotation;
		if (this.currentPosition > MaxDialValue)
		{
			this.currentPosition %= 100;
		}

		this.CheckIfLandedOnZero();
	}

	public void RotateLeft(int rotation)
	{
		this.currentPosition -= rotation;
		if (this.currentPosition < MinDialValue) 
		{
			this.currentPosition = 100 - ((this.currentPosition * -1) % 100);
			if (this.currentPosition == 100)
			{
				this.currentPosition = 0;
			}
		}

		this.CheckIfLandedOnZero();
	}

	private void CheckIfLandedOnZero()
	{
		if (this.currentPosition == MinDialValue)
		{
			this.numRotationsLeftAtZero++;
		}
	}
}

internal class PuzzleSolver()
{
	private SafeDial safeDial = new();

	public uint Solve(string input)
	{
		List<(string Direction, int Amount)> rotations =
			input.SplitLinesIntoStringIntVals("\n", new System.Text.RegularExpressions.Regex("[A-Z]"));
	
		foreach ((string Direction, int Amount) rotation in rotations)
		{
			if (rotation.Direction == "L")
			{
				safeDial.RotateLeft(rotation.Amount);
			}
			else
			{
				safeDial.RotateRight(rotation.Amount);
			}
		}

		return safeDial.GetDoorPassword();
	}
}