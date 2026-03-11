namespace CSharpAlgorithms.Tests;

public class GraphsTest
{
    [Theory]
    [MemberData(nameof(CourseScheduleTestData))]
    public void CanFinishTest(int numCourses, int[][] prerequisites, bool expected)
    {
        var result = Graphs.CanFinish(numCourses, prerequisites);
        Assert.Equal(expected, result);
    }
    public static TheoryData<int, int[][], bool> CourseScheduleTestData =>
        new()
        {
            // Basic valid case
            {
                2,
                new int[][] { [1,0] },
                true
            },

            // Simple cycle
            {
                2,
                new int[][] { [1,0], [0,1] },
                false
            },

            // No prerequisites
            {
                3,
                Array.Empty<int[]>(),
                true
            },

            // Linear dependency
            {
                4,
                new int[][]
                {
                    [1,0],
                    [2,1],
                    [3,2]
                },
                true
            },

            // Complex DAG
            {
                4,
                new int[][]
                {
                    [1,0],
                    [2,0],
                    [3,1],
                    [3,2]
                },
                true
            },

            // Cycle in middle
            {
                4,
                new int[][]
                {
                    [1,0],
                    [2,1],
                    [0,2],
                    [3,2]
                },
                false
            },

            // Self dependency
            {
                1,
                new int[][]
                {
                    [0,0]
                },
                false
            }
        };

}

