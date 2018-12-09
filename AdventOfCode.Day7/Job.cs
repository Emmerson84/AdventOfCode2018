namespace AdventOfCode.Day7
{
	public class Job
	{
		public char Step { get; set; }
		public string Dependancies  { get; set; }
		public int RequiredTime { get; set; }
		public bool Done { get; set; }
		public bool InProgress { get; set; }
	}
}
