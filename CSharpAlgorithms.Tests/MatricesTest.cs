namespace CSharpAlgorithms.Tests
{
    public class MatricesTest
    {
        [Theory]
        [MemberData(nameof(SpiralOrderTestData))]
        public void TestSpiralOrder(int[][] matrix, List<int> expected)
        {
            var output = Matrices.SpiralOrder(matrix);
            Assert.Equal(expected, output);
        }

        public static TheoryData<int[][], List<int>> SpiralOrderTestData()
        {
            var data = new TheoryData<int[][], List<int>>
            {
                { new int[][] { [0,1,2], [3,4,5], [6,7,8] }, new List<int>{0,1,2,5,8,7,6,3,4 } },
                { new int[][] { [1,2,3],[4,5,6],[7,8,9] }, new List<int>{ 1, 2, 3, 6, 9, 8, 7, 4, 5 } },
                { new int[][] { [1,2,3,4],[5,6,7,8],[9,10,11,12] }, new List<int>{ 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 } }
            };
            return data;
        }
    }
}
