namespace CSharpAlgorithms;

public class DynamicProgramming
{
    /// <summary>
    /// 198. House Robber
    /// You are a professional robber planning to rob houses along a street. 
    /// Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int Rob(int[] nums)
    {
        if (nums is null || nums.Length == 0) return 0;

        int prev = 0, curr = nums[prev];

        for (int i = 2; i <= nums.Length; i++)
        {
            int take = prev + nums[i - 1];
            int temp = curr;
            int skip = curr;
            curr = Math.Max(skip, take);
            prev = temp;
        }
        return curr;
    }

    /// <summary>
    /// 338. Counting Bits
    /// Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int[] CountBits(int n)
    {
        int[] dp = new int[n + 1];

        for (int i = 1; i < n + 1; i++)
        {
            dp[i] = dp[i / 2] + (i % 2);
        }
        return dp;
    }

    /// <summary>
    /// 91. Decode Ways - Calculates the total number of ways to decode a string of digits according to the mapping 'A' = 1, 'B' = 2, ...,
    /// 'Z' = 26.
    /// </summary>
    /// <remarks>The input string must not contain invalid digit sequences (such as leading zeros or digits
    /// that do not map to any letter).</remarks>
    /// <param name="s">The string of digits to decode. Each character must be a digit between '0' and '9'.</param>
    /// <returns>The number of possible decodings for the input string. Returns 0 if the string cannot be decoded.</returns>
    public static int NumDecodings(string s)
    {
        if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
        int n = s.Length;
        var dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            int digit = s[i - 1] - '0';
            if (digit != 0)
            {
                dp[i] += dp[i - 1];
            }

            digit = int.Parse(s.Substring(i - 2, 2));
            if (digit >= 10 && digit <= 26)
            {
                dp[i] += dp[i - 2];
            }
        }
        return dp[n];
    }

    /// <summary>
    /// 300. Longest Increasing Subsequence - Calculates the length of the longest strictly increasing subsequence in the specified array of integers.
    /// </summary>
    /// <param name="nums">An array of integers to search for the longest increasing subsequence. Cannot be null.</param>
    /// <returns>The length of the longest strictly increasing subsequence found in the input array. Returns 0 if the array is
    /// empty.</returns>
    public static int LengthOfLIS(int[] nums)
    {
        if (nums == null || nums.Length == 0) return 0;
        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, 1);

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        int result = 0;
        for (int i = 0; i < dp.Length; i++)
        {
            if (dp[i] > result)
            {
                result = dp[i];
            }
        }
        return result;
    }

    /// <summary>
    /// 62. Unique Paths - Calculates the number of unique paths from the top-left corner to the bottom-right corner of an m x n grid,
    /// moving only right or down at each step.
    /// </summary>
    /// <remarks>This method assumes movement is restricted to only rightward or downward steps. The result
    /// can be used to determine the number of possible routes in grid-based navigation problems.</remarks>
    /// <param name="m">The number of rows in the grid. Must be greater than zero.</param>
    /// <param name="n">The number of columns in the grid. Must be greater than zero.</param>
    /// <returns>The total number of unique paths from the top-left to the bottom-right corner of the grid.</returns>
    public static int UniquePaths(int m, int n)
    {
        var dp = new int[m, n];

        for (int i = 0; i < n; i++)
        {
            dp[0, i] = 1;
        }

        for (int j = 0; j < m; j++)
        {
            dp[j, 0] = 1;
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];
    }

    /// <summary>
    /// 221. Maximal Square
    /// Calculates the area of the largest square containing only '1's in the specified 2D binary matrix.
    /// </summary>
    /// <param name="matrix">A two-dimensional jagged array of characters representing the binary matrix. Each element must be either '0' or
    /// '1'.</param>
    /// <returns>The area of the largest square containing only '1's. Returns 0 if no such square exists or if the matrix is
    /// empty.</returns>
    public static int MaximalSquare(char[][] matrix)
    {
        if (matrix == null || matrix.Length == 0) return 0;

        int r = matrix.Length;
        int c = matrix[0].Length;
        var dp = new int[r + 1, c + 1];
        int maxSide = 0;

        for (int i = 1; i <= r; i++)
        {
            for (int j = 1; j <= c; j++)
            {
                if (matrix[i-1][j-1] == '1')
                {
                    int top = dp[i - 1, j];
                    int diag = dp[i - 1, j - 1];
                    int left = dp[i, j - 1];
                    dp[i, j] = Math.Min(Math.Min(top,left), diag) + 1;
                    maxSide = Math.Max(maxSide, dp[i, j]);
                }
            }
        }
        return maxSide * maxSide;
    }
}
