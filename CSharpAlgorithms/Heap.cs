namespace CSharpAlgorithms
{
    public class Heap
    {
        /// <summary>
        /// Given an integer array nums, return the 3 largest elements in the array in any order.
        /// </summary>
        /// <param name="nums">int array</param>
        /// <returns>an array containing 3 largest number.</returns>
        public static int[] ThreeLargest(int[] nums)
        {
            var heap = new PriorityQueue<int, int>();

            foreach (var n in nums)
            {
                heap.Enqueue(n, n);

                if (heap.Count > 3)
                    heap.Dequeue();
            }

            return [.. heap.UnorderedItems.Select(x => x.Element)];
        }
    }
}
