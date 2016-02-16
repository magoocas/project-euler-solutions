/*
    Problem: 33

    Title: Digit cancelling fractions

    Description:
        The fraction ^49/[98] is a curious fraction, as an inexperienced mathematician
        in attempting to simplify it may incorrectly believe that ^49/[98] = ^4/[8],
        which is correct, is obtained by cancelling the 9s.
        
        We shall consider fractions like, ^30/[50] = ^3/[5], to be trivial examples.
        
        There are exactly four non-trivial examples of this type of fraction, less than
        one in value, and containing two digits in the numerator and denominator.
        
        If the product of these four fractions is given in its lowest common terms,
        find the value of the denominator.
        

    Url: https://projecteuler.net/problem=33
*/

using csharp.Utility;

namespace csharp.Level02
{
    public class Solution033 : SolutionBase
    {
        public bool IsCurious(int n, int d, int c)
        {
            var canceledFraction = new Rational(n, d);

            if (canceledFraction == new Rational(n + c*10, d + c*10))
                return true;
            if (canceledFraction == new Rational(n*10 + c, d + c*10))
                return true;
            if (canceledFraction == new Rational(n + c*10, d*10 + c))
                return true;
            if (canceledFraction == new Rational(n*10 + c, d*10 + c))
                return true;
            return false;
        }

        public override object Answer()
        {
            var product = new Rational(1,1);
            for (int c = 1; c <= 9; c++)
            {
                for (int n = 1; n <= 9; n++)
                {
                    for (int d = n+1; d <= 9; d++)
                    {
                        if (IsCurious(n, d, c))
                            product *= new Rational(n, d);
                    }
                }
                
            }
			return product.Denominator;
        }
    }
}

