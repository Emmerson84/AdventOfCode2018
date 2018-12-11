using System.Collections.Generic;

namespace AdventOfCode.Day8
{
	internal class Node
	{
		public List<Node> ChildNodes { get; set; }
		public int[] MetaData { get; set; }
	}
}
