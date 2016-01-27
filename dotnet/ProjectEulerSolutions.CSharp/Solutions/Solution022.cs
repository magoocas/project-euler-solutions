/*
    Problem: 22

    Title: 

    Description:
        Using names.txt (right click and 'Save Link/Target As...'), a 46K text file
        containing over five-thousand first names, begin by sorting it into
        alphabetical order. Then working out the alphabetical value for each name,
        multiply this value by its alphabetical position in the list to obtain a name
        score.
        
        For example, when the list is sorted into alphabetical order, COLIN, which is
        worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would
        obtain a score of 938 x 53 = 49714.
        
        What is the total of all the name scores in the file?
        

    Url: https://projecteuler.net/problem=22
*/
using System;
using System.Linq;

namespace ProjectEulerSolutions.CSharp.Solutions
{
    public class Solution022 : SolutionBase
    {
        public override object Answer()
        {
            var names = ProblemData
                .Split(new[]{"\"",","}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            names.Sort();
            
            int sum = 0;
            for (int i = 0; i < names.Count; i++)
                sum += (i + 1) * names[i].Aggregate(0, (acc, c) => acc + c - 64);
            
			return sum;
        }
    }
}

