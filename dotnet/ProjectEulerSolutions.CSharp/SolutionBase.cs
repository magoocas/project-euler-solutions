using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjectEulerSolutions.CSharp
{
    public abstract class SolutionBase
    {
        public string ProblemData { get; }
        public string SolutionId { get; }
        public SolutionBase()
        {
            SolutionId = Regex.Match(GetType().Name, "[0-9]{3}$").Value;
            var problemFile = $"data\\Problem{SolutionId}.txt";
            if (File.Exists(problemFile))
                ProblemData = File.ReadAllText(problemFile);
        }

        public static IEnumerable<Type> GetDerivedTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof (SolutionBase));
        }

        public T[][] GetProblemDataAsArray<T>(string rowSeparators, string columnSeparators, Func<string, T> valueConverter )
        {
            return ProblemData
                .Split(rowSeparators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(r =>
                    r.Split(columnSeparators.ToCharArray(), StringSplitOptions.None).Select(valueConverter).ToArray()
                ).ToArray();

        }

        public abstract object Answer();
    }
}
