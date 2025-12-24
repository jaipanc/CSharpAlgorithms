namespace Leetcode15Patterns.Tests
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
    }
}
