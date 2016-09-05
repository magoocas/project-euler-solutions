/*
    Problem: 52

    Title: Permuted multiples

    Description:
        It can be seen that the number, 125874, and its double, 251748, contain exactly
        the same digits, but in a different order.
        
        Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x,
        contain the same digits.
        

    Url: https://projecteuler.net/problem=52
*/

using System.Linq;
using csharp.Utility;
namespace csharp.Level03
{
    public class Solution052 : SolutionBase
    {
        public override object Answer()
        {
            
			return Enumerable.Range(125874, 1000000).First(n =>
			{
			    var number = (ulong)n;
			    var baseFrequency = ToolBox.DigitFrequency(number);
			    for (ulong i = 6; i >= 2; i--)
			    {
			        var multipleFrequency = ToolBox.DigitFrequency(number*i);

                    if (baseFrequency != multipleFrequency)
			            return false;
			    }
			    return true;
			});
        }
    }
}

