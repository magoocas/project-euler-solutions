/*
    Problem: 40

    Title: Champernowne's constant

    Description:
        An irrational decimal fraction is created by concatenating the positive
        integers:
        
        0.12345678910 1112131415161718192021...
        
        It can be seen that the 12^th digit of the fractional part is 1.
        
        If d[n] represents the n^th digit of the fractional part, find the value of the
        following expression.
        
            d[1] x d[10] x d[100] x d[1000] x d[10000] x d[100000] x d[1000000]
        

    Url: https://projecteuler.net/problem=40
*/

namespace csharp.Level02
{
    public class Solution040 : SolutionBase
    {
        public override object Answer()
        {
            var digitBuffer = new int[10];
            var digitBufferIndex = 0;

            var currentNumber = 0;
            var nextDigitIndex = 1;
            var currentDigitIndex = 0;
            var product = 1;

            while (nextDigitIndex <= 1000000)
            {
                digitBufferIndex = 0;
                currentNumber++;
                var number = currentNumber;
                while (number >0)
                {
                    digitBuffer[digitBufferIndex++] = number%10;
                    number /= 10;
                    currentDigitIndex++;
                }
                if (currentDigitIndex >= nextDigitIndex)
                {
                    product *= digitBuffer[currentDigitIndex - nextDigitIndex];
                    nextDigitIndex *= 10;
                }
                
            }
			return product;
        }
    }
}

