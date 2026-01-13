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

        [Theory]
        [MemberData(nameof(RotateImageTestData))]
        public void TestRotateImage(int[][] matrix, int[][] expected)
        {
            Matrices.RotateImage(matrix);
            Assert.Equal(expected, matrix);
        }

        public static TheoryData<int[][], int[][]> RotateImageTestData()
        {
            var data = new TheoryData<int[][], int[][]>
            {
                { new int[][] { [1,4,7],[2,5,8],[3,6,9] }, new int[][]{ [3,2,1],[6,5,4],[9,8,7]} },
                { new int[][] { [1,2,3],[4,5,6],[7,8,9] }, new int[][]{ [7, 4, 1], [8, 5, 2], [9, 6, 3] } },
                { new int[][] { [5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16] }, new int[][]{ [15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11] } }
            };
            return data;
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
