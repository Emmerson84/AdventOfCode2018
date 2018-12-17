using System;

namespace AdventOfCode.Day9
{
	class Program
	{
		static void Main(string[] args)
		{
			var partOne = new PartOne();
			var partTwo = new PartTwo();
			var answer1 = partOne.PlayGame(413, 71082).Score;
			var answer2 = partTwo.PlayLongGame(413, 7108200);

			Console.Clear();
			Console.WriteLine($"Answer day 9.1: {answer1}");
			Console.WriteLine($"Answer day 9.2: {answer2}");
			Console.ReadKey();
		}
	}
}
