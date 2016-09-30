/*
    Problem: 62

    Title: Cubic permutations

    Description:
        The cube, 41063625 (345^3), can be permuted to produce two other cubes:
        56623104 (384^3) and 66430125 (405^3). In fact, 41063625 is the smallest cube
        which has exactly three permutations of its digits which are also cube.
        
        Find the smallest cube for which exactly five permutations of its digits are
        cube.
        

    Url: https://projecteuler.net/problem=62
*/

using System.Collections.Generic;
using csharp.Utility;

namespace csharp.Level03
{
    public class Solution062 : SolutionBase
    {
        public override object Answer()
        {
            var cubes = new Dictionary<ulong, ulong[]>();

            for (ulong n = 1;; n++)
            {
                var cube = n*n*n;
                var digitFrequency = ToolBox.DigitFrequency(cube);
                ulong[] info;
                if (!cubes.TryGetValue(digitFrequency, out info))
                {
                    info = new[] {cube, 0ul};
                    cubes.Add(digitFrequency, new []{cube,0ul});
                }
                info[1]++;
                cubes[digitFrequency] = info;
                if (info[1]== 5)
                    return info[0];
            }
        }
    }
}

