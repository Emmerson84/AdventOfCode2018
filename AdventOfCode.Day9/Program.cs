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

			partOne.PlayGame(9, 25);





			var players = 9;
			var highestMarbel = 25;


			var circle = new List<Marbel>()
			{ new Marbel()
				{
					Points = 0,
					IsCurrent = true
				}
			};

			for(var i = 1; i <= highestMarbel; i++)
			{
				var nextMarbel = new Marbel() { Points = i, IsCurrent = true };

				circle = ResolveNextTurn(nextMarbel, circle);

			}


		}

		private static List<Marbel> ResolveNextTurn(Marbel nextMarbel, List<Marbel> circle)
		{
			var currentMarbel = circle.Find(m => m.IsCurrent.Equals(true));
			var currentMarbelIndex = circle.FindIndex(m => m.IsCurrent.Equals(true));
			currentMarbel.IsCurrent = false;

			var isNotMultipleOf23 = ((nextMarbel.Points / 23) % 1) == 0;

			if (isNotMultipleOf23)
			{

				if (currentMarbelIndex == circle.Count() - 1)
				{
					circle.Insert(1, nextMarbel);
				}
				else if (currentMarbelIndex == circle.Count() - 2)
				{
					circle.Add(nextMarbel);
				}
				else
				{
					circle.Insert(currentMarbelIndex + 2, nextMarbel);
				}
			}
			else
			{
				
			}

	


			return circle;
		}
	}
}
