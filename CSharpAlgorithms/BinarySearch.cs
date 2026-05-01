namespace CSharpAlgorithms
{
    public class BinarySearch
    {
        /// <summary>
        /// Given a sorted array of integers nums and a target value target, 
        /// write a function to determine if target is in the array.
        /// </summary>
        /// <param name="arr">sorted array</param>
        /// <param name="target">number to find in array</param>
        /// <returns><see cref="int"/>If target is present in the array, return its index. Otherwise, return -1</returns>
        public static int FindTarget(int[] arr, int target)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (arr[mid] == target)
                {
                    return mid;
                }
                else if (arr[mid] > target)
                {
                    right = mid - 1;
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 35. Search Insert Position
        /// Searches for the specified target value within a sorted array and returns the index if found; otherwise,
        /// returns the index where the target should be inserted to maintain the array's sorted order.
        /// </summary>
        /// <remarks>The input array must be sorted in ascending order. If the target is less than all
        /// elements, 0 is returned. If the target is greater than all elements, the length of the array is
        /// returned.</remarks>
        /// <param name="nums">The sorted array of integers to search. Must not be null.</param>
        /// <param name="target">The value to locate within the array.</param>
        /// <returns>The zero-based index of the target if found; otherwise, the index where the target should be inserted to
        /// maintain the sorted order.</returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // ( left + rigth ) / 2 might cause int overflow
                if (nums[mid] == target) return mid;

                if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return left;
        }

        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// Searches for a specified target value in a rotated sorted array and returns its index if found.
        /// </summary>
        /// <remarks>The input array must not contain duplicate elements. The method performs the search
        /// in O(log n) time complexity.</remarks>
        /// <param name="nums">An array of integers that has been sorted in ascending order and then rotated at an unknown pivot.</param>
        /// <param name="target">The value to search for within the array.</param>
        /// <returns>The zero-based index of the target value if found; otherwise, -1.</returns>
        public int SearchRotatedArray(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target) return mid;

                //left half is sorted
                if (nums[left] <= nums[mid])
                {
                    if (target >= nums[left] && target < nums[mid]) right = mid - 1;
                    else left = mid + 1;
                }
                else
                {
                    //right half id sorted
                    if (target > mid && target <= nums[right]) left = mid + 1;
                    else right = mid - 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 875. Koko Eating Bananas
        /// Determines the minimum integer eating speed required to finish all banana piles within a given number of
        /// hours.
        /// </summary>
        /// <remarks>If it is not possible to finish all piles within the given hours, the method returns
        /// the smallest speed that allows completion. The method assumes that eating speed and pile sizes are positive
        /// integers.</remarks>
        /// <param name="piles">An array of integers representing the number of bananas in each pile. Each element must be a non-negative
        /// integer.</param>
        /// <param name="h">The maximum number of hours allowed to finish eating all the piles. Must be a positive integer.</param>
        /// <returns>The minimum integer value representing the eating speed (bananas per hour) needed to finish all piles within
        /// the specified number of hours.</returns>
        public static int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = piles.Max();

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                long hours = 0;
                foreach (var p in piles)
                {
                    hours += (p + mid - 1) / mid; // Math Ceiling Formula
                }

                if (hours > h) left = mid + 1;
                else right = mid;
            }
            return left;
        }
    }
}
