using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace csharp
{
    public abstract class SolutionBase
    {
        private readonly string _problemData = "";

        public SolutionBase()
        {
            SolutionId = Regex.Match(GetType().Name, "[0-9]{3}$").Value;
            var problemFile = Path.Combine("ProblemData", $"Problem{SolutionId}.txt");
            if (File.Exists(problemFile))
                _problemData = File.ReadAllText(problemFile);
        }

        public string ProblemData
        {
            get
            {
                if(_problemData == "")
                    throw new Exception($"Problem Data File for: {GetType().Name} missing.");
                return _problemData;
            }
        }

        public string SolutionId { get; }

        public static IEnumerable<Type> GetDerivedTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof (SolutionBase));
        }
        public T[] GetProblemDataAsArray<T>(string rowSeparators, Func<string, T> valueConverter)
        {
            return ProblemData
                .Split(rowSeparators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(valueConverter).ToArray();
        }

        public T[][] GetProblemDataAsMatrix<T>(string rowSeparators, string columnSeparators, Func<string, T> valueConverter )
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
