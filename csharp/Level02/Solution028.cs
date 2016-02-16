/*
    Problem: 28

    Title: Number spiral diagonals

    Description:
        Starting with the number 1 and moving to the right in a clockwise direction a 5
        by 5 spiral is formed as follows:
        
            21 22 23 24 25
            20  7  8  9 10
            19  6  1  2 11
            18  5  4  3 12
            17 16 15 14 13
        
        It can be verified that the sum of the numbers on the diagonals is 101.
        
        What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed
        in the same way?
        

    Url: https://projecteuler.net/problem=28
*/

namespace csharp.Level02
{
    public class Solution028 : SolutionBase
    {
        public override object Answer()
        {
            int skip = 2;
            int sum = 0;
            int diag = -1;

            for (int i = 1; i < 1001*1001; i += skip)
            {
                sum += i;
                if (diag++ == 3)
                {
                    skip += 2;
                    diag = 0;
                }
            }
            sum += 1001*1001;
            return sum;
        }
    }
}

