using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day4
{
	class Program
	{
		static void Main(string[] args)
		{
			var x = 10;

			var scheduleList = GetSortedGuardSchedule(File.ReadAllLines(@"input.txt"));


			




			//var tmp = GetMinutes(scheduleList[0].DateTime, scheduleList[1].DateTime);
			//var tmp2 = tmp[1].TimeOfDay;



			Guard currentGuard = new Guard();

			DateTime sleepStartTime = new DateTime();
			var guardList = new List<Guard>();

			foreach(var action in scheduleList)
			{
				if (action.GuardId != null)
				{
					
					if (!guardList.Any(a => a.GuardId == action.GuardId))
					{
					var guard = new Guard();
					guard.GuardId = action.GuardId;
					guard.SleepMinutes = new List<DateTime>();
					guardList.Add(guard);
					}
					currentGuard = guardList.Where(g => g.GuardId == action.GuardId).FirstOrDefault();
				}
				if (action.Action == "falls asleep")
				{
					sleepStartTime = action.DateTime;
				}
				if (action.Action == "wakes up")
				{
					//Where(g => g.GuardId == action.GuardId).FirstOrDefault()
					var guard = guardList.Where(g => g.GuardId == currentGuard.GuardId).FirstOrDefault();
					guard.SleepMinutes.AddRange(GetMinutes(sleepStartTime, action.DateTime));
				}

			}


			var a2GuardId = "";
			var mostFreq = 0;
			foreach (var guard in guardList)
			{
				var bmFreaq = GetBestTime(guard.SleepMinutes);

				if(mostFreq < bmFreaq)
				{
					mostFreq = bmFreaq;
					a2GuardId = guard.GuardId;
				}
			}

			var a2Guard = guardList.Where(g => g.GuardId == "2789").Single();
			var a2BestMinute = GetBestTime(a2Guard.SleepMinutes);

			var sleepyGuard = GetMostSleepingGuard(guardList);

			var bestMinute = GetBestTime(sleepyGuard.SleepMinutes);


			var answer = Convert.ToInt32(sleepyGuard.GuardId) * bestMinute;
			var answer2 = Convert.ToInt32(a2Guard.GuardId) * a2BestMinute;
		}

		private static int GetBestTime(List<DateTime> sleepMinutes)
		{
			var duplicateItems = new List<DateTime>();

			foreach (var minute in sleepMinutes)
			{
				//duplicateItems = sleepMinutes.Where(sm => sm.Minute.Equals(minute.Minute)).ToList();

			var rslt =  (from item in sleepMinutes
					   group item by item.Minute into g
					   orderby g.Count() descending
					   select new { Item = g.Key, Count = g.Count() }).First();
				//return rslt.Count;
				return rslt.Item;
			}

			return 0;


		}

		private static Guard GetMostSleepingGuard(List<Guard> guards)
		{
			var sleepyGuard = new Guard() { SleepMinutes = new List<DateTime>() };
			foreach(var guard in guards)
			{
				if(sleepyGuard.SleepMinutes.Count < guard.SleepMinutes.Count())
				{
					sleepyGuard = guard;
				}
			}
			return sleepyGuard;
		}


		private static List<DateTime> GetMinutes(DateTime start, DateTime stop)
		{
			var minutes = new List<DateTime>();
			minutes.Add(start);
			var difference = stop.Subtract(start).Minutes;
			for(var i = 1; difference > i; i++)
			{
				minutes.Add(minutes.Last().AddMinutes(1));
			}


			return minutes;
		}



		private static List<GuardAction> GetSortedGuardSchedule(string[] guardActionNotes)
		{
			var guardSchedule = new List<GuardAction>();
			foreach(var note in guardActionNotes)
			{
				GuardAction action = new GuardAction();
				action.DateTime = DateTime.Parse(note.Split(']')[0].Trim('['));
				action.Action = note.Split(']')[1].Trim();
				action.GuardId = note.Split(']')[1].Contains('#') ? note.Split(']')[1].Trim().Split('#')[1].Split(' ')[0] : null;
				guardSchedule.Add(action);
			}
			return guardSchedule.OrderBy(gs => gs.DateTime).ToList(); ;
		}


		class GuardAction
		{
			public string GuardId { get; set; }
			public DateTime DateTime { get; set; }
			public string Action { get; set; }
		}

		class Guard
		{
			public string GuardId { get; set; }
			public List<DateTime> SleepMinutes { get; set; }
		}
	}
}
