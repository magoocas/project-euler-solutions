/*
    Problem: 18

    Title: 

    Description:
        By starting at the top of the triangle below and moving to adjacent numbers on
        the row below, the maximum total from top to bottom is 23.
        
            3
            7 4
            2 4 6
            8 5  9 3
        
        That is, 3 + 7 + 4 + 9 = 23.
        
        Find the maximum total from top to bottom of the triangle below:
            {Problem018.txt}
        
        NOTE: As there are only 16384 routes, it is possible to solve this problem by
        trying every route. However, Problem 67, is the same challenge with a triangle
        containing one-hundred rows; it cannot be solved by brute force, and requires a
        clever method! ;o)
        

    Url: https://projecteuler.net/problem=18
*/

using System;

namespace ProjectEulerSolutions.CSharp.Level01
{
    public class Solution018 : SolutionBase
    {

        public override object Answer()
        {
            var triangle = GetProblemDataAsMatrix("\r\n", " ", int.Parse);

            for (int i = triangle.Length - 2; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    var left = triangle[i + 1][j];
                    var right = triangle[i + 1][j + 1];
                    triangle[i][j] += left > right ? left : right;
                }
            }

            return triangle[0][0];
        }
    }
}

