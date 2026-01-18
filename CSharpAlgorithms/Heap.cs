using static System.Runtime.InteropServices.JavaScript.JSType;

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

        /// <summary>
        /// 973. K Closest Points to Origin
        /// Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin (0, 0).
        /// The distance between two points on the X-Y plane is the Euclidean distance(i.e., √(x1 - x2)2 + (y1 - y2)2).
        /// You may return the answer in any order.The answer is guaranteed to be unique (except for the order that it is in).
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[][] KClosetToOrigin(int[][] nums, int k)
        {
            var pq = new PriorityQueue<int[], int>();

            foreach (var num in nums)
            {
                int x = num[0], y = num[1];
                int dist = x * x + y * y;

                pq.Enqueue(num, -dist);

                if (pq.Count > k)
                    pq.Dequeue();// removes farthest (most negative priority == farthest)
            }
            return [.. pq.UnorderedItems.Select(static x => x.Element)];
        }
    }
}
