namespace Leetcode15Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example usage of TwoPointers
            Console.WriteLine(TwoPointers.HasPairWithSum([1, 3, 4, 6, 8, 10, 13],13));

            // Example usage of PrefixSum
            int[] nums = { 1, 2, 3, 4, 5 };
            int a = 1;
            int b = 3;
            int result = PrefixSum.CalculatePrefixSum(nums, a, b);
            Console.WriteLine($"Sum of elements between indices {a} and {b} is: {result}");
        }
    }
}
