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

        [Theory]
        [InlineData(new int[] { 1, 5, 4, 2, 9, 9, 9 }, 3, 15)]
        [InlineData(new int[] { 4, 4, 4 }, 3, 0)]
        [InlineData(new int[] { 5, 5, 5, 5, 5 }, 3, 0)]
        [InlineData(new int[] { 3, 2, 2, 3, 4, 6, 7, 7, -1 }, 4, 20)]
        public void TestMaximumSumOfDistinctSubArray(int[] nums, int k, int expected)
        {
            var output = SlidingWindow.MaximumSumOfDistinctSubArray(nums, k);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(new int[] { 2, 11, 4, 5, 3, 9, 2 }, 3, 23)]
        public void TestMaxScoreFromGivenCards(int[] cards , int k , int expected)
        {
            var output = SlidingWindow.MaxScoreFromGivenCards(cards, k);
            Assert.Equal(expected, output);
        }
    }
}
