using System.Linq;

namespace csharp.Utility
{
    public struct Rational
    {
        public long Numerator { get; }
        public long Denominator { get; }
        public Rational(long numerator, long denominator)
        {
            if (numerator > 1)
            {
                var numeratorFactors = ToolBox.GetDivisors((ulong) numerator);
                var denominatorFactors = ToolBox.GetDivisors((ulong) denominator);

                var greatestCommonDivisor = (long) numeratorFactors
                    .Join(denominatorFactors, n => n, d => d, (n, d) => n).Max();

                numerator /= greatestCommonDivisor;
                denominator /= greatestCommonDivisor;
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        public static Rational Multiply(Rational a, Rational b)
        {
            return new Rational(a.Numerator*b.Numerator, a.Denominator*b.Denominator);
        }

        public static bool Equals(Rational a, Rational b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return Multiply(a, b);
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return !Equals(a, b);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}