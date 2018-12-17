using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Day10
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("input.txt");
			var lightStates = GetSignalLightsStartState(input);
			var secondsPassed = 0;

			while (true)
			{
	
				var xmax = lightStates.Select(l => l.PositionX).Max();
				var ymax = lightStates.Select(l => l.PositionY).Max();
			
				var xmin = lightStates.Select(l => l.PositionX).Min();
				var ymin = lightStates.Select(l => l.PositionY).Min();

				var size = GetDistance(new int[] { xmax, xmin }, new int[] { ymin, ymax });

				if(secondsPassed >= 10375)
				{
					Console.Clear();
					foreach (var light in lightStates)
					{
						Console.SetCursorPosition(light.PositionX - xmin, light.PositionY - ymin);
						Console.Write("#");
						Thread.Sleep(5);
					}
					Console.ReadKey();
				}

				secondsPassed++;
				ResolveNextSecond(lightStates);
			}
		}

		private static int GetDistance(int[]x, int[]y)
		{
			return (x.Max() - x.Min()) + (y.Max() - y.Min());
		}

		private static void ResolveNextSecond(List<SignalLight> states)
		{
			foreach(var s in states)
			{
				s.PositionX += s.VelocityX;
				s.PositionY += s.VelocityY;
			}
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
