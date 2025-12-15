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
    }
}
