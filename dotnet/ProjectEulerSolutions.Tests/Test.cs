﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
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
            var stopwatch = new Stopwatch();
            var runCount = 0;
		    var minTime = 100;
		    var maxTime = Debugger.IsAttached ? 0 : 1000;
		    var maxRun = 1000;
            string result = "";

		    try
            { 
		        var task = Task.Run(() =>
		        {
		            while (stopwatch.ElapsedMilliseconds < minTime && runCount < maxRun)
		            {
		                stopwatch.Start();
		                result = solution().ToString();
		                stopwatch.Stop();
		                runCount++;
		            }
		        });

                if(Debugger.IsAttached)
		            task.Wait();
                else
                    task.Wait(new CancellationTokenSource(maxTime).Token);


            }
		    catch(OperationCanceledException)
		    {
		        if (stopwatch.IsRunning)
		            stopwatch.Stop();
                throw new TimeoutException($"Solution exceeded max time of {maxTime} seconds.");
		    }
            

            Console.WriteLine($"Ran {runCount} times, with average execution time: {stopwatch.ElapsedTicks/10/runCount} us.");
            
            return result;
		}

	}
}

