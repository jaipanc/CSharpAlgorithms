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

        /// <summary>
        /// Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.
        /// This transformation should be done in place, without using any additional data structures for storage.
        /// </summary>
        /// <remarks>
        /// Key trick: Use first row + first column as “marker storage”
        /// Instead of extra memory arrays rows[] and cols[], we store markers inside:
        /// matrix[r][0] → marks row r
        /// matrix[0][c] → marks column c
        /// But we must be careful: the first row and first column themselves can originally contain zeros, so we store two booleans:
        /// firstRowZero
        /// firstColZero
        /// </remarks>
        /// <param name="matrix"></param>
        /// <returns>matrix with zeros set.</returns>
        public static int[][] SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            // Step 0: check if first row/col contain zero
            bool firstRowZero = false;
            for (int c = 0; c < n; c++)
                if (matrix[0][c] == 0) { firstRowZero = true; break; }

            bool firstColZero = false;
            for (int r = 0; r < m; r++)
                if (matrix[r][0] == 0) { firstColZero = true; break; }

            // Step 1: mark rows and cols using first row/col
            for (int r = 1; r < m; r++)
            {
                for (int c = 1; c < n; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        matrix[r][0] = 0;
                        matrix[0][c] = 0;
                    }
                }
            }

            // Step 2: zero inner cells based on markers
            for (int r = 1; r < m; r++)
            {
                for (int c = 1; c < n; c++)
                {
                    if (matrix[r][0] == 0 || matrix[0][c] == 0)
                        matrix[r][c] = 0;
                }
            }

            // Step 3: zero first row/col if needed
            if (firstRowZero)
                for (int c = 0; c < n; c++)
                    matrix[0][c] = 0;

            if (firstColZero)
                for (int r = 0; r < m; r++)
                    matrix[r][0] = 0;

            return matrix;
        }
        /// <summary>
        /// Write a function to rotate an n x n 2D matrix representing an image by 90 degrees clockwise. 
        /// The rotation must be done in-place, meaning you should modify the input matrix directly without using an additional matrix for the operation.
        /// </summary>
        /// <param name="matrix">2D array</param>
        public static void RotateImage(int[][] matrix)
        {
            int l = matrix.Length;

            // 1) Transpose (swap across diagonal)
            for (int i = 0; i < l; i++)
            {
                for (int j = i + 1; j < l; j++)
                {
                    // Swap Using Tuple Deconstruction (Required C# 7.0+)
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }

            // 2) Reverse each row
            for (int i = 0; i < l; i++)
            {
                int left = 0, right = l - 1;
                while (left < right)
                {
                    (matrix[i][left], matrix[i][right]) = (matrix[i][right], matrix[i][left]);
                    left++;
                    right--;
                }
            }
        }
    }
}
