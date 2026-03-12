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

    [Theory]
    [MemberData(nameof(CourseScheduleData))]
    public void FindOrderTest(int numCourses, int[][] prerequisites, int[] expectedCourses)
    {
        var result = Graphs.FindOrder(numCourses, prerequisites);
        Assert.Equal(numCourses, result.Length);

        // verifies all courses present
        Assert.Equivalent(expectedCourses, result);

        // verifies prerequisite ordering
        Assert.True(IsValidOrder(result, prerequisites));
    }

    bool IsValidOrder(int[] order, int[][] prerequisites)
    {
        var position = order
            .Select((course, index) => (course, index))
            .ToDictionary(x => x.course, x => x.index);

        foreach (var p in prerequisites)
        {
            int course = p[0];
            int prereq = p[1];

            if (position[prereq] > position[course])
                return false;
        }

        return true;
    }

    public static TheoryData<int, int[][], int[]> CourseScheduleData =>
        new()
        {
            {
                2,
                new int[][] { [1,0] },
                new [] {0,1}
            },
            {
                4,
                new int[][]
                {
                    [1,0],
                    [2,0],
                    [3,1],
                    [3,2]
                },
                new [] {0,1,2,3}
            },
            {
                3,
                Array.Empty<int[]>(),
                new [] {0,1,2}
            }
        };

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

