/*
    Problem: 17

    Title: Number letter counts

    Description:
        If the numbers 1 to 5 are written out in words: one, two, three, four, five,
        then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        
        If all the numbers from 1 to 1000 (one thousand) inclusive were written out in
        words, how many letters would be used?
        
        
        NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and
        forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20
        letters. The use of "and" when writing out numbers is in compliance with
        British usage.
        

    Url: https://projecteuler.net/problem=17
*/

using System.Linq;

namespace csharp.Level01
{
    public class Solution017 : SolutionBase
    {
        public override object Answer()
        {
            var ones = new[]
            {
                "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
                "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
                "nineteen"
            }.Select(x => x.Length).ToArray();

            var tens = new[]
            {
                "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            }
                .Select(x => x.Length).ToArray();

            var hundred = "hundred".Length;
            var thousand = "thousand".Length;
            var and = "and".Length;

            var letters = 0;
            for (var i = 1; i <= 1000; i++)
            {
                var number = i;

                var numThousands = number/1000;
                if (numThousands > 0)
                {
                    letters += ones[numThousands] + thousand;
                    number %= 1000;
                }

                var numHundreds = number/100;
                if (numHundreds > 0)
                {
                    letters += ones[numHundreds] + hundred;
                    number %= 100;
                }

                if (number > 0 && (numThousands > 0 || numHundreds > 0))
                    letters += and;

                if (number < 20)
                {
                    letters += ones[number];
                }
                else
                {
                    var numTens = number/10;
                    if (numTens > 0)
                    {
                        letters += tens[numTens];
                        number %= 10;
                    }

                    if (number > 0)
                        letters += ones[number];
                }
            }

            return letters;
        }
    }
}