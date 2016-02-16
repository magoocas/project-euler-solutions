/*
    Problem: 19

    Title: Counting Sundays

    Description:
        You are given the following information, but you may prefer to do some research
        for yourself.
        
            • 1 Jan 1900 was a Monday.
            • Thirty days has September,
            April, June and November.
            All the rest have thirty-one,
            Saving February alone,
            Which has twenty-eight, rain or shine.
            And on leap years, twenty-nine.
            • A leap year occurs on any year evenly divisible by 4, but not on a century
            unless it is divisible by 400.
        
        How many Sundays fell on the first of the month during the twentieth century (1
        Jan 1901 to 31 Dec 2000)?
        

    Url: https://projecteuler.net/problem=19
*/

using System;

namespace csharp.Level01
{
    public class Solution019 : SolutionBase
    {
        public override object Answer()
        {
            var date = DateTime.Parse("01/01/1901");
            var lastDay = DateTime.Parse("12/31/2000");
            var count = 0;
            while (date < lastDay)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday && date.Day == 1)
                {
                    count++;
                }
                date = date.AddDays(1);
            }
            return count;
        }
    }
}