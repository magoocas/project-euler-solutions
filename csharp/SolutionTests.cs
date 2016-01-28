using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CsvHelper;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class SolutionTests
    {
        private static IEnumerable TestCases()
        {
            var answers = new CsvReader(new StreamReader("ProblemData\\Answers.txt"))
                .GetRecords<SolutionTestCase>()
                .ToDictionary(s => s.SolutionName, s => s.Answer);

            foreach (var type in SolutionBase.GetDerivedTypes())
            {
                var solution = (SolutionBase) Activator.CreateInstance(type);

                if (!answers.ContainsKey(type.Name))
                    answers.Add(type.Name, "");

                yield return new TestCaseData(
                    new Func<object>(() => solution.Answer())
                    , type, answers[type.Name])
                    .SetName($"{type.Name}")
                    .Returns(answers[type.Name]);
            }
        }


        [Test, TestCaseSource(nameof(TestCases))]
        public string TestSoution(Func<object> solution, Type solutionType, string answer)
        {
            var stopwatch = new Stopwatch();
            string result;

            stopwatch.Start();
            result = solution().ToString();
            stopwatch.Stop();

            Console.WriteLine($"Result: {result}, Answer: {answer}, Execution time: {stopwatch.ElapsedTicks/10} us.");

            if(answer=="")
                Assert.Inconclusive();

            return result;
        }
    }
}