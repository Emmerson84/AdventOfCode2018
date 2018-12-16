using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day9
{
	class Program
	{
		static void Main(string[] args)
		{
			var partOne = new PartOne();
			//var answer1 = partOne.PlayGame(413, 71082).Score;
			var answer2 = partOne.PlayGame(413, 7108200).Score;

			Console.Clear();
			//Console.WriteLine($"Answer day 9.1: {answer1}");
			Console.WriteLine($"Answer day 9.2: {answer2}");
			Console.ReadKey();
		}
	}
}
