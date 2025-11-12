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

        public static int[] SquaredSortedArray(int[] arr)
        {
            var n = arr.Length;
            var result = new int[n];
            var left = 0;
            var right = n - 1;
            var highestSquareIndex = n - 1;
            while (left <= right)
            {
                var leftSquare = arr[left] * arr[left];
                var rightSquare = arr[right] * arr[right];
                if (leftSquare > rightSquare)
                {
                    result[highestSquareIndex] = leftSquare;
                    left++;
                }
                else
                {
                    result[highestSquareIndex] = rightSquare;
                    right--;
                }
                highestSquareIndex--;
            }
            return result;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums); // Step 1: Sort the array
            var result = new List<IList<int>>();
            int n = nums.Length;

            for (int i = 0; i < n - 2; i++) // we need at least three indices for a triplet so n-2
            {
                // Skip duplicate values for i
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int left = i + 1;
                int right = n - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add([nums[i], nums[left], nums[right]]);

                        // Move left pointer to next unique number
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        // Move right pointer to previous unique number
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++; // Need a bigger sum
                    }
                    else
                    {
                        right--; // Need a smaller sum
                    }
                }
            }

            return result;
        }
    }
}
