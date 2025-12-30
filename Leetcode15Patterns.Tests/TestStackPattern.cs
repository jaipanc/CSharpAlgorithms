
namespace Leetcode15Patterns.Tests
{
    public class TestStackPattern
    {
        [Theory]
        [InlineData("(){({})}", true)]
        [InlineData("(){({}})", false)]
        public void TestIsValidString(string s, bool isValid)
        {
            var output = StackPattern.IsValid(s);
            Assert.Equal(isValid, output);
        }

        [Theory]
        [InlineData("3[a2[c]]", "accaccacc")]
        [InlineData("3[a]2[bc]", "aaabcbc")]
        [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
        public void TestDecodeString(string encoded,string decoded)
        {
            var output = StackPattern.DecodeString(encoded);
            Assert.Equal(decoded, output);
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 3, 2, 4, 3 }, new int[] { 3, 3, 4, 4, -1, -1 })]
        public void TestNextGreaterNumber(int[] nums, int[] output)
        {
            var result = StackPattern.NextGreaterNumber(nums);
            Assert.Equal(output, result);
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 }, new int[] { -1, 3, -1 })]
        [InlineData(new int[] { 2, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 3, -1 })]
        public void TestNextGreaterNumber1(int[] num1, int[] num2, int[] output)
        {
            var result = StackPattern.NextGreaterNumber(num1, num2);
            Assert.Equal(output, result);
        }

        [Theory]
        [InlineData(new int[] { 65, 70, 68, 60, 55, 75, 80, 74 }, new int[] { 1, 4, 3, 2, 1, 1, 0, 0 })]
        public void TestDailyTemperatures(int[] temperatures, int[] output)
        {
            var result = StackPattern.DailyTemperatures(temperatures);
            Assert.Equal(output, result);
        }
    }
}
