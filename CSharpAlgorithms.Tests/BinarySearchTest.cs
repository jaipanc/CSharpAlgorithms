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
    }
}
