/*
    Problem: 21

    Title: 

    Description:
        Let d(n) be defined as the sum of proper divisors of n (numbers less than n
        which divide evenly into n).
        If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and
        each of a and b are called amicable numbers.
        
        For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55
        and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and
        142; so d(284) = 220.
        
        Evaluate the sum of all the amicable numbers under 10000.
        

    Url: https://projecteuler.net/problem=21
*/
using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEulerSolutions.CSharp.Level01
{
    public class Solution021 : SolutionBase
    {
        int d(int n)
        {
            var divisors = ToolBox.GetDivisors(n, true);
            return (int)divisors.Sum();
        }


        public override object Answer()
        {
//            var numbers = new int[10001];
//            numbers[0] = -1;
//            for (int i = 1; i < numbers.Length; i++)
//            {
//                if (numbers[i] != 0)
//                    continue;
//                
//                var a = i;
//                var b = d(a);
//                var isAmicable = false;
//                if (a != b && d(b) == a)
//                    isAmicable = true;
//
//                numbers[a] = isAmicable ? a : -1;
//                if (b < numbers.Length)
//                    numbers[b] = isAmicable ? b : -1;
//                
//            }
//
//
//            return numbers.Sum(x => x > 0 ? x : 0);

            int sum = 0;

            for(int a=1; a<=10000;a++)
            {
                var b = d(a);
                if (b != a && a == d(b))
                    sum += a;
            }

            return sum;
        }
    }
}

