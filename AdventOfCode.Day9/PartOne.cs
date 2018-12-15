using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day9
{
	class PartOne
	{
		//private List<Player> _players;


		public void SetupGame(int numberOfPlayers, int lastMarbelWorth)
		{
			var players = GetPlayers(numberOfPlayers);
			var firstMarbel = new Marbel() { Points = 0, IsCurrent = true };
			var marbleCircle = new List<Marbel>();
			marbleCircle.Add(firstMarbel);

			Tuple<List<Player>, List<Marbel>> gameState = PlayGame(players, marbleCircle, lastMarbelWorth);
		}

		private Tuple<List<Player>, List<Marbel>> PlayGame(List<Player> players, List<Marbel> marbleCircle, int lastMarbelWorth)
		{
			Player currentPlayer = GetNextPlayer(players);


			for (var i = 1; i <= lastMarbelWorth; i++)
			{
				var nextMarbel = new Marbel() { Points = i, IsCurrent = true };
				//marbleCircle = ResolveNextTurn(nextMarbel, marbleCircle);
			}

	

			return Tuple.Create(players, marbleCircle);
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
