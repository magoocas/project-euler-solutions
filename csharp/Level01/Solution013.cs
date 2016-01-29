/*
    Problem: 13

    Title: 

    Description:
        Work out the first ten digits of the sum of the following one-hundred 50-digit
        numbers.
        
            {Problem013.txt}

    Url: https://projecteuler.net/problem=13
*/
using System.Numerics;
using System.Linq;

namespace csharp.Level01
{
    public class Solution013 : SolutionBase
    {
        public override object Answer()
        {
            var numbers = GetProblemDataAsArray("\r\n",BigInteger.Parse);

            return numbers.Aggregate((a, b) => a + b).ToString().Substring(0, 10);
        }
    }
}

