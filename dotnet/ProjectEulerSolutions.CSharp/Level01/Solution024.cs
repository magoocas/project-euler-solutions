/*
    Problem: 24

    Title: 

    Description:
        A permutation is an ordered arrangement of objects. For example, 3124 is one
        possible permutation of the digits 1, 2, 3 and 4. If all of the permutations
        are listed numerically or alphabetically, we call it lexicographic order. The
        lexicographic permutations of 0, 1 and 2 are:
        
            012   021   102   120   201   210
        
        What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5,
        6, 7, 8 and 9?

    Url: https://projecteuler.net/problem=24
*/
using System.Collections.Generic;
using System;

namespace ProjectEulerSolutions.CSharp.Level01
{
    public class Solution024 : SolutionBase
    {
        public bool Permute(List<int> digits, ref int counter, Func<string,bool> permutationCallback, string number="")
        {
            
            if (digits.Count == 0)
            {
                counter++;
                return permutationCallback(number);
            }

            for (int i = 0; i < digits.Count; i++)
            {
                var digit = digits[i];
                digits.RemoveAt(i);
                if (Permute(digits, ref counter, permutationCallback, number + digit))
                    return true;
                digits.Insert(i, digit);

            }
            return false;
        }

        public override object Answer()
        {
            var digits = new List<int>{0,1,2,3,4,5,6,7,8,9};
            int counter = 0;
            string number = "";

            Permute(digits, ref counter, num=>{
                if(counter == 1000000)
                {
                    number = num;
                    return true;
                }
                return false;

            });

			return number;
        }
    }
}

