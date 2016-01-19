/*
    Problem: 14

    Title: Longest Collatz sequence

    Description:
        The following iterative sequence is defined for the set of positive integers:
        
            n → n/2 (n is even)
            n → 3n + 1 (n is odd)
        
        Using the rule above and starting with 13, we generate the following sequence:
        
            13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
        
        It can be seen that this sequence (starting at 13 and finishing at 1) contains
        10 terms. Although it has not been proved yet (Collatz Problem), it is thought
        that all starting numbers finish at 1.
        
        Which starting number, under one million, produces the longest chain?
        
        NOTE: Once the chain starts the terms are allowed to go above one million.
        

    Url: https://projecteuler.net/problem=14
*/

namespace ProjectEulerSolutions.CSharp.Solutions
{
    public class Solution014 : SolutionBase
    {
        public override object Answer()
        {
            var maxDistance = 0;
            long maxNumber = 1;

            for (var i = 2; i < 1000000; i++)
            {
                long next = i;
                var distance = 0;
                while ((next = (next & 1) == 0 ? next >> 1 : next*3 + 1) != 1)
                    distance++;
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    maxNumber = i;
                }
            }
            return maxNumber;
        }
    }
}