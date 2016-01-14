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
                .ToDictionary(s => s.SolutionName, s => s.Answer);

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

                    if (!answers.ContainsKey(type.Name))
                        answers.Add(type.Name, "No Answer In TestCases File!");
                        
                    return new TestCaseData(solution, type, answers[type.Name])
                    .SetName($"{type.Namespace}_{type.Name}")
                    .Returns(answers[type.Name]);
                });
        }


		[Test, TestCaseSource(nameof(TestCases))]
        public string TestSoution(Func<object> solution, Type solutionType, string answer)
		{
            var result = solution().ToString();

            //Console.WriteLine($"{solutionType.Namespace.Split('.')[1]} - {solutionType.Name} returned {result}, expected {answer}.");

            return result;
		}

	}
}

