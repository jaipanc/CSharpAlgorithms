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

        [Theory]
        [MemberData(nameof(SetZeroesTestData))]
        public void TestSetZeroes(int[][] matrix, int[][] expected)
        {
            var output = Matrices.SetZeroes(matrix);
            Assert.Equal(expected, output);
        }

        public static TheoryData<int[][], int[][]> SetZeroesTestData()
        {
            var data = new TheoryData<int[][], int[][]>
            {
                { new int[][] { [0,1,2,0],[3,4,5,2],[1,3,1,5] }, new int[][]{ [0, 0, 0, 0], [0, 4, 5, 0], [0, 3, 1, 0] } },
                { new int[][] { [1,1,1],[1,0,1],[1,1,1] }, new int[][] { [1,0,1],[0,0,0],[1,0,1] } },
                { new int[][] { [1,0,3],[4,5,6],[7,8,9] }, new int[][] { [0,0,0],[4,0,6],[7,0,9] } },
                { new int[][] { [1,2,3],[0,5,6],[7,8,9] }, new int[][] { [0,2,3],[0,0,0],[0,8,9] } },
                { new int[][] { [0,1,2,0],[3,4,5,2],[1,3,1,5] }, new int[][] { [0,0,0,0],[0,4,5,0],[0,3,1,0] } },
                { new int[][] { [1,0,3],[4,5,6],[0,8,9] }, new int[][] { [0,0,0],[0,0,6],[0,0,0] } },
                { new int[][] { [1,2,3],[0,0,0],[4,5,6] }, new int[][] { [0,0,0],[0,0,0],[0,0,0] } },
                { new int[][] { [1,0,3],[4,0,6],[7,0,9] }, new int[][] { [0,0,0],[0,0,0],[0,0,0] } },
                { new int[][] { [1,0,3] }, new int[][] { [0,0,0] } },
                { new int[][] { [1],[0],[3] }, new int[][] { [0],[0],[0] } },
                { new int[][] { [1,2],[3,4] }, new int[][] { [1,2],[3,4] } }
            };
            return data;
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
