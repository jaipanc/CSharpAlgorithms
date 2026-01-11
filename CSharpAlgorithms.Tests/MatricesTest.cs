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
                { new int[][] { [0,1,2], [3,4,5], [6,7,8] }, new List<int>{0,1,2,5,8,7,6,3,4 } }
            };
            return data;
        }
    }
}
