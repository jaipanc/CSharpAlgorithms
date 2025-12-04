using System.Globalization;
using System.IO.MemoryMappedFiles;

namespace Leetcode15Patterns
{
    static public class TwoPointers
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

        // container with most water
        public static int maxArea(int[] height)
        {
            var left = 0;
            var right = height.Length - 1;
            var maxArea = 0;
            while (left < right)
            {
                var width = right - left;
                var currentHeight = Math.Min(height[left], height[right]);
                var currentArea = width * currentHeight;
                maxArea = Math.Max(maxArea, currentArea);
                // Move the pointer pointing to the shorter line
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxArea;
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

        //LC#611 Valid Triangle Numbers 
        public static int ValidTraingleNumbers(int[] nums)
        {
            Array.Sort(nums);
            int count = 0;

            for (int j = nums.Length - 1; j >= 2; j--)
            {
                var left = 0;
                var right = j - 1;

                while (left < right)
                {
                    if (nums[left] + nums[right] > nums[j])
                    {
                        int validTriplet = right - left;
                        count += validTriplet;
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }
            return count;
        }

        //Color Sorting using Dutch National Flag algorithm
        public static int[] SortColors(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;
            var i = 0;

            while (i <= right)
            {
                if (nums[i] == 0)
                {
                    //using tuple to swap the values , much cleaner than legacy approach
                    (nums[left], nums[i]) = (nums[i], nums[left]);
                    left++;
                    i++;
                }
                else if (nums[i] == 2)
                {
                    (nums[right], nums[i]) = (nums[i], nums[right]);
                    right--;
                }
                else
                {
                    i++;
                }
            }

            return nums;
        }

        // LC-42 Trapping Rain Water
        public static int TrappingRainWater(int[] heights)
        {
            int i = 0;
            int j = heights.Length - 1;
            int leftBar = heights[i];
            int rightBar = heights[j];
            int count = 0;

            while (i < j)
            {
                if (leftBar < rightBar)
                {
                    i++;
                    if (heights[i] >= leftBar)
                    {
                        leftBar = heights[i];
                    }
                    else
                    {
                        count += leftBar - heights[i];
                    }

                }
                else
                {
                    j--;
                    if (heights[j] >= rightBar)
                    {
                        rightBar = heights[j];
                    }
                    else
                    {
                        count += rightBar - heights[j];
                    }
                }
            }

            return count;
        }
    }
}
