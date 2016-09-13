using System;
using System.Numerics;

namespace csharp.Utility
{
    public static class Combinatorics
    {
        public static BigInteger Select(BigInteger r, BigInteger n)
        {
            if(r>n)
                throw new ArgumentOutOfRangeException(nameof(r), r, $"Greater than parameter {nameof(n)}({n})");
            return ToolBox.Factorial(n)/(ToolBox.Factorial(r)*ToolBox.Factorial(n - r));
        }
    }
}
