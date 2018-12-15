using System;
using System.IO;

namespace AdventOfCode.Day8
{
	class Program
	{
		static void Main(string[] args)
		{
			// Part one
			var licenseFile = File.ReadAllText("einput.txt").Split(' ');
			//var nodes = PartOne.GetNodes(licenseFile);
			var nodes = PartOne.GetSumOfMeta(PartOne.ConvertToInt(licenseFile));
			var answerP1 = nodes[1];

			// Part two
			var answerP2 = "??";


			Console.Clear();
			Console.WriteLine($"Answer day 8.1: {answerP1}");
			Console.WriteLine($"Answer day 8.2: {answerP2}");
			Console.ReadKey();
		}
	}
}
