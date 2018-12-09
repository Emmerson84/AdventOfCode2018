using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day5
{
	class Program
	{
		static void Main(string[] args)
		{

			var polymer = File.ReadAllText("epolymer.txt");
			var allUnitTypes = "abcdefghijklmnopqrstuvwxyz";

			var smallestExperimentalPolymerResult = polymer.Length;

			foreach (var type in allUnitTypes)
			{

				var expirimentalPolymer = polymer.Replace(type.ToString().ToLower(), "");
				expirimentalPolymer = expirimentalPolymer.Replace(type.ToString().ToUpper(), "");

				var minimalUnitCount = GetMinimalUnitCount(expirimentalPolymer, smallestExperimentalPolymerResult);

				smallestExperimentalPolymerResult = smallestExperimentalPolymerResult > minimalUnitCount ? minimalUnitCount : smallestExperimentalPolymerResult;

			}




			Console.WriteLine();
			Console.WriteLine($"Answer day 5.2: {smallestExperimentalPolymerResult}");
			Console.ReadKey();
		}

		private static int GetMinimalUnitCount(string polymer, int currentSmallest)
		{
			for (var i = 0; polymer.Length > i; i++)
			{
				var u1 = polymer[i];
				var u2 = i + 1 >= polymer.Length ? '-' : polymer[i + 1];

				if (Char.IsUpper(u1) != Char.IsUpper(u2))
				{
					if (u1.ToString().ToLower() == u2.ToString().ToLower())
					{
						StringBuilder sb = new StringBuilder(polymer);
						sb.Remove(i, 1);
						sb.Remove(i, 1);
						polymer = sb.ToString();
						i = i > 1 ? i - 2 : i = -1;
	
						Console.Write("\r{0}  ", $"Calculating experimental polymer length: {polymer.Length - i} - Current Lowest size: {currentSmallest}");
					}
				}
			}

			return polymer.Length;
		}
	}
}
