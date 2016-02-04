/*
    Problem: 34

    Title: 

    Description:
        145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
        
        Find the sum of all numbers which are equal to the sum of the factorial of
        their digits.
        
        Note: as 1! = 1 and 2! = 2 are not sums they are not included.
        

    Url: https://projecteuler.net/problem=34
*/

using System;
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
            var max = ToolBox.Factorial(9)*9;

            var chunks = Environment.ProcessorCount;
            var chunkSize = max/chunks + 1;
            var results = new int[chunks];

            Parallel.For(0, chunks, ()=>0, (i,loop,chunkSum) =>
            {
                var chunkStart = i*chunkSize;
                var chunkMax = i*chunkSize + chunkSize;
                for (int j = chunkStart; j < chunkMax; j++)
                {
                    if (j == ToolBox.NumberToDigits(j).Select(ToolBox.Factorial).Sum())
                        chunkSum += j;
                }
                return chunkSum;
            }, chunkSum => Interlocked.Add(ref sum, chunkSum));


			return sum-3;
        }
    }
}

