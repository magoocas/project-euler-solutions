/*
    Problem: 36

    Title: 

    Description:
        The decimal number, 585 = 1001001001[2] (binary), is palindromic in both bases.
        
        Find the sum of all numbers, less than one million, which are palindromic in
        base 10 and base 2.
        
        (Please note that the palindromic number, in either base, may not include
        leading zeros.)
        

    Url: https://projecteuler.net/problem=36
*/

using csharp.Utility;

namespace csharp.Level02
{
    public class Solution036 : SolutionBase
    {
        public override object Answer()
        {
            int sum = 0;
            for (int i = 1; i < 1000000; i++)
            {
                if(i%10 == 0)
                    continue;
                if (ToolBox.IsPalindrome(i, 10) && ToolBox.IsPalindrome(i, 2))
                    sum += i;
            }
			return sum;
        }
    }
}

