/*
    Problem: 64

    Title: Odd period square roots

    Description:
       All square roots are periodic when written as continued fractions and can be written in the form:
       vN = a0 +1
        a1 +1
         a2 +1
          a3 + ...
       For example, let us consider v23:
       v23 = 4 + v23 — 4 = 4 + 1 = 4 + 1
        1
       v23—4 1 + v23 – 3
       7
       If we continue we would get the following expansion:
       v23 = 4 +1
        1 +1
         3 +1
          1 +1
           8 + ...
       The process can be summarised as follows:
       a0 = 4, 1
       v23—4 = v23+4
       7 = 1 + v23—3
       7
       a1 = 1, 7
       v23—3 = 7(v23+3)
       14 = 3 + v23—3
       2
       a2 = 3, 2
       v23—3 = 2(v23+3)
       14 = 1 + v23—4
       7
       a3 = 1, 7
       v23—4 = 7(v23+4)
       7 = 8 + v23—4
       a4 = 8, 1
       v23—4 = v23+4
       7 = 1 + v23—3
       7
       a5 = 1, 7
       v23—3 = 7(v23+3)
       14 = 3 + v23—3
       2
       a6 = 3, 2
       v23—3 = 2(v23+3)
       14 = 1 + v23—4
       7
       a7 = 1, 7
       v23—4 = 7(v23+4)
       7 = 8 + v23—4
       It can be seen that the sequence is repeating. For conciseness, we use the notation v23 = [4;(1,3,1,8)], to indicate that the block (1,3,1,8) repeats indefinitely.
       The first ten continued fraction representations of (irrational) square roots are:
       v2=[1;(2)], period=1
       v3=[1;(1,2)], period=2
       v5=[2;(4)], period=1
       v6=[2;(2,4)], period=2
       v7=[2;(1,1,1,4)], period=4
       v8=[2;(1,4)], period=2
       v10=[3;(6)], period=1
       v11=[3;(3,6)], period=2
       v12= [3;(2,6)], period=2
       v13=[3;(1,1,1,1,6)], period=5
       Exactly four continued fractions, for N = 13, have an odd period.
       How many continued fractions for N = 10000 have an odd period?

*/

namespace csharp.Level03
{
    public class Solution064 : SolutionBase
    {
        public override object Answer()
        {
            int m = 1;
            int result = 0;
            for (int n = 2; n <= 10000; n++)
            {
                while ((m + 1) * (m + 1) < n) m++;
                if (m * m == n) continue;

                int a = m, b=0, d=1,p=0;
                do
                {
                    b = a * d - b;
                    d = (m - b * b) / d;
                    a = (n + b) / d;
                    p++;
                }
                while (d!=1) ;
                if (p % 2 == 1) result++;
            }

			return 0;
        }
    }
}
