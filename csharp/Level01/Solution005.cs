/*
    Problem: 5

    Title: Smallest multiple

    Description:
        2520 is the smallest number that can be divided by each of the numbers
        from 1 to 10 without any remainder.
        What is the smallest positive number that is evenly divisible by all of
        the numbers from 1 to 20?

    Url: https://projecteuler.net/problem=5
*/

using System;
using System.Linq;
using csharp.Utility;

namespace csharp.Level01
{
    public class Solution005 : SolutionBase
    {
        public override object Answer()
        {
            var answer = Enumerable.Range(2, 19).Select(p =>
                ToolBox.GetPrimeFactors((ulong) p)
                    .GroupBy(f => f)
                    .Select(g => new
                    {
                        prime = g.Key,
                        count = g.Count()
                    }))
                .SelectMany(x => x)
                .GroupBy(x => x.prime)
                .Select(a =>
                {
                    var prime = a.Key;
                    var result = 1ul;
                    for (int i = 0; i < a.Max(b => b.count); i++)
                        result *= prime;
                    return result;
                }).Aggregate(1ul, (a, b) => a*b);


            return answer;
        }
    }
}