/*
    Problem: 30

    Title: 

    Description:
        Surprisingly there are only three numbers that can be written as the sum of
        fourth powers of their digits:
        
            1634 = 1^4 + 6^4 + 3^4 + 4^4
            8208 = 8^4 + 2^4 + 0^4 + 8^4
            9474 = 9^4 + 4^4 + 7^4 + 4^4
        
        As 1 = 1^4 is not a sum it is not included.
        
        The sum of these numbers is 1634 + 8208 + 9474 = 19316.
        
        Find the sum of all the numbers that can be written as the sum of fifth powers
        of their digits.
        

    Url: https://projecteuler.net/problem=30
*/

namespace csharp.Level02
{
    public class Solution030 : SolutionBase
    {
        public override object Answer()
        {
            int sum = 0;
            for(int i = 2; i<= 354295;i++)
            { 
                int n = i;
                int digitSum = 0;
                while (n>0)
                {
                    int d = n%10;
                    n /= 10;
                    digitSum += d*d*d*d*d;
                }
                if (i == digitSum)
                    sum += i;
            }
			return sum;
        }
    }
}

