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

        [Theory]
        [MemberData(nameof(KClosetToOriginTestData))]
        public void TestKClosetToOrigin(int[][] nums, int k, int[][] exptected)
        {
            var output = Heap.KClosetToOrigin(nums, k);
            Assert.Equivalent(exptected, output);
        }

        public static TheoryData<int[][],int, int[][]> KClosetToOriginTestData()
        {
            return new TheoryData<int[][], int, int[][]>()
            {
                {new int[][]{ [1, 3], [-2, 2] } , 1 , new int[][]{[-2,2]} },
                {new int[][]{ [3, 3], [5, -1], [-2, 4] } , 2 , new int[][]{ [3, 3], [-2, 4] } },
                {new int[][]{ [3, 4], [2, 2], [1, 1], [0, 0], [5, 5] } , 3 , new int[][]{ [2, 2], [1, 1], [0, 0] } }
            };
        }
    }
}
