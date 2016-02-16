/*
    Problem: 34

    Title: Digit factorials

    Description:
        145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
        
        Find the sum of all numbers which are equal to the sum of the factorial of
        their digits.
        
        Note: as 1! = 1 and 2! = 2 are not sums they are not included.
        

    Url: https://projecteuler.net/problem=34
*/

using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution034 : SolutionBase
    {
        public override object Answer()
        {
            int sum = 0;
            var max = Enumerable.Range(1,9).Select(ToolBox.Factorial).Sum();

            Parallel.ForEach(Partitioner.Create(3, max), range =>
            {
                for (int i = range.Item1; i <= range.Item2; i++)
                    if (i == ToolBox.NumberToDigits(i).Select(ToolBox.Factorial).Sum())
                        Interlocked.Add(ref sum, i);
            });

            return sum;
        }
    }
}

