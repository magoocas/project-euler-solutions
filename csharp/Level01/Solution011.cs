/*
    Problem: 11

    Title: Largest product in a grid

    Description:
        
        In the 20×20 grid below, four numbers along a diagonal line have been marked in red.

            {Problem011.txt}

        The product of these numbers is 26 × 63 × 78 × 14 = 1788696.

        What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?

    Url: https://projecteuler.net/problem=11
*/

namespace csharp.Level01
{
    public class Solution011 : SolutionBase
    {
        public override object Answer()
        {
            var matrix = GetProblemDataAsMatrix("\r\n", " ", int.Parse);
            var productCount = 4;
            var maxProduct = 0;

            var rows = matrix.Length;
            var columns = matrix[0].Length;

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    var currentProduct = matrix[row][column];
                    if (column + productCount <= columns)
                        for (var k = 1; k < productCount; k++)
                            currentProduct *= matrix[row][column + k];
                    maxProduct = currentProduct > maxProduct ? currentProduct : maxProduct;

                    currentProduct = matrix[row][column];
                    if (row + productCount <= rows)
                        for (var k = 1; k < productCount; k++)
                            currentProduct *= matrix[row + k][column];
                    maxProduct = currentProduct > maxProduct ? currentProduct : maxProduct;

                    currentProduct = matrix[row][column];
                    if (column + productCount <= columns && row + productCount <= rows)
                        for (var k = 1; k < productCount; k++)
                            currentProduct *= matrix[row + k][column + k];
                    maxProduct = currentProduct > maxProduct ? currentProduct : maxProduct;

                    currentProduct = matrix[row][column];
                    if (column - productCount >= 0 && row + productCount <= rows)
                        for (var k = 1; k < productCount; k++)
                            currentProduct *= matrix[row + k][column - k];
                    maxProduct = currentProduct > maxProduct ? currentProduct : maxProduct;
                }
            }

            return maxProduct;
        }
    }
}