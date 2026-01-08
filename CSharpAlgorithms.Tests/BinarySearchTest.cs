namespace CSharpAlgorithms.Tests
{
    public class BinarySearchTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5, 4)]
        [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
        [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
        [InlineData(new int[] { }, 2, -1)]
        [InlineData(new int[] { 1 }, 2, -1)]
        public void TestFindTarget(int[] arr, int target, int expected)
        {
            var output = BinarySearch.FindTarget(arr, target);
            Assert.Equal(expected, output);
        }
    }
}
