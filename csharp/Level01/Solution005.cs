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

namespace csharp.Level01
{
    public class Solution005 : SolutionBase
    {
        public override object Answer()
        {
            var answer = Enumerable.Range(2, 19).Select(p =>
                ToolBox.GetPrimeFactors(p)
                    .GroupBy(f => f)
                    .Select(g => new
                    {
                        prime = g.Key,
                        count = g.Count()
                    }))
                .SelectMany(x => x)
                .GroupBy(x => x.prime)
                .Select(a => new
                {
                    prime = a.Key,
                    count = a.Max(b => b.count)
                })
                .Aggregate(1, (a, b) => a*(int) Math.Pow(b.prime, b.count));


            return answer;
        }
    }
}