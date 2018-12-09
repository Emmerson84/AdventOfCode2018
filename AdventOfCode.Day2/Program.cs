using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day2
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] input = { "jiwamotqgcfnudclzbyxkzmrvp", "jiwamotqgsfnidcvzpyxkhervp", "jiwamotqgsqnjdclzbyxkaervp", "jiwamotqgsvnudclzbvikhervp", "jiwamotqgjfnuqclzbyxkhemvp", "jifamotqgsfnudclzbyxohecvp", "jiwamotqssfnudclzjyxkhekvp", "jiramotqgsfnudclzbyxztervp", "jiwamotqgsfnuddozbyxjhervp", "jiwamohqgsfntdclzxyxkhervp", "jfwamobqgsfnudzlzbyxkhervp", "fiwamotqgsfnudcfzbyfkhervp", "jiwamothgsonudclzbyxkhcrvp", "jinamojqgsftudclzbyxkhervp", "jiwamotbgsfnudclzpyxchervp", "wiwaiotqgsfnudhlzbyxkhervp", "jiwamotqgsfktdclzbyxlhervp", "jimamokqgsfnudclzbyokhervp", "jiwqmotqgyfnudcdzbyxkhervp", "ziwvmotqgsfnusclzbyxkhervp", "jiwamotqgsfnuzclpbyxkherip", "jiwumotqgsfnudclzgyxkhedvp", "jiwomocqgsfnudylzbyxkhervp", "jtwamotqgxfnudwlzbyxkhervp", "jiwamotqgsfnudclzbnvkherva", "jiwaxoeqgsfnsdclzbyxkhervp", "jiwamotqgsrnudclzbyxkoekvp", "jiwamotqgsfnudclzbynkhorvr", "jiwavotqgsfxudclzbmxkhervp", "jiwamotqksfnudcvzbytkhervp", "qiwamotqgsfnadwlzbyxkhervp", "jiwamctqgsfnwdclzhyxkhervp", "jiwamotqggfnudclzbyxqwervp", "jiwamdtqgslnurclzbyxkhervp", "jiwamozqgsfnupclobyxkhervp", "jiwamotqgtfnudcbzbypkhervp", "jiwnmotqgsfnudclmbybkhervp", "jihamotqgsfnudclzbyxkhsivp", "jiwamotqgsfcudclzbyxkxervz", "jiwamotqgsfhwdclzbyxkfervp", "jivamotqgsfnudclzbixkpervp", "jiwamotagsfrudclzbyzkhlrvp", "jiwamotqgsfnudclzbdxkhbrvh", "jfwamotsasfnudclzbyxkhervp", "jiwrmotqgsfnudclzbyxgherkp", "jiwomotqisfnudcbzbyxkhervp", "jiermotqgsfjudclzbyxkhervp", "jiwamotqgsfeudcpzbyxkmervp", "jxwpmotqgsfnufclzbyxkhervp", "jiwamotqgsfnunclzpyxkhecvp", "jpwamotqvsfnudclzbyxkhprvp", "jimamothgsfnudclzbjxkhervp", "jiwamotqgsfnudclzbybkhewvc", "jiwqmotqgsfnudclzbyrkheovp", "jiwapotqgsfnudblzbyxkhsrvp", "jiwhmotqgsfaudclzbyakhervp", "jiqamotjgsfnudclzbyxphervp", "jiwamotqgsfnudklzbyeghervp", "jowamotqgsfnudcljbyxshervp", "jiwamotxgkfnudclzbyskhervp", "jifamotqgsfnudclzbyxklprvp", "jiwamotqgsfnudclzbghkherep", "jiwamotygsfnudcezbyxkheovp", "jiwmmhtqgsfnudclzhyxkhervp", "fiwxmotqgsfnudclzbwxkhervp", "jvwapotwgsfnudclzbyxkhervp", "jiwamodqgsfnudcizbtxkhervp", "jiwamotqgsfnhnclzbyxkwervp", "jiwsmozqgsfnudclzbyxkwervp", "jwwamotqgsxnudclzbyxkpervp", "jiwamotqgsftudclzbcckhervp", "jiwaootqgnfnudclzbrxkhervp", "aicamotqgsfnudclzbyxklervp", "jilamolqgsfnudclzbyxknervp", "jiwamotqgqftudcczbyxkhervp", "jiwmmntqgsfnudclzbyxkhewvp", "dxwamotqgsfnudclzbyxkhervn", "imwamotqgsfnudclzbyxkhervv", "jiwammtqgsfnudcrzsyxkhervp", "jiwamojqgsznuuclzbyxkhervp", "bisamotqgsqnudclzbyxkhervp", "jiwaootqksfyudclzbyxkhervp", "jiwamotqgscnudclzbyskhervs", "jiwamltqgsfnudhlzbyxkhervh", "jiwemotggsfnuuclzbyxkhervp", "jiwamotqgsfnudclzbexkheoxp", "jiwayotqgfffudclzbyxkhervp", "jywamotqgsftudclzbyxkherxp", "viwamotqgdfnudcfzbyxkhervp", "jioamotvgsfnudclwbyxkhervp", "jiwomotqgsflurclzbyxkhervp", "jiwamotqgsfnudclzbyckhernh", "jiwarobqosfnudclzbyxkhervp", "jiwamotqgsfnudclbbyzkkervp", "jiwamvtqgsfwudclzbyxkhetvp", "jtwavotdgsfnudclzbyxkhervp", "jiwamotqzsjnydclzbyxkhervp", "jiwamotqgsfnrdctzbyxkxervp", "jiwamotqgsfnudclzbyxehezyp", "jiwamftqgsfcudclqbyxkhervp", "jiwnmotqgssnudclzbyxkherbp", "jidgmotqgsfnbdclzbyxkhervp", "biwamotqgnfnudclzbyxkhervc", "jizamotqxffnudclzbyxkhervp", "jiwamztqgsfnudclzbyxkhevvi", "jmwamotqgsfnudclzbtwkhervp", "jxwamotqgsfkudchzbyxkhervp", "jiwamotqgspqudclzbyxkhervl", "jiyagoxqgsfnudclzbyxkhervp", "jawamotqgsfnudllzbyxkhervr", "jfwamotqgsxnudclzbyxklervp", "juaametqgsfnudclzbyxkhervp", "jiwamotqgsfnudcrybyxkhnrvp", "jiwamotqgsfnudclfbmxkheovp", "jiwamotqgsfnukclzbykkhervz", "jwwamztqgsfnudclzbyxkhervt", "jiwamotqgsbnudclzbyxkhkrvu", "jewamotqgsfnuqclzbyxkherve", "jiwamotqgsfntdblrbyxkhervp", "jiwamotqgsfoudclzbyxcherwp", "jiwamopqgscnudclzbyxkhrrvp", "jiwamotqosfnudclkbyxyhervp", "jiwamotqysfnudclzbyxqhermp", "jiwamotqgsfnuscbzbyzkhervp", "jiwamotqgofnudflgbyxkhervp", "jvwamotqgefnydclzbyxkhervp", "jjwamotqgsfnudclzbkxkhetvp", "jiwasctqcsfnudclzbyxkhervp", "jiwamotqgsfnudcqzbyxkherxf", "jiwamotqgsgnudclzbtxkherip", "jiwamotqksfnudflzbyxkhervf", "jixamotqgsfnudclzbyxklerzp", "jkwamatqgsfnudcmzbyxkhervp", "wiwamotqcsfnudclzbyxkhervu", "jiwahotqgsfnudclzbyxqjervp", "juhamotqdsfnudclzbyxkhervp", "jiwamotqqsfnudclzryxkherfp", "vfwazotqgsfnudclzbyxkhervp", "jicamoaqgsfnudclzbyxkherup", "jiwqmogqxsfnudclzbyxkhervp", "xiwamotqgsfnudclybyxkhurvp", "jiwamitqgssnudclzbpxkhervp", "jiwamotqgstnudqlzbyxkhrrvp", "jiwamctqgsfnuwclzbfxkhervp", "jiwzmotqgsfnuhclzbyxkhwrvp", "hiwamotqgsfmudclzbykkhervp", "jiwamotqgsrnudclzbyxohnrvp", "jswametqgsfcudclzbyxkhervp", "jiwamotqgsfsudcazeyxkhervp", "jiwamotqgsfnqdctzbyxkherjp", "jhwamotqgsfnudclgbyxkhervw", "jiwamotqgsxnudglzbyxkhermp", "jiwamotqgsfnudclabjxkrervp", "jiwamotqbsrnudclpbyxkhervp", "jiqamotugsfnudcrzbyxkhervp", "jiwamotqgsfnuwdazbyxkhervp", "jiwamctqghwnudclzbyxkhervp", "siwamotqgsznudclzbyxghervp", "jiwamotdgsfrudclcbyxkhervp", "jiwamotqgsfnddylzbyxkhelvp", "jiwqmotqgjfnudclzbyxkhervd", "jiwamotogffvudclzbyxkhervp", "jiwawhtqgsfnudclzbyxkhervi", "jiwomotqgsfnulclzjyxkhervp", "diwamotqgsfnudclzbypkhervk", "jiwamotqgsfqtsclzbyxkhervp", "jiwgmotqgsfnudcwzbyxkhnrvp", "jiwamotqksfnvdclzbyxkherve", "jiwamztqgsfnusxlzbyxkhervp", "hiwamotqgssnudclibyxkhervp", "jiwamotzgsfnudclzbyxxhemvp", "jiwamotqgsfrudclzbyzkhlrvp", "jiwaaotqgsfnudcazbyxkhervf", "jiwadotqgsffudclzbyxkhbrvp", "jieamotqgafnudclzbyxknervp", "jieamotqgsfnudclzjyxjhervp", "jvwamotqglfnudclzbyxkhxrvp", "jiwamotqgsfnudcozdyxkhdrvp", "riwamocqgsfnudclzbtxkhervp", "jiwawitqgsfnudclzbyxkhlrvp", "giwamotqgsfvudclzayxkhervp", "jiwamotqgsfnddcjzjyxkhervp", "jiwamotpgrfnxdclzbyxkhervp", "jiwamotkgnfnubclzbyxkhervp", "jiwamokqgsfnukclzbyxkservp", "jiwamotqgyfnudzlqbyxkhervp", "jiwamotqgsonudclzbyxhhwrvp", "iiwamotqgsfnudclzbvxkhemvp", "jxwamotogsfnudclzbyxkhervh", "jiwkmocqgsfnudclzbyxkhervg", "jiwymotzgsfnudclvbyxkhervp", "jiwatotqgsfaudcvzbyxkhervp", "jiwamotkgsfnudclzbyckhsrvp", "jiwamotqgsfiuyklzbyxkhervp", "jiwamotqgsfnudclzmyakiervp", "jiwamotqgsfnidcyzbyxfhervp", "jiwakotqgsfnudclzbaukhervp", "jixadotqgsfnudglzbyxkhervp", "jiwamotqnsfnudclrbyxkhemvp", "jiwamotqgsfnhdtlzbyxuhervp", "jiwamotqlsfnudcyzbyxkhervu", "jiwamotqgsfnuxclxbyxkheryp", "jiwamotqgafnudflhbyxkhervp", "jicamotqgsfnufcqzbyxkhervp", "jiwamotqgsmnudcszbyxfhervp", "jiwamotqgsfnudclzryxkjekvp", "jiwamocqgsfnudflzayxkhervp", "jiwomotqgsfaudclzkyxkhervp", "niwamoaqgsfnuyclzbyxkhervp", "jiwamogqdsfnudcvzbyxkhervp", "jiwamotbgsfnudclhbyxehervp", "jiwamdtqgsfnudclzbyxdhergp", "jiwamotqgofnudclzbyxkhcrjp", "jhfamotqgsfnudclzbyxkherjp", "jiwqmotqgsfkudclzbixkhervp", "jdfametqgsfnudclzbyxkhervp", "jioamotqgrfnudclzbqxkhervp", "jiwamotqgornudclzbyxkheavp", "jlwarotqgsfbudclzbyxkhervp", "jiwamyyqgsfnudclzbyxkhorvp", "piwamotqgsfnudclnbmxkhervp", "jiwvmotqgsfnudnlzbyxshervp", "jiwamotqjsfnudclzbytkhenvp", "wswamotqgsfnudcfzbyxkhervp", "jiwamotqgsftddclrbyxkhervp", "jiwamytqgsfnudclzbyxkhwrzp", "jiwamotqgsfnudcbzayxkmervp", "jiykmokqgsfnudclzbyxkhervp", "jiwamotqqsxnudclzbixkhervp", "jiwamotqgsfnubclzboxihervp", "jiwsmottgsfnudclzbrxkhervp", "jiwamotqgsfnudcgzbexkherjp", "juwamotqgsfnudclzcyvkhervp", "jiwamotqglfcudcdzbyxkhervp", "jiwamotqgsftudclzbynkhevvp", "jiwamotdlzfnudclzbyxkhervp", "jiwamohqgsfnuyclzbyxkhervk", "jiwamodygsanudclzbyxkhervp", "jiwamotqgsfnujclzbyxrhewvp", "jicamotqgsfnudcmzbyhkhervp", "jiwamvtqgvfnudclzayxkhervp", "jiwamotqgsfnuzclzfyxkhevvp", "jiwafotqgsfnudcejbyxkhervp", "jiwamomqgyfnudclzbyzkhervp", "jiqamorqgsfnudclqbyxkhervp", "jiwamotqgsfpudclzbyxkkvrvp", "jiwamotqgsfnuiclzbyxhherfp", "jiwagotqgsfoudclzbyxkdervp", "jiwamotmgmfnudclzbyxkhermp", "jltamotqgsfnudctzbyxkhervp"};

			Console.WriteLine($"Result Day2.1: {GetCheckSum(input)}");
			Console.WriteLine($"Result Day2.2: {GetBoxCodes(input)}");
			Console.ReadKey();

		}

		private static string GetBoxCodes(string[] input)
		{
			string matchingCodeSubsection = null;
			var codeList = input;

			foreach (var code in input)
			{
				foreach (var comparingCode in codeList)
				{
					matchingCodeSubsection = GetCodeWithoutDifference(code, comparingCode);

					if (matchingCodeSubsection != null)
					{
						return matchingCodeSubsection;
					}
				}
				codeList = codeList.Skip(1).ToArray();
			}

			return "No match found";
		}

		private static string GetCodeWithoutDifference(string codeOne, string codeTwo)
		{
			var counter = 0;
			int currentDifferenceIndex = 0;
			for(var i = 0; codeOne.Count() > i; i++)
			{
				if (!codeOne[i].Equals(codeTwo[i]))
				{
					counter++;
					currentDifferenceIndex = i;
				}
				if(counter > 1)
				{
					return null;
				}
			}
			if(counter == 1)
			{
				StringBuilder sb = new StringBuilder(codeOne);
				sb.Remove(currentDifferenceIndex, 1);
				
				return sb.ToString();
			}

			return null;
		}

		private static int GetCheckSum(string[] input)
		{
			int a = 0;
			int b = 0;

			foreach (var word in input)
			{
					var x = GetDoublesAndTriples(word);
					a = a + x[0];
					b = b + x[1];
			}
			return a * b;
		}

		private static int[] GetDoublesAndTriples(string word)
		{
			var hashset = new HashSet<char>();
			var codeResult = new Dictionary<char, int>();
			foreach (var letter in word)
			{
				if (!hashset.Add(letter))
				{
					try
					{
						codeResult[letter] = codeResult[letter] + 1;
					}
					catch(KeyNotFoundException)
					{
						codeResult.Add(letter, 2);
					}
				}
			}

			var doublesAndTriples = new int[2];
			if (codeResult.Any(d => d.Value == 2)) doublesAndTriples[0] = 1;
			if (codeResult.Any(d => d.Value == 3)) doublesAndTriples[1] = 1;

			return doublesAndTriples;
		}
	}
}
