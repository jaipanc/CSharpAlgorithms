namespace Leetcode15Patterns
{
    public static class DictionaryAndHashing
    {
        public static int[] LC1_TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (var i = 1; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (map.TryGetValue(complement, out int index))
                    return [index, i];
                map[nums[i]] = i;
            }
            return [];
        }
    }
}
