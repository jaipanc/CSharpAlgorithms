namespace CSharpAlgorithms.Tests
{
    public class HeapTest
    {
        [Theory]
        [InlineData(new int[] { 9, 3, 7, 1, -2, 6, 8 }, new int[] { 7, 9, 8 })]
        public void TestHeap(int[] nums, int[] expected)
        {
            var output = Heap.ThreeLargest(nums);
            Assert.Equal(expected, output);
        }
    }
}
