
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
    }
}
