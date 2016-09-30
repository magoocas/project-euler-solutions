/*
    Problem: 60

    Title: Prime pair sets

    Description:
        The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes
        and concatenating them in any order the result will always be prime. For
        example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four
        primes, 792, represents the lowest sum for a set of four primes with this
        property.
        
        Find the lowest sum for a set of five primes for which any two primes
        concatenate to produce another prime.
        

    Url: https://projecteuler.net/problem=60
    
    References:
        https://projecteuler.net/thread=60;post=731
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level03
{
    public class Solution060 : SolutionBase
    {
        private const int Max = 1200;
        private int[,] _check = new int[Max, Max];

        public bool Check(int i, int j)
        {
            if (_check[i, j] == 0)
            {
                var prime1 = ToolBox.PrimeSieve.GetNthPrime(i);
                var prime2 = ToolBox.PrimeSieve.GetNthPrime(j);

                var newprime1 = ToolBox.Concatenate(prime1, prime2);
                var newprime2 = ToolBox.Concatenate(prime2, prime1);
                _check[i, j] = ToolBox.PrimeSieve[newprime1] ? 1 : -1;
                _check[j, i] = ToolBox.PrimeSieve[newprime2] ? 1 : -1;
            }
            return _check[i, j] == 1 && _check[j, i] == 1;
        }

        public bool Find(int[] matches, int matchDepth, int requiredDepth, int max, int currentPrime)
        {
            if (matchDepth == requiredDepth)
                return true;

            for (int i = 0; i < matchDepth; i++)
                if (!Check(currentPrime, matches[i]))
                    return false;

            matches[matchDepth] = currentPrime;

            var localMax = max - requiredDepth + matchDepth;
            for (int i = 1; i < localMax; i++)
            {
                if (Find(matches, matchDepth + 1, requiredDepth,max, i + 1))
                    return true;
            }
            return false;
        }

        public override object Answer()
        {
            var matches = new int[5];
            for (int i = 1; i < Max - 4; i++)
                if (Find(matches, 0, 5, Max, i))
                    break;
            return matches.Aggregate(0ul,(a,b)=>a+ToolBox.PrimeSieve.GetNthPrime(b));
        }
    }
}

