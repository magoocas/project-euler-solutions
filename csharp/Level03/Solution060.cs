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
    
    References:
        https://projecteuler.net/thread=60;post=3006
*/

using System;
using System.Collections.Generic;
using System.Linq;
using csharp.Utility;

namespace csharp.Level03
{
    public class Solution060 : SolutionBase
    {
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
            ulong max = 10000; 
            int size = 5;
            var primes = ToolBox.PrimeSieve.PrimeRange(2, max).ToArray();
            var lookup = new Dictionary<ulong,HashSet<ulong>>();

            for (int i = 0; i < primes.Length; i++)
            {
                for (int j = i + 1; j < primes.Length; j++)
                {
                    var p1 = primes[i];
                    var p2 = primes[j];

                    var n1 = ToolBox.Concatenate(p1, p2);
                    if (!ToolBox.PrimeSieve.IsPrime(n1))
                        continue;

                    var n2 = ToolBox.Concatenate(p2, p1);
                    if (!ToolBox.PrimeSieve.IsPrime(n2))
                        continue;

                    lookup.GetValueOrNew(p1, () => new HashSet<ulong> {p1}).Add(p2);
                    lookup.GetValueOrNew(p2, () => new HashSet<ulong> {p2}).Add(p1);

                }
            }

            var sets = lookup.Values.OrderByDescending(s => s.Count).ToList();

            for (int i = 0; i < sets.Count; i++)
            {
                var intersected = new HashSet<ulong> { sets[i].First() };
                if (Find(lookup, sets[i], intersected, size))
                {
                    Console.WriteLine($"Set:{intersected.Aggregate("", (a, b) => $"{a} [{b}]")}");
                    return intersected.Aggregate(0ul, (a, b) => a + b);
                }
            }

            return 0;
        }
    }
}

