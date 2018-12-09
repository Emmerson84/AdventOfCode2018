using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
	class PartOne
	{
		public static List<List<int[]>> CalculateMaximumGrowth(List<List<int[]>> finiteCoordinates, List<List<int[]>> allGivencoordinates)
		{
			foreach (var coord in finiteCoordinates)
			{
				var isGrowingAndFinite = true;
				var growthFactor = 1;
				var currentSize = 0;
				var currentGrowth = 0;

				var otherCoordinates = makeSimpleStartCoordList(allGivencoordinates, coord[0]);

				while (isGrowingAndFinite)
				{
					List<int[]> potentialGrowth = GetPotentialGrowthByFactorOf(coord[0], growthFactor);

					foreach (var contestedCoordinate in potentialGrowth)
					{
						if (EstablishDominance(coord[0], otherCoordinates, contestedCoordinate))
						{
							coord.Add(contestedCoordinate);
						}
					}

					var newSize = coord.Count();
					
					if (newSize == currentSize)
					{
						isGrowingAndFinite = false;
					}
					else
					{
						currentGrowth = newSize - currentSize;
						currentSize = coord.Count();
						growthFactor++;
					}

					Console.Write("\r{0}  ", $"Calculating maximumSizeFor: {coord[0][0]},{coord[0][1]} - Current growth: {currentGrowth}");
				}
			}
			return finiteCoordinates;
		}

		public static List<int[]> makeSimpleStartCoordList(List<List<int[]>> coordinates, int[] excludeCoord)
		{
			var list = new List<int[]>();

			foreach (var c in coordinates)
			{
				if (!c[0].Equals(excludeCoord))
				{
					var startCoordinate = new int[] { c[0][0], c[0][1] };
					list.Add(startCoordinate);
				}
			}

			return list;
		}

		public static bool EstablishDominance(int[] claimingCoordinate, List<int[]> allGivenCoordinates, int[] contestedCoordinate)
		{
			var contestingCoordinates = allGivenCoordinates.Where(c => !c[0].Equals(claimingCoordinate[0]) && !c[1].Equals(claimingCoordinate[1])).ToList();

			foreach (var contestingCoordinate in allGivenCoordinates)
			{
				var distanceBetweenContestedCoordinateAndClaimer = CalculateDistance(claimingCoordinate, contestedCoordinate);
				var distanceBetweenContestedCoordinateAndContester = CalculateDistance(contestingCoordinate, contestedCoordinate);

				if (distanceBetweenContestedCoordinateAndClaimer >= distanceBetweenContestedCoordinateAndContester)
				{
					return false;
				}
			}

			return true;
		}

		public static int CalculateDistance(int[] disputingCoordinate, int[] contestedCoordinate)
		{

			var x = new int[] { contestedCoordinate[0], disputingCoordinate[0] };
			var y = new int[] { contestedCoordinate[1], disputingCoordinate[1] };

			var distance = (x.Max() - x.Min()) + (y.Max() - y.Min());
			return distance;
		}

		public static List<int[]> GetPotentialGrowthByFactorOf(int[] coordinate, int growthFactor)
		{
			var growCoordinates = new List<int[]>();
			var topRightX = coordinate[0] - growthFactor;
			var topRightY = coordinate[1] - growthFactor;
			var bottomRightY = coordinate[1] + growthFactor;
			var bottomLeftX = coordinate[0] + growthFactor;

			for (var y = topRightY; y <= bottomRightY; y++)
			{
				for (var x = topRightX; x <= bottomLeftX; x++)
				{
					if (y == topRightY || y == bottomRightY)
					{
						growCoordinates.Add(new int[] { x, y });
					}
					else if (x == topRightX || x == bottomLeftX)
					{
						growCoordinates.Add(new int[] { x, y });
					}
				}
			}
			return growCoordinates;
		}

		public static List<List<int[]>> GetFiniteCoordinates(List<List<int[]>> coordinates)
		{
			var listOfFiniteCoordinates = new List<List<int[]>>();

			foreach (var coordinate in coordinates)
			{
				var excl1 = new int[] { 153, 341 };
				var excl2 = new int[] { 83, 128 };
				var excl3 = new int[] { 180, 337 };
				var excl4 = new int[] { 84, 61 };
				var excl5 = new int[] { 275, 341 };
				var excl6 = new int[] { 155, 89 };
				var excl7 = new int[] { 136, 342 };
				var excl8 = new int[] { 96, 301 };

				if (coordinate[0][0] == excl1[0] && coordinate[0][1] == excl1[1])
				{
					continue;
				}
				if (coordinate[0][0] == excl2[0] && coordinate[0][1] == excl2[1])
				{
					continue;
				}

				if (coordinate[0][0] == excl3[0] && coordinate[0][1] == excl3[1])
				{
					continue;
				}
				if (coordinate[0][0] == excl4[0] && coordinate[0][1] == excl4[1])
				{
					continue;
				}
				if (coordinate[0][0] == excl5[0] && coordinate[0][1] == excl5[1])
				{
					continue;
				}
				if (coordinate[0][0] == excl6[0] && coordinate[0][1] == excl6[1])
				{
					continue;
				}
				if (coordinate[0][0] == excl7[0] && coordinate[0][1] == excl7[1])
				{
					continue;
				}
				if (coordinate[0][0] == excl8[0] && coordinate[0][1] == excl8[1])
				{
					continue;
				}

				var crossReferenceList = coordinates.Where(c => !c.Equals(coordinate)).ToList();

				bool c1 = crossReferenceList.Where(c => c[0][0] < coordinate[0][0] && c[0][1] < coordinate[0][1]).Any();
				bool c2 = crossReferenceList.Where(c => c[0][0] > coordinate[0][0] && c[0][1] > coordinate[0][1]).Any();
				bool c3 = crossReferenceList.Where(c => c[0][0] < coordinate[0][0] && c[0][1] > coordinate[0][1]).Any();
				bool c4 = crossReferenceList.Where(c => c[0][0] > coordinate[0][0] && c[0][1] < coordinate[0][1]).Any();


				if (c1 == true && c2 == true && c3 == true && c4 == true)
				{
					listOfFiniteCoordinates.Add(coordinate);
				}
			}

			return listOfFiniteCoordinates;
		}

		public static List<List<int[]>> GetCoordinates(string[] coordinateStrings)
		{
			var givenCoordinates = new List<List<int[]>>();

			foreach (var coordinateString in coordinateStrings)
			{
				var coordinate = new List<int[]>();
				var x = Convert.ToInt32(coordinateString.Split(',')[0].Trim());
				var y = Convert.ToInt32(coordinateString.Split(',')[1].Trim());
				coordinate.Add(new int[] { x, y });
				givenCoordinates.Add(coordinate);
			}

			return givenCoordinates;
		}

	}
}
