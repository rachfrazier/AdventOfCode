using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode2015;

internal class Day4
{
	public string FindLowestThing(string input)
	{
		using MD5 md5 = MD5.Create();
		byte[] inputBytes = Encoding.ASCII.GetBytes(input);
		byte[] hashBytes = md5.ComputeHash(inputBytes);

		return Convert.ToHexString(hashBytes);
	}

	internal bool IsValidHash(string hash) =>
		hash[0..5] == "00000";
}
