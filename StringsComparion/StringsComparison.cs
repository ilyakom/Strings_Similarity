using Microsoft.SqlServer.Server;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class StringsComparison
{
	/// <summary>
	/// significant words pattern
	/// </summary>
	private const string SplitPattern = "[^a-zA-Z0-9]+";

	/// <summary>
	/// Transliteration finction
	/// </summary>
	/// <param name="str"> String on Russin to transliterate</param>
	/// <returns></returns>
	private static string Tranliterate(string str)
	{
		var translitCapitalEn = new[]
		{
		  "A",
		  "B",
		  "V",
		  "G",
		  "D",
		  "E",
		  "Yo",
		  "Zh",
		  "Z",
		  "I",
		  "Y",
		  "K",
		  "L",
		  "M",
		  "N",
		  "O",
		  "P",
		  "R",
		  "S",
		  "T",
		  "U",
		  "F",
		  "Kh",
		  "Ts",
		  "Ch",
		  "Sh",
		  "Shch",
		  "\"",
		  "Y",
		  "'",
		  "E",
		  "Yu",
		  "Ya"
		};
		var translitLowEn = new[]
		{
		  "a",
		  "b",
		  "v",
		  "g",
		  "d",
		  "e",
		  "yo",
		  "zh",
		  "z",
		  "i",
		  "y",
		  "k",
		  "l",
		  "m",
		  "n",
		  "o",
		  "p",
		  "r",
		  "s",
		  "t",
		  "u",
		  "f",
		  "kh",
		  "ts",
		  "ch",
		  "sh",
		  "shch",
		  "\"",
		  "y",
		  "'",
		  "e",
		  "yu",
		  "ya"
		};
		var translitCapitalRu = new[]
		{
		  "А",
		  "Б",
		  "В",
		  "Г",
		  "Д",
		  "Е",
		  "Ё",
		  "Ж",
		  "З",
		  "И",
		  "Й",
		  "К",
		  "Л",
		  "М",
		  "Н",
		  "О",
		  "П",
		  "Р",
		  "С",
		  "Т",
		  "У",
		  "Ф",
		  "Х",
		  "Ц",
		  "Ч",
		  "Ш",
		  "Щ",
		  "Ъ",
		  "Ы",
		  "Ь",
		  "Э",
		  "Ю",
		  "Я"
		};
		var translitLowRu = new[]
		{
		  "а",
		  "б",
		  "в",
		  "г",
		  "д",
		  "е",
		  "ё",
		  "ж",
		  "з",
		  "и",
		  "й",
		  "к",
		  "л",
		  "м",
		  "н",
		  "о",
		  "п",
		  "р",
		  "с",
		  "т",
		  "у",
		  "ф",
		  "х",
		  "ц",
		  "ч",
		  "ш",
		  "щ",
		  "ъ",
		  "ы",
		  "ь",
		  "э",
		  "ю",
		  "я"
		};

		for (var index = 0; index <= 32; ++index)
		{
			str = str.Replace(translitCapitalRu[index], translitCapitalEn[index]);
			str = str.Replace(translitLowRu[index], translitLowEn[index]);
		}
		return str;
	}

	/// <summary>
	/// Levenshtein distance calculation
	/// </summary>
	/// <param name="str1"></param>
	/// <param name="str2"></param>
	/// <returns></returns>
	private static int EditDistance(string str1, string str2)
	{
		var length1 = str1.Length;
		var length2 = str2.Length;
		var numArray = new int[length1 + 1, length2 + 1];

		for (var i = 0; i <= length1; ++i)
			numArray[i, 0] = i;

		for (var i = 0; i <= length2; ++i)
			numArray[0, i] = i;

		for (var i = 1; i <= length1; ++i)
		{
			for (var j = 1; j <= length2; ++j)
			{
				var num = str2[j - 1] == str1[i - 1] ? 0 : 1;
				var numArray2 = new[]
				{
					numArray[i - 1, j] + 1,
					numArray[i, j - 1] + 1,
					numArray[i - 1, j - 1] + num
				};

				numArray[i, j] = numArray2.Min();
				if (i > 1 && j > 1 && str1[i - 1] == str2[j - 2] && str1[i - 2] == str2[j - 1])
					numArray[i, j] = Math.Min(numArray[i, j], numArray[i - 2, j - 2] + num);
			}
		}

		return numArray[length1, length2];
	}

	/// <summary>
	/// Removing rows and cols with the according indexes of max element
	/// </summary>
	/// <param name="deleteElem"> What to delete? </param>
	/// <param name="originalArray"> Where to delete? </param>
	private static void TrimArrayAtMaxElem(double deleteElem, ref double[,] originalArray)
	{
		for (var row = 0; row < originalArray.GetLength(0); ++row)
		{
			for (var col = 0; col < originalArray.GetLength(1); ++col)
			{
				if (Math.Abs(originalArray[row, col] - deleteElem) > 0.00001) continue;
				ZeroRowsAndCols(row, col, ref originalArray);
				return;
			}
		}
	}

	/// <summary>
	/// Make all elements in the following rows and cols equal to zero
	/// </summary>
	private static void ZeroRowsAndCols(int row, int col, ref double[,] originalArray)
	{
		for (var i = 0; i < originalArray.GetLength(0); ++i)
			originalArray[i, col] = 0.0;

		for (var i = 0; i < originalArray.GetLength(1); ++i)
			originalArray[row, i] = 0.0;
	}

	/// <summary>
	/// Compare two words
	/// </summary>
	/// <param name="word1"></param>
	/// <param name="word2"></param>
	/// <param name="maxLength"></param>
	/// <returns> Weighted result of two word comparison</returns>
	private static double CompareWords(string word1, string word2, int maxLength)
	{
		return (maxLength - EditDistance(word1, word2)) / (double) maxLength;
	}

	/// <summary>
	/// Compare two strings (multiple words)
	/// </summary>
	/// <param name="str1"></param>
	/// <param name="str2"></param>
	/// <returns>Percentage value of strings similarity </returns>
	[SqlFunction(FillRowMethodName = "CompareStrings")]
	public static double CompareStrings(string str1, string str2)
	{
		if (str1 == null) throw new ArgumentNullException(nameof(str1));
		if (str2 == null) throw new ArgumentNullException(nameof(str2));

		var array1 = Regex.Split(Tranliterate(str1.ToLower()), SplitPattern).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
		var array2 = Regex.Split(Tranliterate(str2.ToLower()), SplitPattern).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

		if (array1.Length == 0 && array2.Length == 0) return 1;

		var originalArray = new double[array1.Length, array2.Length];
		var val1 = array1.Select(x => x.Length).Sum();
		var val2 = array2.Select(x => x.Length).Sum();
		var num1 = Math.Max(val1, val2);
		var num2 = 0.0;

		for (var i = 0; i < array1.Length; ++i)
		{
			for (var j = 0; j < array2.Length; ++j)
			{
				var maxLength = Math.Max(array1[i].Length, array2[j].Length);
				originalArray[i, j] = CompareWords(array1[i], array2[j], maxLength) * ((val1 > val2 ? array1[i].Length : array2[j].Length) / (double) num1);
			}
		}

		while (true)
		{
			var deleteElem = originalArray.Cast<double>().Max();
			if (Math.Abs(deleteElem) > 0.00001)
			{
				TrimArrayAtMaxElem(deleteElem, ref originalArray);
				num2 += deleteElem;
			}
			else
				break;
		}
		return num2;
	}
}
