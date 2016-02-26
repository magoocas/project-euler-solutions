/*
    Problem: 41

    Title: Pandigital prime

    Description:
        We shall say that an n-digit number is pandigital if it makes use of all the
        digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is
        also prime.
        
        What is the largest n-digit pandigital prime that exists?
        

    Url: https://projecteuler.net/problem=41
*/

using System.Collections.Generic;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution041 : SolutionBase
    {
        
        public override object Answer()
        {
            foreach (var n in Pandigital.Pick(new List<int> {7,6,5,4,3,2,1}))
            {
                if (PrimeGenerator2.PrimeSieve[n])
                    return n;
            }

            return -1;
        }
    }
}

