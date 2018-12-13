using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
	class PartOne
	{

		internal static int[] GetNodes(string[] licenseFile)
		{
			var numberOfChildNodes = Convert.ToInt32(licenseFile[0]);
			var numberOfMetaData = Convert.ToInt32(licenseFile[1]);
			List<string> children = new List<string>();
			var sum = 0;


			if (numberOfChildNodes > 0)
			{
				children = licenseFile.ToList().GetRange(2, licenseFile.Length - numberOfMetaData - 2);
				var quantifier = 0;
				for (var i = 0; i < numberOfChildNodes; i++)
				{
					var NodeIndex = quantifier;
					var nodeInfo = GetNodes(children.GetRange(NodeIndex, children.Count()-NodeIndex).ToArray());
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







		internal static int[] GetAllNodes(string[] licenseFile)
		{
			//var sumOfMetaData = 0;
			var numberOfChildNodes = Convert.ToInt32(licenseFile[0]);
			var numberOfMetaData = Convert.ToInt32(licenseFile[1]);
			List<string> subnodes = new List<string>();


			if (numberOfChildNodes > 0)
			{
				subnodes = licenseFile.ToList().GetRange(2, licenseFile.Length - numberOfMetaData - 2);
				for (var i = 0; i < numberOfChildNodes; i++)
				{
					var childNodeLenght = GetAllNodes(subnodes.ToArray());
					if( i != numberOfChildNodes - 1)
					{
						subnodes.RemoveRange(0, childNodeLenght[0]);
					}
				}
			}
			else if (numberOfChildNodes == 0)
			{
				var node = licenseFile.ToList();
				var nodeLenght = numberOfMetaData + 2;
				int sumOfMeta = GetSumOfNodeMetaData(node.GetRange(0, nodeLenght).ToArray());

				return new int[] {nodeLenght, sumOfMeta };
			}

			licenseFile.ToList().RemoveRange(2, 3);
			var list = licenseFile.ToList();
			var rr = (subnodes.Count());
			list.RemoveRange(2, rr);
			var sumOfFinalNodeMeta = GetSumOfNodeMetaData(list.ToArray());
			var finalNodeLenght = numberOfMetaData + 2;
			//int sumOfMetaqqq = GetSumOfNodeMetaData(licenseFile);
			//subnodes.RemoveRange(0, childNodeLenght[0]);
			//var nodeLenghtqq = numberOfMetaData + 2;
			//int sumOfMetaqqq = GetSumOfNodeMetaData(finalNode.RemoveRange(2, 3));

			return new int[] { finalNodeLenght, sumOfFinalNodeMeta };

		}

		private static int GetNode(string[] licenseFile)
		{
			var sumOfMetaData = 0;
			var numberOfChildNodes = Convert.ToInt32(licenseFile[0]);
			var totalNumberOfMetaData = 0;
			var numberOfMetaData = Convert.ToInt32(licenseFile[1]);
			var subNodes = licenseFile.ToList();
			
			for (var i = 0; i < numberOfChildNodes; i++)
			{
				if (i == 0) { subNodes.RemoveRange(0, 2); }
				sumOfMetaData += GetNode(subNodes.ToArray());
				var numberOfSubNodeMetaData = Convert.ToInt32(subNodes[1]);
				totalNumberOfMetaData += numberOfSubNodeMetaData;
				subNodes.RemoveRange(0, 2 + numberOfSubNodeMetaData);
			}

			sumOfMetaData += GetSumOfNodeMetaData(subNodes.ToArray());

			var restValues = licenseFile.ToList();
			restValues.RemoveRange(2, totalNumberOfMetaData);
			
			return sumOfMetaData;
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
