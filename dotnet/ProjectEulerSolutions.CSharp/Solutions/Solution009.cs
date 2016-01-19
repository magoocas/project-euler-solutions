/*
    Problem: 9

    Title: Special Pythagorean triplet

    Description:
        
        
        A Pythagorean triplet is a set of three natural numbers, a < b < c, for
        which,
        a^2 + b^2 = c^2
        
        For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
        
        There exists exactly one Pythagorean triplet for which a + b + c =
        1000.
        Find the product abc.

    Url: https://projecteuler.net/problem=9
*/

namespace ProjectEulerSolutions.CSharp.Solutions
{
    public class Solution009 : SolutionBase
    {
        public override object Answer()
        {
            int sum = 1000,
                a = 1,
                b = a,
                c = sum - (a + b);

            while (b < c)
            {
                while (++b < (c = sum - (a + b)))
                {
                    if (a*a + b*b == c*c)
                        return a*b*c;
                }
                b = ++a;
            }

            return -1;
        }
    }
}