
using System.Diagnostics.Contracts;

namespace Leetcode15Patterns.Tests
{
    public class PrefixSumTest
    {
        [Fact]
        public void CalculatePrefixSum_ReturnsCorrectSum()
        {
            int[] nums = [1, 2, 3, 4, 5];
            int a = 1;
            int b = 3;
            int result = PrefixSum.CalculatePrefixSum(nums, a, b);
            Assert.Equal(9, result); // 2 + 3 + 4 = 9
        }

        [Fact]
        public void CalculatePrefixSum_SingleElement_ReturnsElementValue()
        {
            int[] nums = [10, 20, 30, 40, 50];
            int a = 2;
            int b = 2;
            int result = PrefixSum.CalculatePrefixSum(nums, a, b);
            Assert.Equal(30, result); // Only the element at index 2
        }

        [Fact]
        public void CalculatePrefixSum_FullArray_ReturnsTotalSum()
        {
            int[] nums = [5, 10, 15];
            int a = 0;
            int b = 2;
            int result = PrefixSum.CalculatePrefixSum(nums, a, b);
            Assert.Equal(30, result); // 5 + 10 + 15 = 30
        }

    }
}
