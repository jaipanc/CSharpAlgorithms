namespace CSharpAlgorithms.Tests
{
    public class TwoPointersTest
    {
        private static readonly List<IList<int>> ThreeSumTestCase1 = new List<IList<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 1, 1 }
        };

        [Theory]
        [InlineData(new int[] { 10, 15, 3, 7 }, 17, true)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 8, false)]
        public void TestHasPairWithSum(int[] arr, int targetSum, bool hasPair)
        {
            Assert.Equal(hasPair, TwoPointers.HasPairWithSum(arr, targetSum));
        }

        [Theory]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [InlineData(new int[] { 1, 1 }, 1)]
        public void MaxAreaTest(int[] heights, int expectedArea)
        {
            var actualArea = TwoPointers.maxArea(heights);
            Assert.Equal(expectedArea, actualArea);
        }

        [Fact]
        public void MoveZeroes_MovesZerosToEnd()
        {
            int[] nums = [0, 1, 0, 3, 12];
            TwoPointers.MoveZeroes(nums);
            Assert.Equal([1, 3, 12, 0, 0], nums);
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 2, 0, 1, 0, 1, 0, 1 }, new int[] { 0, 0, 0, 1, 1, 1, 1, 2, 2 })]
        [InlineData(new int[] { 2, 0, 2, 1, 1, 0 }, new int[] { 0, 0, 1, 1, 2, 2 })]
        public void TestSortColors(int[] colors, int[] sortedColors)
        {
            int[] sortedResult = TwoPointers.SortColors(colors);
            Assert.Equal(sortedColors, sortedResult);
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 3, 4 }, 4)]
        public void TestValidTriangleNumbers(int[] nums, int tripletCount)
        {
            var resultCount = TwoPointers.ValidTraingleNumbers(nums);
            Assert.Equal(tripletCount, resultCount);
        }

        [Theory]
        [InlineData(new int[] { 3, 4, 1, 2, 2, 5, 1, 0, 2 }, 10)]
        [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        [InlineData(new int[] { }, 0)]
        [InlineData(new int[] { 1 }, 0)]
        [InlineData(new int[] { 1, 2 }, 0)]
        [InlineData(new int[] { 2, 1 }, 0)]
        [InlineData(new int[] { 0, 1, 2, 3, 4 }, 0)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 0)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 0)]
        [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 0)]
        [InlineData(new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
        [InlineData(new int[] { 2, 0, 2 }, 2)]
        [InlineData(new int[] { 5, 1, 5 }, 4)]
        [InlineData(new int[] { 3, 0, 3 }, 3)]
        [InlineData(new int[] { 4, 1, 1, 4 }, 6)]
        [InlineData(new int[] { 5, 2, 1, 2, 1, 5 }, 14)]
        [InlineData(new int[] { 1, 0, 2, 0, 1, 0, 3 }, 6)]
        [InlineData(new int[] { 3, 0, 2, 0, 4 }, 7)]
        [InlineData(new int[] { 2, 1, 0, 1, 3 }, 4)]
        [InlineData(new int[] { 2, 2, 2, 2 }, 0)]
        [InlineData(new int[] { 0, 0, 0, 0 }, 0)]
        [InlineData(new int[] { 5, 0, 0, 0, 5 }, 15)]
        [InlineData(new int[] { 6, 1, 0, 1, 6 }, 16)]
        [InlineData(new int[] { 1, 3, 2, 1, 2, 3, 1 }, 4)]
        [InlineData(new int[] { 2, 1, 2, 1, 2, 1, 2 }, 3)]
        [InlineData(new int[] { 4, 1, 3, 1, 4 }, 7)]
        [InlineData(new int[] { 3, 1, 2, 1, 3 }, 5)]
        public void TestTrappingRainWater(int[] heights, int trappedWaterCount)
        {
            var resultCount = TwoPointers.TrappingRainWater(heights);
            Assert.Equal(trappedWaterCount, resultCount);
        }

        [Fact]
        public void Test3Sum()
        {
            int[] nums = [-1, 0, 1, 2, -1, -1];
            var expectedTriplets = new List<IList<int>> { new List<int> { -1, -1, 2 }, new List<int> { -1, 0, 1 } };
            var result = TwoPointers.ThreeSum(nums);
            Assert.Equal(expectedTriplets, result);
        }
    }
}
