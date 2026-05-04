namespace CSharpAlgorithms.Tests
{
    public class BinarySearchTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5, 4)]
        [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
        [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
        [InlineData(new int[] { }, 2, -1)]
        [InlineData(new int[] { 1 }, 2, -1)]
        public void TestFindTarget(int[] arr, int target, int expected)
        {
            var output = BinarySearch.FindTarget(arr, target);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 5, 6 }, 5, 2)]
        [InlineData(new int[] { 1, 3, 5, 6 }, 2, 1)]
        [InlineData(new int[] { 1, 3, 5, 6 }, 7, 4)]
        [InlineData(new int[] { 1, 3, 5, 6 }, 0, 0)]
        [InlineData(new int[] { 1 }, 1, 0)]
        [InlineData(new int[] { 1 }, 0, 0)]
        [InlineData(new int[] { 1 }, 2, 1)]
        [InlineData(new int[] { 1, 3 }, 2, 1)]
        public void TestSearchInsert(int[] nums, int target, int expected)
        {
            var binarySearch = new BinarySearch();
            var output = binarySearch.SearchInsert(nums, target);
            Assert.Equal(expected, output);
        }

        [Theory]
        // Target found in left sorted half
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 5, 1)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4, 0)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6, 2)]
        // Target found in right sorted half
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1, 5)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 2, 6)]
        // Target not found
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 8, -1)]
        // Edge cases
        [InlineData(new int[] { 1 }, 1, 0)]
        [InlineData(new int[] { 1 }, 0, -1)]
        [InlineData(new int[] { 1, 3 }, 3, 1)]
        [InlineData(new int[] { 1, 3 }, 1, 0)]
        [InlineData(new int[] { 3, 1 }, 1, 1)]
        [InlineData(new int[] { 3, 1 }, 3, 0)]
        // Larger rotated arrays
        [InlineData(new int[] { 5, 1, 3 }, 3, 2)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 1)]
        [InlineData(new int[] { 7, 1, 2, 3, 4, 5, 6 }, 2, 2)]
        public void TestSearchRotatedArray(int[] nums, int target, int expected)
        {
            var binarySearch = new BinarySearch();
            var output = binarySearch.SearchRotatedArray(nums, target);
            Assert.Equal(expected, output);
        }

        [Theory]
        // Basic cases
        [InlineData(new int[] { 1, 1, 1, 1 }, 4, 1)]
        [InlineData(new int[] { 312884132 }, 968709470, 1)]
        // Multiple piles, sufficient time
        [InlineData(new int[] { 1, 1, 1, 1 }, 8, 1)]
        [InlineData(new int[] { 312884132 }, 968709469, 1)]
        // Large numbers
        [InlineData(new int[] { 4, 3, 8, 2 }, 5, 4)]
        [InlineData(new int[] { 7, 11 }, 9, 3)]
        // Single pile
        [InlineData(new int[] { 10 }, 1, 10)]
        [InlineData(new int[] { 100 }, 10, 10)]
        [InlineData(new int[] { 100 }, 100, 1)]
        // Multiple piles with varying sizes
        [InlineData(new int[] { 1, 1, 1, 1 }, 4, 1)]
        [InlineData(new int[] { 1, 10, 1, 10, 1, 10, 1, 10, 1, 10 }, 50, 2)]
        // Tight time constraint
        [InlineData(new int[] { 1, 1, 1, 1 }, 4, 1)]
        [InlineData(new int[] { 100, 100, 100, 100 }, 4, 100)]
        public void TestMinEatingSpeed(int[] piles, int h, int expected)
        {
            var output = BinarySearch.MinEatingSpeed(piles, h);
            Assert.Equal(expected, output);
        }

        public static TheoryData<int[][], int, int> KthSmallestTestData()
        {
            return new TheoryData<int[][], int, int>
            {
                // Basic 2x2 matrix tests
                { new int[][] { [1, 2], [1, 3] }, 1, 1 },
                { new int[][] { [1, 2], [1, 3] }, 2, 1 },
                { new int[][] { [1, 2], [1, 3] }, 3, 2 },
                { new int[][] { [1, 2], [1, 3] }, 4, 3 },

                // 3x3 matrix tests
                { new int[][] { [1, 2, 4], [3, 5, 8], [6, 9, 11] }, 1, 1 },
                { new int[][] { [1, 2, 4], [3, 5, 8], [6, 9, 11] }, 5, 5 },
                { new int[][] { [1, 2, 4], [3, 5, 8], [6, 9, 11] }, 9, 11 },

                // Matrix with duplicate values
                { new int[][] { [1, 1], [1, 2] }, 1, 1 },
                { new int[][] { [1, 1], [1, 2] }, 2, 1 },
                { new int[][] { [1, 1], [1, 2] }, 3, 1 },
                { new int[][] { [1, 1], [1, 2] }, 4, 2 },

                // Single element matrix
                { new int[][] { [5] }, 1, 5 },

                // Larger 3x3 matrix
                { new int[][] { [1, 3, 5], [2, 4, 6], [7, 8, 9] }, 1, 1 },
                { new int[][] { [1, 3, 5], [2, 4, 6], [7, 8, 9] }, 5, 5 },
                { new int[][] { [1, 3, 5], [2, 4, 6], [7, 8, 9] }, 9, 9 },
            };
        }

        [Theory]
        [MemberData(nameof(KthSmallestTestData))]
        public void TestKthSmallest(int[][] matrix, int k, int expected)
        {
            var output = BinarySearch.KthSmallest(matrix, k);
            Assert.Equal(expected, output);
        }
    }
}
