namespace CSharpAlgorithms.Tests;

public class DynamicProgrammingTest
{
    public static TheoryData<int[], int> RobTestData =>
        new()
        {
            { null!, 0 },
            { Array.Empty<int>(), 0 },
            { [ 1 ], 1 },
            { [ 1, 2, 3, 1 ], 4 },
            { [ 2, 7, 9, 3, 1 ], 12 },
            { [ 2, 1, 1, 2 ], 4 }
        };

    [Theory]
    [MemberData(nameof(RobTestData))]
    public void Rob_ShouldReturnMaxAmount(int[] nums, int expected)
    {
        var result = DynamicProgramming.Rob(nums);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, new int[] { 0 })]
    [InlineData(1, new int[] { 0, 1 })]
    [InlineData(2, new int[] { 0, 1, 1 })]
    [InlineData(3, new int[] { 0, 1, 1, 2 })]
    [InlineData(4, new int[] { 0, 1, 1, 2, 1 })]
    [InlineData(7, new int[] { 0, 1, 1, 2, 1, 2, 2, 3 })]
    public void CountingBitsTest(int n, int[] expected)
    {
        var result = DynamicProgramming.CountBits(n);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(NumDecodingsTestData))]
    public void NumDecodingsTest(string s, int expected)
    {
        var result = DynamicProgramming.NumDecodings(s);
        Assert.Equal(expected, result);
    }

    public static TheoryData<string, int> NumDecodingsTestData()
    {
        return new()
        {
            { null!, 0 },         // null input
            { "", 0 },          // empty string
            { "0", 0 },         // single zero invalid
            { "1", 1 },
            { "12", 2 },        // "AB" or "L"
            { "226", 3 },       // "BZ","VF","BBF"
            { "10", 1 },        // only "J"
            { "100", 0 },       // invalid trailing zero
            { "101", 1 },       // "10" + "1"
            { "27", 1 },        // 27 can't pair -> only separate
            { "110", 1 }        // "11" + "0"
        };
    }

    [Theory]
    [MemberData(nameof(MaximalSquareTestData))]
    public void MaximalSquareTest(char[][] matrix, int expected)
    {
        var result = DynamicProgramming.MaximalSquare(matrix);
        Assert.Equal(expected, result);
    }

    public static TheoryData<char[][], int> MaximalSquareTestData()
    {
        return new()
        {
            { null!, 0 }, // null matrix
            { Array.Empty<char[]>(), 0 }, // empty matrix (no rows)
            { new char[][] { [] }, 0 }, // one row, zero cols

            // single cell
            { new char[][] { ['0'] }, 0 },
            { new char[][] { ['1'] }, 1 },

            // simple 2x2
            { new char[][] { ['1','1'], ['1','1'] }, 4 },

            // rectangular with full ones (3x5) -> max square side = 3 -> area = 9
            { new char[][] { ['1','1','1','1','1'], ['1','1','1','1','1'], ['1','1','1','1','1'] }, 9 },

            // LeetCode example -> maximal square area = 4
            {
                new char[][]
                {
                    ['1','0','1','0','0'],
                    ['1','0','1','1','1'],
                    ['1','1','1','1','1'],
                    ['1','0','0','1','0']
                },
                4
            },

            // no ones
            { new char[][] { ['0','0','0'], ['0','0','0'] }, 0 }
        };
    }

    [Theory]
    [MemberData(nameof(LengthOfLISTestData))]
    public void LengthOfLISTest(int[] nums, int expected)
    {
        var result = DynamicProgramming.LengthOfLIS(nums);
        Assert.Equal(expected, result);
    }

    public static TheoryData<int[], int> LengthOfLISTestData()
    {
        return new()
        {
            // Empty input
            { [], 0 },

            // Single element
            { [1], 1 },

            // Strictly increasing
            { [1, 2, 3, 4, 5], 5 },

            // All equal
            { [7, 7, 7, 7], 1 },

            // Typical mixed example
            { [10, 9, 2, 5, 3, 7, 101, 18], 4 },

            // Another mixed case
            { [0, 1, 0, 3, 2, 3], 4 },

            // Decreasing sequence
            { [5, 4, 3, 2, 1], 1 },

            // Complex case
            { [4, 10, 4, 3, 8, 9], 3 }
        };
    }

    [Theory]
    [MemberData(nameof(UniquePathsTestData))]
    public void UniquePathsTest(int m, int n, int expected)
    {
        var result = DynamicProgramming.UniquePaths(m, n);
        Assert.Equal(expected, result);
    }

    public static TheoryData<int, int, int> UniquePathsTestData()
    {
        return new()
        {
            // Minimal grids
            { 1, 1, 1 },
            { 1, 5, 1 },
            { 5, 1, 1 },

            // Small grids
            { 2, 2, 2 },
            { 3, 3, 6 },
            { 3, 2, 3 },

            // Known combinatorial values
            { 3, 7, 28 },
            { 7, 3, 28 },

            // Larger but reasonable
            { 5, 5, 70 }
        };
    }
}
