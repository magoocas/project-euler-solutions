/*
    Problem: 35

    Title: 

    Description:
        The number, 197, is called a circular prime because all rotations of the
        digits: 197, 971, and 719, are themselves prime.
        
        There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71,
        73, 79, and 97.
        
        How many circular primes are there below one million?
        

    Url: https://projecteuler.net/problem=35
*/

using System.Collections.Generic;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution035 : SolutionBase
    {
        public override object Answer()
        {
            var primes = new HashSet<ulong>(ToolBox.GetPrimes(1000000));
            var count = 0;
            foreach (var prime in primes)
            {
                var possiblePrime = ToolBox.Base10RotateRightUInt64(prime);
                var isCircular = true;
                while (possiblePrime != prime)
                {
                    if (!primes.Contains(possiblePrime))
                    {
                        isCircular = false;
                        break;
                    }
                    possiblePrime = ToolBox.Base10RotateRightUInt64(possiblePrime);
                }
                if (isCircular)
                    count++;
            }
            
			return count;
        }
    }
}

