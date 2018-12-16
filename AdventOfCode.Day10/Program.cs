using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day10
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("einput.txt");
			var states = GetSignalLightsStartState(input);

			var averigeDistance = GetAverige(states);
			var newDistance = 0;

			var distanceIsShrinking = true;

			while (distanceIsShrinking)
			{
				averigeDistance = GetAverige(states);
				ResolveNextSecond(states);
				newDistance = GetAverige(states);

				distanceIsShrinking = averigeDistance -newDistance > 0;
			}




		}

		private static void ResolveNextSecond(List<SignalLight> states)
		{
			foreach(var s in states)
			{
				s.PositionX += s.VelocityX;
				s.PositionY += s.VelocityY;
			}
		}

		private static int GetAverige(List<SignalLight> states)
		{
			var distance = 0;
			var counter = 0;

			foreach(var s in states)
			{
				foreach(var s1 in states)
				{
					counter++;
					var cx = new int[] { s.PositionX, s1.PositionX };
					var cy = new int[] { s.PositionY, s1.PositionY };
					distance += (cx.Max() - cx.Min()) + (cy.Max() - cy.Min());
				}
			}

			return distance / counter;
		}

		private static List<SignalLight> GetSignalLightsStartState(string[] input)
		{
			var coordinateList = new List<SignalLight>();

			foreach (var line in input)
			{
				var t = line.Split('<', '>', ',');
				var positionX = Convert.ToInt32(t[1].Trim());
				var positionY = Convert.ToInt32(t[2].Trim());

				var velocityX = Convert.ToInt32(t[4].Trim());
				var velocityY = Convert.ToInt32(t[5].Trim());

				coordinateList.Add(new SignalLight()
				{
					PositionX = positionX,
					PositionY = positionY,
					VelocityX = velocityX,
					VelocityY = velocityY
				});
			}

			return coordinateList;
		}
	}
}
