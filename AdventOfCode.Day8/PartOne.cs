using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
	class PartOne
	{
		internal static int GetAllNodes(string[] licenseFile)
		{
			var sumOfMetaData = 0;
			var numberOfChildNodes = Convert.ToInt32(licenseFile[0]);
			var numberOfMetaData = Convert.ToInt32(licenseFile[1]);

			var subnodes = licenseFile.ToList().GetRange(2, licenseFile.Length - numberOfMetaData - 2); ;
		

			for (var i = 0; i < numberOfChildNodes; i++)
			{
				sumOfMetaData += GetAllNodes(subnodes.ToArray());
				
			}

			var node = licenseFile.ToList();
			node.RemoveRange(2, licenseFile.Length - numberOfMetaData-2);
			sumOfMetaData += GetSumOfNodeMetaData(node.ToArray());

			return sumOfMetaData;
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
