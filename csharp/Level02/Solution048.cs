/*
    Problem: 48

    Title: Self powers

    Description:
        The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
        
        Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
        

    Url: https://projecteuler.net/problem=48
*/

using System.Numerics;

namespace csharp.Level02
{
    public class Solution048 : SolutionBase
    {
        public override object Answer()
        {
            BigInteger sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                BigInteger num = 1;
                for (int j = 1; j <= i; j++)
                {
                    num *= i;
                }
                sum += num;
            }
            var sumString = sum.ToString();
            return sumString.Substring(sumString.Length - 10);
        }
    }
}

