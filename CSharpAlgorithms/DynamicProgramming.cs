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
}
