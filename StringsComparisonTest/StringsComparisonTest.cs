using System;
using NUnit.Framework;

namespace StringsComparisonTest
{
	[TestFixture]
	public class StringsComparisonTest
	{
		[Test]
		[TestCase("string", "string", 1)]
		[TestCase("стринг", "string", 1)]
		[TestCase("str", "string",0.5)]
		[TestCase("", "", 1)]
		[TestCase("		", "                          ",1)]
		[TestCase("abc def", "def abc", 1)]
		[TestCase("0123456789", "02468", 0.5)]
		public void CompareTest(string first, string second, double expectedResult)
		{
			//Act
			var result = StringsComparison.CompareStrings(first, second);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		[TestCase(null, "test")]
		[TestCase("test", null)]
		public void StringComparisonExceptionsTest(string first, string second)
		{
			Assert.Throws<ArgumentNullException>(() => StringsComparison.CompareStrings(first, second));
		}

	}
}
