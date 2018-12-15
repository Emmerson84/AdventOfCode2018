using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
	class PartOne
	{
		
		


		public static List<int[]> ConvertToInt(string[] stringList)
		{
			var resultList = new List<int[]>();

			var inputList = new int[stringList.Length];
			var i = 0;
			foreach(var nString in stringList)
			{
				inputList[i] = Convert.ToInt32(nString);
				i++;
			}
			resultList.Add(inputList);
			return resultList;
		}



		public static List<int[]> GetSumOfMeta(List<int[]> result)
		{
			//var remainingList = result[0];

			var ChildNum = result[0][0];
			var metaNum = result[0][1];
			
			if(ChildNum > 0)
			{
				var list = result[0].ToList();
				list.RemoveRange(0, 2);
				result[0] = list.ToArray();

				result = GetSumOfMeta(result);
			}




				//var list = new List<int>()
				//{
				//1, 2, 3, 4
				//};

				//// 1 + 2 + 3
				//int sum = list.Take(3).Sum();


			return result;
		}










		internal static int[] GetNodes(string[] licenseFile)
		{
			var numberOfChildNodes = Convert.ToInt32(licenseFile[0]);
			var numberOfMetaData = Convert.ToInt32(licenseFile[1]);
			List<string> children = new List<string>();
			var sum = 0;


			if (numberOfChildNodes > 0)
			{
				children = licenseFile.ToList().GetRange(2, licenseFile.Length - (2 + numberOfMetaData));

				

				var quantifier = 0;
				for (var i = 0; i < numberOfChildNodes; i++)
				{
					var NodeIndex = quantifier;


					var nextGroup = children.GetRange(NodeIndex, children.Count() - NodeIndex).ToArray();

					if (nextGroup.Length == 0)
					{
						continue;
					}

					var nodeInfo = GetNodes(nextGroup);
					quantifier += nodeInfo[0];
					sum += nodeInfo[1];
				}
			}
			else if (numberOfChildNodes == 0)
			{
				var node = licenseFile.ToList();
				var nodeLenght = numberOfMetaData + 2;
				int sumOfMeta = GetSumOfNodeMetaData(node.GetRange(0, nodeLenght).ToArray());

				return new int[] { nodeLenght, sumOfMeta };
			}


			var list = licenseFile.ToList();
			list.RemoveRange(2, children.Count());
			var sumOfFinalNodeMeta = GetSumOfNodeMetaData(list.ToArray());
			var finalNodeLenght = licenseFile.Length;
			return new int[] { finalNodeLenght, sumOfFinalNodeMeta + sum };
		}


		public static int GetSumOfNodeMetaData(string[] licenseFile)
		{
			var numberOfMetaData = Convert.ToInt32(licenseFile[1]);
			var sumOfMetaData = 0;

			for (var i = 0; i < numberOfMetaData; i++)
			{
				sumOfMetaData += Convert.ToInt32(licenseFile[2 + i]);
			}

			return sumOfMetaData;
		}

	}
}
