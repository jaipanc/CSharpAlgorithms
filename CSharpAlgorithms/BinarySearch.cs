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
    }
}
