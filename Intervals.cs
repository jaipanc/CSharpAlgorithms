using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode15Patterns
{
    static internal class Intervals
    {
        public static bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals is null || intervals.Length == 0)
            {
                return true;
            }

            // Sort intervals based on start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            for (int i = 1; i < intervals.Length; i++)
            {
                // If the start time of the current interval is less than the end time of the previous interval, return false
                if (intervals[i][0] < intervals[i - 1][1])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
