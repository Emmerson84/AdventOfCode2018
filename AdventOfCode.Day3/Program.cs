using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day3
{
	class Program
	{
		static void Main(string[] args)
		{
			//var claimsList = GetClaims(File.ReadAllLines(@"inputTest.txt"));
			var claimsList = GetClaims(File.ReadAllLines(@"input.txt"));
			//var totalOverlappingInches = GetCalculateTotalOverlap(claimsList);
			var totalSurface = new List<Inch>();//GetClaimSurface("#0 @ 0,0: 1000x1000");

			var listCount = claimsList.Count();
			var totalActions = 0;


			foreach (var claim in claimsList)
			{
				//totalActions += claim.Inches.Count(); 514028

				var inchCount = claim.Inches.Count();
				foreach (var inch in claim.Inches)
				{
					inch.State = State.filled;

					var surface = totalSurface.Where(ts => ts.X == inch.X && ts.Y == inch.Y).FirstOrDefault();
					if (surface == null)
					{
						totalSurface.Add(inch);
					}
					else
					{
						if (surface.State == State.filled)
						{
							totalSurface.Where(ts => ts.X == inch.X && ts.Y == inch.Y).FirstOrDefault().State = State.overlap;
							inch.State = State.overlap;
						}
					}
					inchCount--;

					Console.Write("\r{0}  ", $"List: {listCount}  -  inches: {inchCount}");
				}
				listCount--;
			}

			var r = totalSurface.Where(ts => ts.State == State.overlap).ToList().Count();
			var r2 = claimsList.Where(cl => cl.Inches.All(i => i.State == State.filled)).FirstOrDefault().id;
			var r3 = claimsList.Where(cl => cl.Inches.All(i => i.State == State.filled)).ToList();

			Console.WriteLine();
			Console.WriteLine($"Answer day 3.1: {r}");
			Console.WriteLine($"Answer day 3.2: {r2}");
			Console.ReadKey();

			foreach(var i in r3)
			{
				foreach(var inch in i.Inches)
				{
					if(inch.State == State.overlap)
					{
						var hit = 0;
					}
				}
			}






		}



		private static List<Claim> GetClaims(string[] claimStrings)
		{
			var claimsList = new List<Claim>();
			foreach (var claimString in claimStrings)
			{
				claimsList.Add(GetClaimSurface(claimString));
			}
			return claimsList;
		}



		private static Claim GetClaimSurface(string claimString)
		{
			var claim = new Claim();
			var substrings = claimString.Split('@', ':');
			claim.id = Convert.ToInt32(substrings[0].Split('#').Last().Trim());
			var startPointX = Convert.ToInt32(substrings[1].Split(',').First().Trim()); ;
			var startPointY = Convert.ToInt32(substrings[1].Split(',').Last().Trim()); ;
			var width = Convert.ToInt32(substrings[2].Split('x').First().Trim());
			var height = Convert.ToInt32(substrings[2].Split('x').Last().Trim());
			var inchList = new List<Inch>();

			for(var y = startPointY; y < startPointY + height; y++)
			{
				for (var x = startPointX; x < startPointX + width; x++)
				{
					inchList.Add(new Inch() { Y = y, X = x });
				}
			}
			claim.Inches = inchList;
			return claim;
		}

		private enum State { free, filled, overlap }

		private class Inch
		{
			public int X { get; set; }
			public int Y { get; set; }
			public State State { get; set; }
		}

		private class Claim
		{
			public int id { get; set; }
			public List<Inch> Inches { get; set; }
		}
	}
}
