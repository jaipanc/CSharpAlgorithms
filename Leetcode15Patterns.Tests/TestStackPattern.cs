
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
    }
}
