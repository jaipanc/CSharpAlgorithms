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
