using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Day9
{
	class PartTwo
	{
		public long PlayLongGame(int numberOfPlayers, int totalMarbles)
		{
			var players = new List<long>();
			players.AddRange(Enumerable.Repeat<long>(0, numberOfPlayers));

			var marbleCircle = new List<int>() { 0 };
			var nextMarble = 0;
			var currentMarbleIndex = 0;

			while (true)
			{
				for(var i = 0; i < players.Count; i++)
				{
					nextMarble++;
					if (nextMarble > totalMarbles)
					{
						return players.Max();
					}
					Console.Write("\r{0}  ", $"Remaining marbles: {totalMarbles - nextMarble}");

					if (nextMarble % 23 == 0)
					{
						var bonusMarbleIndex = currentMarbleIndex - 7;

						if (bonusMarbleIndex < 0)
						{
							bonusMarbleIndex = marbleCircle.Count - Math.Abs(bonusMarbleIndex);
						}
						players[i] += nextMarble;
						players[i] += marbleCircle[bonusMarbleIndex];
						marbleCircle.RemoveAt(bonusMarbleIndex);
						currentMarbleIndex = bonusMarbleIndex;
					}
					else
					{
						if (currentMarbleIndex == marbleCircle.Count - 1)
						{
							marbleCircle.Insert(1, nextMarble);
							currentMarbleIndex = 1;
						}
						else if (currentMarbleIndex == marbleCircle.Count - 2)
						{
							marbleCircle.Add(nextMarble);
							currentMarbleIndex = marbleCircle.Count - 1;
						}
						else
						{
							marbleCircle.Insert(currentMarbleIndex + 2, nextMarble);
							currentMarbleIndex = currentMarbleIndex + 2;
						}
					}
				}
			}
		}
	}
}
