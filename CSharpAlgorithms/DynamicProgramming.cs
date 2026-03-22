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
}
