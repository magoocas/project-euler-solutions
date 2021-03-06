/*
    Problem: 42

    Title: Coded triangle numbers

    Description:
        The n^th term of the sequence of triangle numbers is given by, t[n] = 1/2n(n
        +1); so the first ten triangle numbers are:
        
            1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
        
        By converting each letter in a word to a number corresponding to its
        alphabetical position and adding these values we form a word value. For
        example, the word value for SKY is 19 + 11 + 25 = 55 = t[10]. If the word value
        is a triangle number then we shall call the word a triangle word.
        
        Using words.txt (right click and 'Save Link/Target As...'), a 16K text file
        containing nearly two-thousand common English words, how many are triangle
        words?
        

    Url: https://projecteuler.net/problem=42
*/

using System;
using System.Linq;

namespace csharp.Level02
{
    public class Solution042 : SolutionBase
    {
        private bool IsTriangle(int wordValue) => Math.Abs((-1 + Math.Sqrt(1 + 8*wordValue))/2%1) < double.Epsilon;
        private int WordValue(string word) => word.ToUpper().ToCharArray().Sum(c => c - 64);


        public override object Answer()
        {
            var words = GetProblemDataAsArray(",", s => s.Trim('"'));
            return words.Select(WordValue).Where(IsTriangle).Count();
        }
        
    }
}

