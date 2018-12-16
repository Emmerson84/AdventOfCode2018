using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day9
{
	class PartOne
	{
		public Player PlayGame(int numberOfPlayers, int lastMarbleWorth)
		{
			var players = GetPlayers(numberOfPlayers);
			var marbles = GetMarbles(lastMarbleWorth);

			var marbleCircle = new List<Marbel>() { new Marbel() { Points = 0, IsCurrent = true } };
			var currentMarbleIndex = 0;


			while (marbles.Count() > 0)
			{
				foreach(Player player in players)
				{
					Console.Write("\r{0}  ", $"Remaining marbles: {marbles.Count()}");

					if (!marbles.Any()) { break; }

					if ((marbles.First().Points / 23f % 1) > 0)
					{
						if (currentMarbleIndex == marbleCircle.Count() - 1)
						{
							marbleCircle.Insert(1, marbles.First());
							currentMarbleIndex = 1;
						}
						else if (currentMarbleIndex == marbleCircle.Count() - 2)
						{
							marbleCircle.Add(marbles.First());
							currentMarbleIndex = marbleCircle.Count() - 1;
						}
						else
						{
							marbleCircle.Insert(currentMarbleIndex + 2, marbles.First());
							currentMarbleIndex = currentMarbleIndex + 2;
						}
					}
					else
					{
						var bonusMarbleIndex = currentMarbleIndex - 7;

						if (bonusMarbleIndex < 0)
						{
							bonusMarbleIndex = (marbleCircle.Count()) - (Math.Abs(bonusMarbleIndex));
							player.Marbels.Add(marbles.First());
							player.Marbels.Add(marbleCircle[bonusMarbleIndex]);
							player.Score += marbles.First().Points;
							player.Score += marbleCircle[bonusMarbleIndex].Points;
							marbleCircle.RemoveAt(bonusMarbleIndex);
							currentMarbleIndex = bonusMarbleIndex;
						}
						else
						{
							player.Marbels.Add(marbles.First());
							player.Marbels.Add(marbleCircle[bonusMarbleIndex]);
							player.Score += marbles.First().Points;
							player.Score += marbleCircle[bonusMarbleIndex].Points;
							marbleCircle.RemoveAt(bonusMarbleIndex);
							currentMarbleIndex = bonusMarbleIndex;
						}
					}

					marbles.RemoveAt(0);
				}
			}

			var winner = players.OrderByDescending(p => p.Score).First();
			return winner;
		}

	

		private List<Marbel> GetMarbles(int lastMarbleWorth)
		{
			var marbleList = new List<Marbel>();
			for (var i = 1; i <= lastMarbleWorth; i++)
			{
				marbleList.Add(new Marbel()
				{
					Points = i,
					IsCurrent = true
				});
			}
			return marbleList;
		}

		private List<Player> GetPlayers(int numberOfPlayers)
		{
			var playersList = new List<Player>();
			for(var i =0; i < numberOfPlayers; i++)
			{
				playersList.Add(new Player()
				{
					Marbels = new List<Marbel>(),
					Score = 0
				});
			}
			return playersList;
		}
	}
}
