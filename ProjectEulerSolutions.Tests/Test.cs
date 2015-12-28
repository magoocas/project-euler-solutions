using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using NUnit.Framework;

namespace ProjectEulerSolutions.Tests
{
	[TestFixture]
	public class Tests
	{
		static Dictionary<string, Type> _cSharpSolutions;
		static Dictionary<string, Type> _fSharpSolutions;

		static IEnumerable TestCases()
		{
			var testCases = new CsvReader(new StreamReader("TestCases")).GetRecords<SolutionTestCase>();

			foreach (var test in testCases)
				yield return new TestCaseData(test.SolutionName).Returns(test.Answer);
		}

		[TestFixtureSetUp]
		public void TestSetup()
		{
			_cSharpSolutions = Assembly.LoadFrom("ProjectEulerSolutions.CSharp.dll")
				.GetTypes()
				.Where(t => t.Name.StartsWith("Solution"))
				.ToDictionary(t => t.Name, t => t);

			_fSharpSolutions = Assembly.LoadFrom("ProjectEulerSolutions.FSharp.dll")
				.GetTypes()
				.Where(t => t.Name.StartsWith("Solution"))
				.ToDictionary(t => t.Name, t => t);
		}


		[Test, TestCaseSource("TestCases")]
		public string TestCSharpSoution(string solutionName)
		{
			var answer = _cSharpSolutions[solutionName]
				.GetMethod("Answer")
				.Invoke(null, null);

			return answer.ToString();

		}

		[Test, TestCaseSource("TestCases")]
		public string TestFSharpSoution(string solutionName)
		{
			var answer = _fSharpSolutions[solutionName]
				.GetMethod("Answer")
				.Invoke(null, null);

			return answer.ToString();
		}

	}
}

