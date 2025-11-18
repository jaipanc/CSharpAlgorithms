namespace Leetcode15Patterns.Tests
{
    public class TwoPointersTest
    {
        [Fact]
        public void HasPairWithSum_ReturnsTrue_WhenPairExists()
        {
            int[] arr = [10, 15, 3, 7];
            int targetSum = 17;
            Assert.True(TwoPointers.HasPairWithSum(arr, targetSum));
        }

        [Fact]
        public void HasPairWithSum_ReturnsFalse_WhenPairDoesNotExist()
        {
            int[] arr = [1, 2, 3, 4];
            int targetSum = 8;
            Assert.False(TwoPointers.HasPairWithSum(arr, targetSum));
        }

        [Fact]
        public void MoveZeroes_MovesZerosToEnd()
        {
            int[] nums = [0, 1, 0, 3, 12];
            TwoPointers.MoveZeroes(nums);
            Assert.Equal([1, 3, 12, 0, 0], nums);
        }
    }
}
