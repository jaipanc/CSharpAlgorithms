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
}
