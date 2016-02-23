using System;
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

        public static Rational Add(Rational a, Rational b)
        {
            var commonDenominator = a.Denominator*b.Denominator;
            return new Rational(a.Numerator*b.Denominator + b.Numerator*a.Denominator, a.Denominator*b.Denominator);
        }

        public static Rational Subtract(Rational a, Rational b)
        {
            var commonDenominator = a.Denominator * b.Denominator;
            return new Rational(a.Numerator*b.Denominator - b.Numerator*a.Denominator, a.Denominator*b.Denominator);
        }

        public static Rational Multiply(Rational a, Rational b)
        {
            return new Rational(a.Numerator*b.Numerator, a.Denominator*b.Denominator);
        }

        public static Rational Divide(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool Equals(Rational a, Rational b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }
        public static Rational operator +(Rational a, Rational b)
        {
            return Add(a, b);
        }
        public static Rational operator -(Rational a, Rational b)
        {
            return Subtract(a, b);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return Multiply(a, b);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            return Divide(a, b);
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