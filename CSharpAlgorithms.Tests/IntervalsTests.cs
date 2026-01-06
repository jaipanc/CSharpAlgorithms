namespace CSharpAlgorithms.Tests
{
    public class IntervalsTests
    {
        [Theory]
        [MemberData(nameof(CanAttendMeetingsTestData))]
        public void TestCanAttendMeetings(int[][] intervals, bool expected)
        {
            var output = Intervals.CanAttendMeetings(intervals);
            Assert.Equal(expected, output);
        }

        public static TheoryData<int[][], bool> CanAttendMeetingsTestData()
        {
            var data = new TheoryData<int[][], bool>
            {
                { new int[][] { [1, 2], [2, 3] }, true },
                { new int[][] { [0, 30], [5, 10], [15, 20] }, false },
                { null, false },
                { new int[][] { [2, 4], [9, 12], [6, 9], [13, 15] }, true }
            };
            return data;
        }

        [Theory]
        [MemberData(nameof(EraseOverlapIntervalsTestData))]
        public void TestEraseOverlapIntervals(int[][] intervals, int output)
        {
            var actualOutput = Intervals.EraseOverlapIntervals(intervals);
            Assert.Equal(output, actualOutput);
        }

        public static TheoryData<int[][], int> EraseOverlapIntervalsTestData()
        {
            var data = new TheoryData<int[][], int>
            {
                { new int[][]{[1,2],[2,3],[3,4],[1,3]}, 1 },
                { new int[][]{[1,2],[1,2],[1,2]}, 2 },
                { new int[][]{[1,2],[2,3]}, 0 }
            };
            return data;
        }

        [Theory]
        [MemberData(nameof(EmployeeFreeTimeTestData))]
        public void TestEmployeeFreeTime(int[][][] schedules, int[][] common)
        {
            var output = Intervals.EmployeeFreeTime(schedules);
            Assert.Equal(common, output);
        }

        public static TheoryData<int[][][], int[][]> EmployeeFreeTimeTestData()
        {
            return new TheoryData<int[][][], int[][]>
            {
                {new int[][][]{[[1,2],[5,6]],[[1,3]],[[4,10]]}, new int[][]{[3,4]} },
                {new int[][][]{[[1,3],[6,7]],[[2,4]],[[2,5],[9,12]]}, new int[][]{ [5, 6], [7, 9] } }
            };
        }
    }
}
