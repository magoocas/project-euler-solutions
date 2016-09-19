/*
    Problem: 60

    Title: Prime pair sets

    Description:
        The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes
        and concatenating them in any order the result will always be prime. For
        example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four
        primes, 792, represents the lowest sum for a set of four primes with this
        property.
        
        Find the lowest sum for a set of five primes for which any two primes
        concatenate to produce another prime.
        

    Url: https://projecteuler.net/problem=60
*/

using System;
using System.Collections.Generic;
using System.Linq;
using csharp.Utility;

namespace csharp.Level03
{
    public class Solution060 : SolutionBase
    {

        private IEnumerable<Tuple<ulong,ulong,ulong>> GetSubPrimes(ulong prime, ulong min)
        {
            var digits = ToolBox.NumberToDigits(prime).ToArray();
            for (int i = 1; i < digits.Length; i++)
            {
                if(digits[i-1]==0)
                    continue;
                var n1 = ToolBox.DigitsToNumber(digits, 0, i);
                var n2 = ToolBox.DigitsToNumber(digits, i, digits.Length - i);
                if (n1 == n2 || n1 < min || n2 < min)
                    continue;
                if (ToolBox.PrimeSieve.IsPrime(n1) && ToolBox.PrimeSieve.IsPrime(n2))
                {
                    var otherPrime = ToolBox.Concatenate(n1,n2);
                    if(ToolBox.PrimeSieve.IsPrime(otherPrime))
                        yield return Tuple.Create(n1, n2,otherPrime);
                }
            }
        }

        public bool Find(Dictionary<ulong,HashSet<ulong>> lookup, HashSet<ulong> set, HashSet<ulong> intersected, int size, int depth=1)
        {
            if (depth == size)
                return true;
            foreach (var n in set.Skip(depth))
            {
                if (intersected.Contains(n))
                    continue;
                var subSet = new HashSet<ulong>(set);
                var otherSet = lookup[n];
                if(!subSet.Contains(otherSet.First()))
                    continue;
                subSet.IntersectWith(lookup[n]);
                if(subSet.Count < size)
                    continue;
                intersected.Add(n);
                if (Find(lookup, subSet, intersected, size, depth+1))
                    return true;
                intersected.Remove(n);
            }
            return false;
        }

        public override object Answer()
        {
            
            ulong max = 100000000;
            var lookup = new Dictionary<ulong,HashSet<ulong>>();
            var tracker = new HashSet<ulong>();
            foreach (var prime in ToolBox.PrimeSieve.PrimeRange(13, max))
            {
                if(tracker.Contains(prime))
                    continue;
                foreach (var subPrimePair in GetSubPrimes(prime, 13)) //setting min to 13 is a hack (only works because I already discovered 13 was the first number in the set), to test faster (~10s vs. ~2min)
                {
                    HashSet<ulong> hashSet;
                    if (!lookup.TryGetValue(subPrimePair.Item1, out hashSet))
                        lookup[subPrimePair.Item1] = hashSet = new HashSet<ulong> {subPrimePair.Item1};
                    hashSet.Add(subPrimePair.Item2);

                    if (!lookup.TryGetValue(subPrimePair.Item2, out hashSet))
                        lookup[subPrimePair.Item2] = hashSet = new HashSet<ulong> {subPrimePair.Item2};
                    hashSet.Add(subPrimePair.Item1);
                    
                    tracker.Add(subPrimePair.Item3);
                }
            }
            var sets = lookup.Values.OrderByDescending(s => s.Count).ToList();
            
            for (int i = 0; i < sets.Count; i++)
            {
                var intersected = new HashSet<ulong> {sets[i].First()};
                if (Find(lookup, sets[i], intersected, 5))
                {
                    Console.WriteLine($"Set: {intersected.Aggregate("",(a,b)=>$"{a},{b}")}");
                    return intersected.Aggregate(0ul, (a, b) => a + b);
                }
            }
            return 0;
        }
    }
}

