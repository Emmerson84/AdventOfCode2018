using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
	class PartTwo
	{
		internal static int CalculateWorkTime(string[] instructions)
		{
	
			var allJobs = GetJobs(instructions);
			var workers = GetWorkers(2);
			var workingSeconds = 0;

			while (allJobs.Where(j => j.Done.Equals(false)).Any())
			{
				allJobs = UpdateDependancies(allJobs);
				var availebleJobs = allJobs
					.Where(j => !j.Dependancies.Any() && j.InProgress.Equals(false))
					.OrderBy(j => j.Step).ToList();

				foreach (var worker in workers)
				{
					if (worker.Active)
					{
						var currentJob = allJobs.Where(j => j.Step.Equals(worker.CurrentJob)).First();
						
						if(currentJob.RequiredTime == 0)
						{
							currentJob.Done = true;
							currentJob.InProgress = false;
							worker.Active = false;
						}
						else
						{
							currentJob.RequiredTime--;
						}
						
					}
					else
					{
						if (availebleJobs.Any())
						{
							worker.CurrentJob = availebleJobs.First().Step;
							worker.Active = true;
							var currentJob = allJobs.Where(j => j.Step.Equals(worker.CurrentJob)).First();
							currentJob.InProgress = true;
							currentJob.RequiredTime--;
						}
					}
				}
				workingSeconds++;
			}


			return workingSeconds;
		}

		private static List<Worker> GetWorkers(int numberOfWorkers)
		{
			var workers = new List<Worker>();
			for(var i = 0; i < numberOfWorkers; i++)
			{
				var worker = new Worker();
				workers.Add(worker);
			}
			return workers;
		}

		private static List<Job> UpdateDependancies(List<Job> allJobs)
		{
			var allFinishedJobs = allJobs.Where(j => j.Done.Equals(true)).ToList();

			if (allFinishedJobs.Any())
			{
				// todo: update if  dependancies if finished jobs exist.
				string MyString = "ABAXD";
				char MyChar = 'A';
				string NewString = MyString.Replace(MyChar.ToString(), "");
			}

			return allJobs;
		}

		private static List<Job> GetJobs(string[] instructions)
		{
			var jobList = new List<Job>();
			var steps = "CABFDE";//"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			
			foreach (var step in steps)
			{
				var job = new Job();
				job.Step = step;
				job.Dependancies = GetDependancies(instructions, step);
				job.RequiredTime = StepTime(step);//60 + StepTime(step);
				jobList.Add(job);
			}

			return jobList;
		}

		private static int StepTime(char step)
		{
			var letterTime = new Dictionary<char, int>
			{
				{ 'A', 1 },	{ 'B', 2 },	{ 'C', 3 },	{ 'D', 4 },	{ 'E', 5 },	{ 'F', 6 },	{ 'G', 7 },	{ 'H', 8 },
				{ 'I', 9 },	{ 'J', 10 },{ 'K', 11 },{ 'L', 12 },{ 'M', 13 },{ 'N', 14 },{ 'O', 15 },{ 'P', 16 },
				{ 'Q', 17 },{ 'R', 18 },{ 'S', 19 },{ 'T', 20 },{ 'U', 21 },{ 'V', 22 },{ 'W', 23 },{ 'X', 24 },
				{ 'Y', 25 },{ 'Z', 26 }
			};
			return letterTime[step];
		}

		private static string GetDependancies(string[] instructions, char step)
		{
			var dependancies = instructions.Where(c => c[36].Equals(step)).ToArray();
			var dependancyString = string.Empty;

			foreach(var dependancy in dependancies)
			{
				dependancyString += dependancy[5];
			}

			return dependancyString;
		}
	}
}