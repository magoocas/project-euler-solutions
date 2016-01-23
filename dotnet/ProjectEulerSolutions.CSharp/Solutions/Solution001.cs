/*
    Problem: 1

    Title: Multiples of 3 and 5

    Description:
        If we list all the natural numbers below 10 that are multiples of 3 or
        5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        Find the sum of all the multiples of 3 or 5 below 1000.

    Url: https://projecteuler.net/problem=1
*/

using System.Linq;
using ProjectEulerSolutions.CSharp.Utility;

namespace ProjectEulerSolutions.CSharp.Solutions
{
    public class Solution001 : SolutionBase
    {
        public override object Answer()
        {
            return Sequence.Unfold(0, x => x + 1).TakeWhile(x=>x<1000).Where(x => x%3 == 0 || x%5 == 0).Sum();
        }
    }
}