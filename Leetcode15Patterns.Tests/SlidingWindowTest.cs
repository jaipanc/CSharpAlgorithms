using System.Numerics;

namespace Leetcode15Patterns.Tests
{
    public class SlidingWindowTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 1, 2, 3 }, 4)]
        public void TestFruitsIntoBasket(int[] fruits, int expected)
        {
            var output = SlidingWindow.FruitsIntoBasket(fruits);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData("eghghhgg", 3)]
        public void TestLongestUniqueSubString(string s, int expectedLength)
        {
            var output = SlidingWindow.LongestUniqueSubString(s);
            Assert.Equal(expectedLength, output);
        }

        [Theory]
        [InlineData("BBABCCDD", 2, 5)]
        [InlineData("BCBABCCCCA", 2, 6)]
        public void TestcharacterReplacement(string s, int k, int expected)
        {
            var output = SlidingWindow.CharacterReplacement(s, k);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 5, 1, 3, 2}, 3, 9)]
        public void TestMaxSumSubArray(int[] nums, int k, int expected)
        {
            var output = SlidingWindow.MaxSumSubArray(nums, k);
            Assert.Equal(expected, output);
        }
    }
}
