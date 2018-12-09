using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
	class Program
	{
		static void Main(string[] args)
		{

			// part one
			var coordinates = PartOne.GetCoordinates(File.ReadAllLines("coordinates.txt"));
			var finiteCoordinates = PartOne.GetFiniteCoordinates(coordinates);
			finiteCoordinates = PartOne.CalculateMaximumGrowth(finiteCoordinates, coordinates);
			var answer1 = finiteCoordinates.Select(x => x.Count()).Max();

			// part two
			var givenCoordinates = PartTwo.GetGivenCoordinates(File.ReadAllLines("coordinates.txt"));
			var maxCoordinates = PartTwo.GetEdgCoordinates(givenCoordinates);
			var answer2 = PartTwo.GetRegionSize(givenCoordinates, maxCoordinates);



			Console.WriteLine();
			Console.WriteLine($"Answer day 6.1: {answer1}");
			Console.WriteLine($"Answer day 6.2: {answer2}");
			Console.ReadKey();
		}
	}
}