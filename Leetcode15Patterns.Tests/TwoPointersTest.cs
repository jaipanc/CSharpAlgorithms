namespace Leetcode15Patterns.Tests
{
    public class TwoPointersTest
    {
        [Theory]
        [InlineData(new int[] { 10, 15, 3, 7 }, 17, true)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 8, false)]
        public void TestHasPairWithSum(int[] arr, int targetSum, bool hasPair)
        {
            Assert.Equal(hasPair, TwoPointers.HasPairWithSum(arr, targetSum));
        }

        [Theory]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [InlineData(new int[] { 1, 1 }, 1)]
        public void MaxAreaTest(int[] heights, int expectedArea)
        {
            var actualArea = TwoPointers.maxArea(heights);
            Assert.Equal(expectedArea, actualArea);
        }

        [Fact]
        public void MoveZeroes_MovesZerosToEnd()
        {
            int[] nums = [0, 1, 0, 3, 12];
            TwoPointers.MoveZeroes(nums);
            Assert.Equal([1, 3, 12, 0, 0], nums);
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 2, 0, 1, 0, 1, 0, 1 }, new int[] { 0, 0, 0, 1, 1, 1, 1, 2, 2 })]
        [InlineData(new int[] { 2, 0, 2, 1, 1, 0 }, new int[] { 0, 0, 1, 1, 2, 2 })]
        public void TestSortColors(int[] colors, int[] sortedColors)
        {
            int[] sortedResult = TwoPointers.SortColors(colors);
            Assert.Equal(sortedColors, sortedResult);
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 3, 4 }, 4)]
        public void TestValidTriangleNumbers(int[] nums, int tripletCount)
        {
            var resultCount = TwoPointers.ValidTraingleNumbers(nums);
            Assert.Equal(tripletCount, resultCount);
        }
    }
}
