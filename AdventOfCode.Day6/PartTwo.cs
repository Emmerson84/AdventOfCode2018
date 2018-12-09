using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
	class PartTwo
	{

		internal static object GetRegionSize(List<int[]> givenCoordinates, int[] maxCoordinates)
		{
			var i = 0;
			var regionSize = 0;

			for (var y = 1; y <= maxCoordinates[1]; y++)
			{
				for (var x = 1; x <= maxCoordinates[0]; x++)
				{
					var distanceSum = CalculateDistanceSum(x,y,givenCoordinates);
					if(distanceSum < 10000)
					{
						regionSize++;
					}
					
					Console.Write("\r{0}  ", $"Coordinates: {x},{y}     --  {i}");
				}
			}
			return regionSize;
		}

		private static int CalculateDistanceSum(int x, int y, List<int[]> givenCoordinates)
		{
			var distance = 0;

			foreach (var coordinate in givenCoordinates)
			{
				var cx = new int[] { x, coordinate[0] };
				var cy = new int[] { y, coordinate[1] };
				distance += (cx.Max() - cx.Min()) + (cy.Max() - cy.Min());
			}
			return distance;
		}

		internal static int[] GetEdgCoordinates(List<int[]> coordinates)
		{
			var edgCoordinates = new int[2];

			foreach (var coordinate in coordinates )
			{
				if(coordinate[0] > edgCoordinates[0])
				{
					edgCoordinates[0] = coordinate[0];
				}
				if(coordinate[1] > edgCoordinates[1])
				{
					edgCoordinates[1] = coordinate[1];
				}
			}
			return edgCoordinates;
		}

		internal static List<int[]> GetGivenCoordinates(string[] coordinateStrings)
		{
			var givenCoordinates = new List<int[]>();

			foreach (var coordinateString in coordinateStrings)
			{
				var x = Convert.ToInt32(coordinateString.Split(',')[0].Trim());
				var y = Convert.ToInt32(coordinateString.Split(',')[1].Trim());
				givenCoordinates.Add(new int[] { x, y });
			}

			return givenCoordinates;
		}
	}
}
