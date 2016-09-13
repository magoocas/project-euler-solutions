/*
    Problem: 53

    Title: Combinatoric selections

    Description:
        There are exactly ten ways of selecting three from five, 12345:
        
            123, 124, 125, 134, 135, 145, 234, 235, 245, and 345
        
        In combinatorics, we use the notation, ^5C[3] = 10.
        
        In general,
        
            
        
        ^nC[r] = n!         ,where r ≤ n, n! = nx(n−1)x...x3x2x1, and 0! = 1.
            r!(n−r)!
        
        It is not until n = 23, that a value exceeds one-million: ^23C[10] = 1144066.
        
        How many, not necessarily distinct, values of  ^nC[r], for 1 ≤ n ≤ 100, are
        greater than one-million?
        

    Url: https://projecteuler.net/problem=53
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level03
{
    public class Solution053 : SolutionBase
    {

        public override object Answer()
        {
            return Enumerable.Range(23, 100 - 22)
                .Select(n => Enumerable.Range(1, n)
                    .Count(r => Combinatorics.Select(r, n) > 1000000))
                .Sum();
        }
    }
}

