/*
    Problem: 51

    Title: Prime digit replacements

    Description:
        By replacing the 1^st digit of the 2-digit number *3, it turns out that six of
        the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.
        
        By replacing the 3^rd and 4^th digits of 56**3 with the same digit, this
        5-digit number is the first example having seven primes among the ten generated
        numbers, yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and
        56993. Consequently 56003, being the first member of this family, is the
        smallest prime with this property.
        
        Find the smallest prime which, by replacing part of the number (not necessarily
        adjacent digits) with the same digit, is part of an eight prime value family.
        

    Url: https://projecteuler.net/problem=51
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level03
{
    public class Solution051 : SolutionBase
    {
        public override object Answer()
        {

            foreach (var prime in ToolBox.PrimeSieve.AllPrimes(56003))
            {
                var primeDigits = ToolBox.NumberToDigits(prime).ToArray();
                var newNumberDigits = new ulong[primeDigits.Length];
                for (ulong digitMask = 1; digitMask < (1ul << primeDigits.Length) - 1; digitMask++)
                {
                    var familySize = 0;
                    ulong smallest = 0;
                    for (ulong digit = 0; digit <= 9; digit++)
                    {
                        for (int i = 0; i < primeDigits.Length; i++)
                            newNumberDigits[i] = (digitMask & 1ul << i) > 0 ? digit : primeDigits[i];

                        if(newNumberDigits.Last() == 0)
                            continue;

                        var newNumber = ToolBox.DigitsToNumber(newNumberDigits);
                        if (ToolBox.PrimeSieve[newNumber])
                        {
                            if (smallest == 0)
                                smallest = newNumber;
                            if (++familySize == 8)
                                return smallest;
                        }
                    }
                }
            }

			return 0;
        }
        
    }
}

