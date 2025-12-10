namespace Leetcode15Patterns.Tests
{
    public class PrefixSumTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 3, 9)]
        [InlineData(new int[] { 10, 20, 30, 40, 50 }, 2, 2, 30)]
        [InlineData(new int[] { 5, 10, 15 }, 0, 2, 30)]
        public void CalculatePrefixSum_ReturnsCorrectSum(int[] nums, int a, int b, int expectedSum)
        {
            int actualSum = PrefixSum.CalculatePrefixSum(nums, a, b);
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, -1, 2 }, 3, 2)]
        [InlineData(new int[] { 1, -1, 0 }, 0, 3)]
        public void TestSubArrayEqualsK(int[] nums, int k, int expectedCount)
        {
            int actualCount = PrefixSum.SubarraySumEqualsK(nums, k);
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [MemberData(nameof(GetCountVowelTestData))]
        public void TestCountVowels(string word, int[][] queries, int[] expectedResult)
        {
            var actualOutput = PrefixSum.countVowels(word, queries);
            Assert.Equal(expectedResult, actualOutput);
        }

        public static IEnumerable<object[]> GetCountVowelTestData()
        {
            yield return new object[]
            {
            "prefixsum", new int[][]{[0, 2], [1, 4], [3, 5]},new int[] { 1, 2, 1 }
            };
        }
    }
}
