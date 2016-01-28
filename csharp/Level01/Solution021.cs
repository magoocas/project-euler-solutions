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

using System.Collections.Generic;
using System.Linq;

namespace csharp.Level01
{
    public class Solution021 : SolutionBase
    {
        private int d(int n)
        {
            var divisors = GetDivisors(n, true);
            return (int) divisors.Sum();
        }

        public static IEnumerable<long> GetDivisors(long number, bool proper = false)
        {
            var primeList = new List<long>();
            var countList = new List<long>();
            var indexList = new List<int>();

            foreach (var f in ToolBox.GetPrimeFactors(number).GroupBy(x => x))
            {
                primeList.Add(f.Key);
                countList.Add(f.Count());
                indexList.Add(0);
            }
            if (primeList.Count == 0)
            {
                yield return 1;
                if (number > 1 && !proper)
                    yield return number;
                yield break;
            }
            var i = 0;
            while (i < primeList.Count)
            {
                long divisor = 1;
                for (i = 0; i < primeList.Count; i++)
                {
                    for (var j = 0; j < indexList[i]; j++)
                    {
                        divisor *= primeList[i];
                    }
                }


                for (i = 0; i < primeList.Count; i++)
                {
                    indexList[i]++;
                    if (indexList[i] > countList[i])
                        indexList[i] = 0;
                    else
                        break;
                }
                if (proper && i >= primeList.Count)
                    yield break;
                yield return divisor;
            }
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

            var sum = 0;

            for (var a = 1; a <= 10000; a++)
            {
                var b = d(a);
                if (b != a && a == d(b))
                    sum += a;
            }

            return sum;
        }
    }
}