/*
    Problem: 31

    Title: 

    Description:
        In England the currency is made up of pound, -L-, and pence, p, and there are
        eight coins in general circulation:
        
            1p, 2p, 5p, 10p, 20p, 50p, -L-1 (100p) and -L-2 (200p).
        
        It is possible to make -L-2 in the following way:
        
            1x-L-1 + 1x50p + 2x20p + 1x5p + 1x2p + 3x1p
        
        How many different ways can -L-2 be made using any number of coins?
        

    Url: https://projecteuler.net/problem=31
*/

namespace csharp.Level02
{

    public class Solution031 : SolutionBase
    {
        public override object Answer()
        {
            int count = 0;
            int desiredSum = 200;

            int[] coinValues = {200, 100, 50, 20, 10, 5, 2};
            int[] coinCounts = new int[coinValues.Length];

            int i = 0;
            while (i>=0)
            {

                while (++i < coinCounts.Length)
                    coinCounts[i] = coinCounts[i - 1];

                i--;

                while (coinCounts[i]<=desiredSum)
                {
                    count++;
                    coinCounts[i] += coinValues[i];
                }

                while (coinCounts[i]>desiredSum)
                {
                    i--;
                    if(i<0)
                        return count;
                }
                coinCounts[i] += coinValues[i];

            }
            return -1;
        }
    }
}

