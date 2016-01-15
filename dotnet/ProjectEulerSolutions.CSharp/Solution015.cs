/*
    Problem: 15

    Title: Lattice paths

    Description:
        Starting in the top left corner of a 2x2 grid, and only being able to move to
        the right and down, there are exactly 6 routes to the bottom right corner.
        
            [p015]
        
        How many such routes are there through a 20x20 grid?
        

    Url: https://projecteuler.net/problem=15
*/

namespace ProjectEulerSolutions.CSharp
{
    public static class Solution015
    {
        public static object Answer()
        {
            var size = 20;
            var paths = new long[size + 1];
            paths[0] = 1;
            for (var i = 0; i <= size; i++)
                for (var j = 0; j < size; j++)
                    paths[j + 1] += paths[j];

            return paths[size];
        }
    }
}