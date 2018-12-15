using System.Collections.Generic;

namespace AdventOfCode.Day9
{
	internal class Player
	{
		public List<Marbel> Marbels { get; set; }
		public int Score { get; set; }
		public bool IsCurrentPlayer { get; set; }
	}
}