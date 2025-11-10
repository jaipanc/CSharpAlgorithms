namespace Leetcode15Patterns
{
    static internal class TwoPointers
    {
        public static bool HasPairWithSum(int[] arr, int targetSum)
        {
            var left = 0;
            var right = arr.Length - 1;
            Array.Sort(arr); // Ensure the array is sorted

            while (left < right)
            {
                var currentSum = arr[left] + arr[right];
                if (currentSum == targetSum)
                {
                    return true;
                }
                if (currentSum < targetSum)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return false;
        }

        public static void MoveZeroes(int[] nums)
        {
            var i = 0;
            for (var j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    // swap the numbers
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                }
            }
        }
    }
}
