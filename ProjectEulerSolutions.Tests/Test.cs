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
		static IEnumerable TestCases()
        {
            var answers = new CsvReader(new StreamReader("TestCases"))
                .GetRecords<SolutionTestCase>()
                .ToDictionary(s=>s.SolutionName,s=>s.Answer);

            return new[]
            { 
                "ProjectEulerSolutions.CSharp.dll", 
                "ProjectEulerSolutions.FSharp.dll" 
            }
                .Select(Assembly.LoadFrom)
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.Name.StartsWith("Solution"))
                .Select(type =>
                {
                    Func<object> solution;
                    var method = type.GetMethod("Answer");
                    if (method != null)
                        solution = () => method.Invoke(null, null);
                    else
                        solution = () => type.GetProperty("Answer").GetValue(null);
                        
                    return new TestCaseData(solution)
                        .SetName(type.Namespace + "_" + type.Name)
                        .Returns(answers[type.Name]);
                });
        }


		[Test, TestCaseSource("TestCases")]
        public string TestSoution(Func<object> solution)
		{
            return solution().ToString();
		}

	}
}

