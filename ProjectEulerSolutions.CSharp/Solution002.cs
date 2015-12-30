/*
    Problem: 2

    Title: Even Fibonacci numbers

    Description:
        Each new term in the Fibonacci sequence is generated by adding the
        previous two terms. By starting with 1 and 2, the first 10 terms will
        be:
        1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        By considering the terms in the Fibonacci sequence whose values do not
        exceed four million, find the sum of the even-valued terms.

    Url: https://projecteuler.net/problem=2
*/

namespace ProjectEulerSolutions.CSharp
{
    public class Solution002
    {
        public static object Answer()
        {
                int a = 1;
                int b = 2;
                int sum = 0;
                int evenTotal = 0;

                while (b < 4000000)
                {
                    if (b%2 == 0)
                    {
                        evenTotal += b;
                    }
                    sum = a + b;
                    a = b;
                    b = sum;
                }

                return evenTotal;
        }

        
    }
}

