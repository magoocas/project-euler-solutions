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
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSolutions.CSharp
{
    public class Solution005
    {
        public static int Answer()
        {
            //algorithm (hand tested)
            //1) convert the sequence of 1 - 20 into it's primes
            //2) count the max number of each prime required to generate any given number
            //3) multiply all the primes from step 2) together (max count of any given prime)

            return 0;
        }
    }
}

