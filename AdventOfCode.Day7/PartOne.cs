using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
	class PartOne
	{
		public static string OrderInstructions(string[] instructions)
		{
			var instructionOrder = string.Empty;


			while (instructions.Any())
			{
				var before = string.Empty;
				var after = string.Empty;

				foreach (var instruction in instructions)
				{
					var step = instruction.Split(' ');
					before += step[1];
					after += step[7];
				}

				var firstAvailableStep = GetFirstAvailableStep(after, instructionOrder);
				instructionOrder += firstAvailableStep;


				instructions = UpdateInstructionList(instructions, firstAvailableStep);
			}


			return instructionOrder;
		}

		private static string[] UpdateInstructionList(string[] instructions, char finishedStep)
		{
			foreach (var instruction in instructions)
			{
				if (instruction.Split(' ')[1] == finishedStep.ToString())
				{
					instructions = instructions.Where(w => !w.Equals(instruction)).ToArray();
				}
			}
			return instructions;
		}

		private static char GetFirstAvailableStep(string after, string done)
		{
			var steps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			foreach (var step in steps)
			{
				if (!after.Where(s => s.Equals(step)).Any())
				{
					if (done.Contains(step))
					{
						continue;
					}
					else
					{
						return step;
					}

				}
			}

			return ' ';
		}
	}
}
