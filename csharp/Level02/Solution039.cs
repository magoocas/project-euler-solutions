/*
    Problem: 39

    Title: Integer right triangles

    Description:
        If p is the perimeter of a right angle triangle with integral length sides, {a,
        b,c}, there are exactly three solutions for p = 120.
        
        {20,48,52}, {24,45,51}, {30,40,50}
        
        For which value of p ≤ 1000, is the number of solutions maximised?
        

    Url: https://projecteuler.net/problem=39
*/
/*
 Analyis
 a^2 + b^2 = c^2
 p = a + b + c
 ...
 c = p - (a + b)
 ...
 a = (p - 2b) / (2 - (2b/p))
 ...
 b is integer
 set 1 < b < p/2
 a is integer ? solution
*/

using System.Numerics;
using Numerics;

namespace csharp.Level02
{
    public class Solution039 : SolutionBase
    {
        public override object Answer()
        {
            var max = 0;
            int maxP = 1;
            for (int p = 1; p <= 1000; p++)
            {
                var count = 0;
                var bMax = p/2;
                for (int b = 1; b < bMax; b++)
                {
                    if(p%b!=0) continue; //I'm not sure this optimization is valid
                    var a = new BigRational((BigInteger)p-2*b)/new BigRational(2 * (p - b), p);
                    if (a.Denominator==1)
                        count++;
                }
                if (count > max)
                {
                    max = count;
                    maxP = p;
                }
            }
            return maxP;
        }
    }
}

