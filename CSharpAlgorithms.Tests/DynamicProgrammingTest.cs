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
}
