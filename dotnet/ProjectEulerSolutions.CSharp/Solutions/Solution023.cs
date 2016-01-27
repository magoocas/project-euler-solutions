/*
    Problem: 23

    Title: 

    Description:
        A perfect number is a number for which the sum of its proper divisors is
        exactly equal to the number. For example, the sum of the proper divisors of 28
        would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
        
        A number n is called deficient if the sum of its proper divisors is less than n
        and it is called abundant if this sum exceeds n.
        
        As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest
        number that can be written as the sum of two abundant numbers is 24. By
        mathematical analysis, it can be shown that all integers greater than 28123 can
        be written as the sum of two abundant numbers. However, this upper limit cannot
        be reduced any further by analysis even though it is known that the greatest
        number that cannot be expressed as the sum of two abundant numbers is less than
        this limit.
        
        Find the sum of all the positive integers which cannot be written as the sum of
        two abundant numbers.
        

    Url: https://projecteuler.net/problem=23
*/
using System.Linq;
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace ProjectEulerSolutions.CSharp.Solutions
{
    public class Solution023 : SolutionBase
    {
        public override object Answer()
        {
            var abundantNumbers = Enumerable.Range(1,28123)
                .Where(x => Solution021.GetDivisors(x, true).Sum() > x).ToList();

            var abundantSums = new List<int>();

            for (int i = 0; i < abundantNumbers.Count; i++)
                for (int j = i; j < abundantNumbers.Count; j++)
                    abundantSums.Add(abundantNumbers[i] + abundantNumbers[j]);

            abundantSums = abundantSums.Distinct().ToList();
            abundantSums.Sort();

            int sum = 0;

            for (int i = 1; i <= 28123; i++)
            {
                if (!abundantSums.Contains(i))
                    sum += i;
            }

			return sum;
        }
    }
}

