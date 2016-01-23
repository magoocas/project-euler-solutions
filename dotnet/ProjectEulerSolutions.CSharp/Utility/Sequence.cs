using System;
using System.Collections.Generic;

namespace ProjectEulerSolutions.CSharp.Utility
{
    public static class Sequence
    {
        public static IEnumerable<T> Unfold<T>(T seed, Func<T, T> enumerator)
        {
            return Unfold(seed, enumerator, x => x);
        }

        public static IEnumerable<TResult> Unfold<T, TResult>(T seed, Func<T, T> enumerator, Func<T, TResult> selector)
        {
            var next = seed;

            while (true)
            {
                var res = enumerator(next);
                if (res == null)
                    yield break;

                yield return selector(res);

                next = res;
            }
        }
        
        public static IEnumerable<long> Fibbinoci()
        {
            return Unfold(Tuple.Create(0L, 1L), x => Tuple.Create(x.Item2, x.Item1 + x.Item2), x => x.Item1);
        }
    }
}
