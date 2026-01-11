namespace CSharpAlgorithms
{
    public class Matrices
    {
        /// <summary>
        /// Write a function to traverse an m x n matrix in spiral order and return all elements in a single list. 
        /// The traversal should start from the top left corner and proceed clockwise, spiraling inward until every element has been visited.
        /// </summary>
        /// <param name="matrix">m x n matrix</param>
        /// <returns><see cref="IList{T}"></returns>
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            int top = 0, left = 0;
            int right = matrix[0].Length - 1;
            int bottom = matrix.Length - 1;
            List<int> result = [];

            while (left <= right && top <= bottom)
            {
                for (int col = left; col <= right; col++)
                {
                    result.Add(matrix[top][col]);
                }
                top++;

                for (int row = top; row <= bottom; row++)
                {
                    result.Add(matrix[row][right]);
                }
                right--;

                if (top <= bottom)
                {
                    for (int col = right; col >= left; col--)
                    {
                        result.Add(matrix[bottom][col]);
                    }
                    bottom--;
                }

                if (left <= right)
                {
                    for (int row = bottom; row >= top; row--)
                    {
                        result.Add(matrix[row][left]);
                    }
                    left++;
                }
            }
            return result;
        }
    }
}
