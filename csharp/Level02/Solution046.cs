/*
    Problem: 46

    Title: Goldbach's other conjecture

    Description:
        It was proposed by Christian Goldbach that every odd composite number can be
        written as the sum of a prime and twice a square.
        
            9 = 7 + 2x1^2
            15 = 7 + 2x2^2
            21 = 3 + 2x3^2
            25 = 7 + 2x3^2
            27 = 19 + 2x2^2
            33 = 31 + 2x1^2
        
        It turns out that the conjecture was false.
        
        What is the smallest odd composite that cannot be written as the sum of a prime
        and twice a square?
        

    Url: https://projecteuler.net/problem=46
*/

using csharp.Utility;

namespace csharp.Level02
{
    public class Solution046 : SolutionBase
    {
        public override object Answer()
        {
            for (ulong i = 1; i < 2000000; i+=2)
            {
                if (!ToolBox.PrimeSieve[i])
                {
                    foreach (var prime in ToolBox.PrimeSieve.AllPrimes())
                    {
                        if(prime > i)
                            return i;
                        ulong j;
                        for (j = 1; i > prime + 2*j*j; j++) ;
                        if(i == prime + 2*j*j)
                            break;
                    }
                }
            }
            return 0;
        }
    }
}

