/*
    Problem: 26

    Title: 

    Description:
        A unit fraction contains 1 in the numerator. The decimal representation of the
        unit fractions with denominators 2 to 10 are given:
        
            ^1/[2]  =  0.5
            ^1/[3]  =  0.(3)
            ^1/[4]  =  0.25
            ^1/[5]  =  0.2
            ^1/[6]  =  0.1(6)
            ^1/[7]  =  0.(142857)
            ^1/[8]  =  0.125
            ^1/[9]  =  0.(1)
            ^1/[10] =  0.1
        
        Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be
        seen that ^1/[7] has a 6-digit recurring cycle.
        
        Find the value of d < 1000 for which ^1/[d] contains the longest recurring
        cycle in its decimal fraction part.
        

    Url: https://projecteuler.net/problem=26
*/
using System.Collections.Generic;

namespace csharp.Level02
{
    public class Solution026 : SolutionBase
    {
        
        public override object Answer()
        {
            var maxRecurranceCount = 0;
            var maxDenominator = 0;

            for (int denominator = 2; denominator < 1000; denominator++)
            {
                var numerator = 1;
                var operationList = new List<string>();
                while (true)
                {
                    var quotient = numerator / denominator;
                    var remainder = numerator % denominator;
                    string operation = $"{quotient}/{remainder}";

                    if (operationList.Contains(operation))
                    {
                        var recurranceCount = operationList.Count - operationList.IndexOf(operation);
                        if (recurranceCount > maxRecurranceCount)
                        {
                            maxRecurranceCount = recurranceCount;
                            maxDenominator = denominator;
                        }
                        break;
                    }
                    operationList.Add(operation);

                    if (remainder == 0)
                        break;
                    
                    numerator = remainder * 10;
                }

            }
            return maxDenominator;
        }
    }
}

