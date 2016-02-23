/*
    Problem: 38

    Title: Pandigital multiples

    Description:
        Take the number 192 and multiply it by each of 1, 2, and 3:
        
            192 x 1 = 192
            192 x 2 = 384
            192 x 3 = 576
        
        By concatenating each product we get the 1 to 9 pandigital, 192384576. We will
        call 192384576 the concatenated product of 192 and (1,2,3)
        
        The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and
        5, giving the pandigital, 918273645, which is the concatenated product of 9 and
        (1,2,3,4,5).
        
        What is the largest 1 to 9 pandigital 9-digit number that can be formed as the
        concatenated product of an integer with (1,2, ... , n) where n > 1?
        

    Url: https://projecteuler.net/problem=38
*/
using System.Globalization;

namespace csharp.Level02
{
    public class Solution038 : SolutionBase
    {
        int Concatenate(int high, int low)
        {
            int place = 1;
            while(place < low)
            {
                place *= 10;
                high *= 10;
            }
            return high + low;
        }

        bool IsPandigital(int number)
        {
            if (number < 123456789)
                return false;
            
            var digits = new bool[9];
            var count = 0;

            while(number>0)
            {
                var digit = number % 10;
                if (digit < 1 || digits[digit-1])
                    return false;
                digits[digit-1] = true;
                number /= 10;
                count++;
            }
            if (count < 9)
                return false;
            return true;
        }

        public int GetConcatenatedProduct(int number, int n)
        {
            int product = number;
            for (int i = 2; i <= n; i++)
                product = Concatenate(product, n * number);
            return product;
        }

        public override object Answer()
        {
            int max = 0;
            for (int n = 2; n <= 9; n++)
            {
                var number = 1;
                var product = GetConcatenatedProduct(number, n);
                while(product<987654321)
                {
                    number++;
                    product = GetConcatenatedProduct(number, n);
                    if (product > max && IsPandigital(product))
                        max = product;
                }
            }
			return max;
        }
    }
}

