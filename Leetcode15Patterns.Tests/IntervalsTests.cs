namespace Leetcode15Patterns.Tests
{
    public class IntervalsTests
    {
        [Fact]
        public void CanAttendMeetings_ReturnsTrue_ForNonOverlapping()
        {
            int[][] intervals = [[2, 4], [9, 12], [6, 9], [13, 15]];
            Assert.True(Intervals.CanAttendMeetings(intervals));
        }

        [Fact]
        public void CanAttendMeetings_ReturnsFalse_ForOverlapping()
        {
            int[][] intervals = [[0, 30], [5, 10], [15, 20]];
            Assert.False(Intervals.CanAttendMeetings(intervals));
        }

        [Fact]
        public void CanAttendMeetings_ReturnsFalse_ForNullOrEmpty()
        {
            Assert.False(Intervals.CanAttendMeetings(null));
            Assert.False(Intervals.CanAttendMeetings([]));
        }

        [Fact]
        public void CanAttendMeetings_TouchingEndpoints_NotOverlap()
        {
            int[][] intervals = [[1, 2], [2, 3]];
            Assert.True(Intervals.CanAttendMeetings(intervals));
        }

        [Theory]
        [MemberData(nameof(EraseOverlapIntervalsTestData))]
        public void TestEraseOverlapIntervals(int[][] intervals, int output)
        {
            var actualOutput = Intervals.EraseOverlapIntervals(intervals);
            Assert.Equal(output, actualOutput);
        }

        public static IEnumerable<object[]> EraseOverlapIntervalsTestData()
        {
            yield return new object[]
            {
            new int[][]{[1,2],[2,3],[3,4],[1,3]},1
            };

            yield return new object[]
           {
               new int[][]{[1,2],[1,2],[1,2]},2
           };

            yield return new object[]
           {
               new int[][]{[1,2],[2,3]},0
           };
        }
    }
}
