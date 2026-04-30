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
    }
}
