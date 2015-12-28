using NUnit.Framework;
using ProjectEulerSolutions.FSharp;

namespace Tests
{
	[TestFixture]
    public class FSharpTests
	{
		[Test(ExpectedResult = Answers.Problem001)]
		public int TestSolution001() => Solution001.Answer();
		[Test(ExpectedResult = Answers.Problem002)]
		public int TestSolution002() => Solution002.Answer();
		[Test(ExpectedResult = Answers.Problem003)]
		public long TestSolution003() => Solution003.Answer();
		[Test(ExpectedResult = Answers.Problem004)]
		public int TestSolution004() => Solution004.Answer();
		[Test(ExpectedResult = Answers.Problem005)]
		public long TestSolution005() => Solution005.Answer();
    }
}
