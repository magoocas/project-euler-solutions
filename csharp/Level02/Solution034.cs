/*
    Problem: 34

    Title: 

    Description:
        145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
        
        Find the sum of all numbers which are equal to the sum of the factorial of
        their digits.
        
        Note: as 1! = 1 and 2! = 2 are not sums they are not included.
        

    Url: https://projecteuler.net/problem=34
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution034 : SolutionBase
    {

        public override object Answer()
        {
            int sum = 0;
            var max = ToolBox.Factorial(9)*9;
            for (int i = 10; i <= max; i++)
            {
                if (i == ToolBox.NumberToDigits(i).Select(ToolBox.Factorial).Sum())
                    sum += i;
            }
			return sum;
        }
    }
}

