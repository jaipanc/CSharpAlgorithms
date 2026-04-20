namespace CSharpAlgorithms.Tests;

public class GreedyAlgorithmTest
{
    [Theory]
    [MemberData(nameof(AssignCookiesTestData))]
    public void AssignCookies_VariousInputs_ReturnsExpectedCount(int[] greeds, int[] cookies, int expected)
    {
        // Act
        int result = GreedyAlgorithm.AssignCookies(greeds, cookies);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(BuySellStockTestData))]
    public void BuySellStockTest(int[] prices, int expectedProfit)
    {
        // Act
        int result = GreedyAlgorithm.BuySellStock(prices);

        // Assert
        Assert.Equal(expectedProfit, result);
    }

    [Theory]
    [MemberData(nameof(CanCompleteCircleTestData))]
    public void CanCompleteCircleTest(int[] gas, int[] cost, int expected)
    {
        // Act
        var result = GreedyAlgorithm.CanCompleteCircle(gas, cost);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(CanJumpTestData))]
    public void CanJumpTest(int[] nums, bool expected)
    {
        var result = GreedyAlgorithm.CanJump(nums);
        Assert.Equal(expected, result);
    }

    // MemberData source
    public static TheoryData<int[], int[], int> CanCompleteCircleTestData()
    {
        return new()
        {
            // Basic valid case
            { [ 1, 2, 3, 4, 5 ], [ 3, 4, 5, 1, 2 ], 3 },

            // Not possible
            { [ 2, 3, 4 ], [ 3, 4, 3 ], -1 },

            // Single station - valid
            { [ 5 ], [ 4 ], 0 },

            // Single station - not valid
            { [ 3 ], [ 4 ], -1 },

            // All equal
            { [ 2, 2, 2 ], [ 2, 2, 2 ], 0 },

            // Edge: start shifts multiple times
            { [5, 1, 2, 3, 4 ], [ 4, 4, 1, 5, 1 ], 4 }
        };
    }

    // MemberData source for CanJump tests
    public static TheoryData<int[], bool> CanJumpTestData()
    {
        return new()
        {
            // Typical reachable case
            { [2, 3, 1, 1, 4], true },

            // Stuck at zero before end
            { [3, 2, 1, 0, 4], false },

            // Empty array (no indices to fail) - method returns true
            { [], true },

            // Single element zero - already at last index
            { [0], true },

            // Can't move from start
            { [0, 2], false },

            // Can jump through zeros
            { [2, 0, 0], true },

            // Fails later when encountering unavoidable gap
            { [1, 0, 1, 0], false },

            // Simple increasing jumps
            { [1, 2, 3], true }
        };
    }

    [Theory]
    [MemberData(nameof(LengthOfLISTestData))]
    public void LengthOfLISTest(int[] nums, int expected)
    {
        var result = GreedyAlgorithm.LengthOfLIS(nums);
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
        var result = GreedyAlgorithm.UniquePaths(m, n);
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


    public static TheoryData<int[], int> BuySellStockTestData => new()
    {
        { [], 0 },                                    // Empty array
        { [7, 1, 5, 3, 6, 4], 5 },                   // Buy at 1, sell at 6
        { [7, 6, 4, 3, 1], 0 },                      // Decreasing prices, no profit
        { [1, 2, 3, 4, 5], 4 },                      // Increasing prices, buy at 1, sell at 5
        { [2, 4, 1, 7, 3], 6 },                      // Buy at 1, sell at 7
        { [5], 0 },                                   // Single element
        { [1, 1, 1, 1], 0 },                         // All same prices
        { [3, 2, 6, 5, 0, 3], 4 }                    // Buy at 2, sell at 6
    };

    public static TheoryData<int[], int[], int> AssignCookiesTestData()
    {
        return new()
        {
            // Basic cases
            { [1, 2, 3], [1, 1], 1 },
            { [], [1, 2, 3], 0 },
            { [1, 2, 3], [], 0 },
            { [], [], 0 },
            
            // Perfect match and variations
            { [1, 2, 3], [1, 2, 3], 3 },
            { [1, 2], [1, 2, 3, 4, 5], 2 },
            { [5, 6, 7], [1, 2, 3], 0 },
            
            // Unsorted arrays
            { [3, 1, 2], [4, 1, 2], 3 },
            { [5, 1, 3], [2, 4, 1, 3], 2 },
            { [10, 5, 8], [3, 15, 7, 1], 2 },
            
            // Special cases
            { [10], [1, 2, 3, 4, 5, 15], 1 },
            { [1, 1, 1], [1, 1, 1], 3 },
            { [5], [5], 1 },
            { [5], [3], 0 },
            
            // Complex cases
            { [1, 2, 4, 8], [1, 3, 5, 7, 9], 4 },
            { [1, 2, 4, 8, 16], [1, 3, 5], 3 }
        };
    }
}
