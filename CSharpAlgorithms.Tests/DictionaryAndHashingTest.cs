namespace CSharpAlgorithms.Tests
{
    public class DictionaryAndHashingTest
    {
        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        public void LC1_TwoSum_ShouldReturnCorrectIndices(int[] nums, int target, int[] expected)
        {         
            // Act
            int[] result = DictionaryAndHashing.LC1_TwoSum(nums, target);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
