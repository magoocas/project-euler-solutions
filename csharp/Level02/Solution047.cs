/*
    Problem: 47

    Title: Distinct primes factors

    Description:
        The first two consecutive numbers to have two distinct prime factors are:
        
            14 = 2 x 7
            15 = 3 x 5
        
        The first three consecutive numbers to have three distinct prime factors are:
        
            644 = 2^2 x 7 x 23
            645 = 3 x 5 x 43
            646 = 2 x 17 x 19.
        
        Find the first four consecutive integers to have four distinct prime factors.
        What is the first of these numbers?
        

    Url: https://projecteuler.net/problem=47
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution047 : SolutionBase
    {
        public override object Answer()
        {
            for (ulong i = 644; i < 2000000; i++)
            {
                for (ulong j = 0; j < 4; j++)
                {
                    if (ToolBox.GetPrimeFactors(i + j, true).Distinct().Count() != 4)
                    {
                        i += j;
                        break;
                    }
                    if (j == 3)
                        return i;
                }
            }
            return 0;
        }
    }
}

