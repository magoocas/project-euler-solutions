/*
    Problem: 7

    Title: 10001st prime

    Description:
        
        
        By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can
        see that the 6th prime is 13.
        
        What is the 10 001st prime number?

    Url: https://projecteuler.net/problem=7
*/

namespace ProjectEulerSolutions.CSharp.Level01
{
    public class Solution007 : SolutionBase
    {
        public override object Answer()
        {
            return ToolBox.GetNthPrime(10001, 200000);
        }
    }
}