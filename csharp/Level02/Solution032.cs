/*
    Problem: 32

    Title: Pandigital products

    Description:
        We shall say that an n-digit number is pandigital if it makes use of all the
        digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1
        through 5 pandigital.
        
        The product 7254 is unusual, as the identity, 39 x 186 = 7254, containing
        multiplicand, multiplier, and product is 1 through 9 pandigital.
        
        Find the sum of all products whose multiplicand/multiplier/product identity can
        be written as a 1 through 9 pandigital.
        
        HINT: Some products can be obtained in more than one way so be sure to only
        include it once in your sum.

    Url: https://projecteuler.net/problem=32
*/

using System.Collections.Generic;
using System.Linq;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution032 : SolutionBase
    {

        public IEnumerable<int> GetPandigitalProducts(List<int> digits, int firstNumSize, int secondNumSize)
        {
            foreach (var num1 in Pandigital.Pick(digits, firstNumSize))
            {
                foreach (var num2 in Pandigital.Pick(digits, secondNumSize))
                {
                    var product = num1 * num2;
                    if (Pandigital.IsPandigital(product, digits))
                        yield return product;
                }

            }
        } 

        public override object Answer()
        {
            var digits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var pandigitalProducts = new HashSet<int>();

            GetPandigitalProducts(digits, 1, 4).ToList().ForEach(x => pandigitalProducts.Add(x));
            GetPandigitalProducts(digits, 2, 3).ToList().ForEach(x => pandigitalProducts.Add(x));
            
            return pandigitalProducts.Sum();
        }
    }
}

