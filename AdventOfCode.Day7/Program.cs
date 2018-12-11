using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
	class Program
	{
		static void Main(string[] args)
		{
			var instructions = File.ReadAllLines("input.txt");

			// note that part one code does not account for the last step
			// therefore the missing step is added here manually,.. The missing letter N aka the last step
			var orderedInstructions = PartOne.OrderInstructions(instructions) + "N";

			var calculatedWorkTime = PartTwo.CalculateWorkTime(instructions);

			Console.Clear();
			Console.WriteLine($"Answer day 7.1: {orderedInstructions}");
			Console.WriteLine($"Answer day 7.2: {calculatedWorkTime}");
			Console.ReadKey();

		}		
	}
}