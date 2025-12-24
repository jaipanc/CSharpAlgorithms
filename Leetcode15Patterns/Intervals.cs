using System.Xml.Schema;

namespace Leetcode15Patterns
{
    static public class Intervals
    {

        public static bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals is null || intervals.Length == 0)
            {
                return false;
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

        //435. Non-overlapping Intervals
        public static int EraseOverlapIntervals(int[][] intervals)
        {
            var len = intervals.Length;
            if (len == 0)
            {
                return 0;
            }
            int count = 0;
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var lastEnd = intervals[0][1];

            for (int i = 1; i < len; i++)
            {
                if (intervals[i][0] < lastEnd)
                    count++;
                else
                    lastEnd = intervals[i][1];
            }
            return count;
        }

        public static int[][] MergeIntervals(int[][] intervals)
        {
            if (intervals is null || intervals.Length == 0)
            {
                return [];
            }
            // Sort intervals based on start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var merged = new List<int[]>
            {
                intervals[0]
            };
            for (int i = 1; i < intervals.Length; i++)
            {
                var lastMerged = merged[^1];
                // If the current interval overlaps with the last merged interval, merge them
                if (intervals[i][0] <= lastMerged[1])
                {
                    lastMerged[1] = Math.Max(lastMerged[1], intervals[i][1]);
                }
                else
                {
                    merged.Add(intervals[i]);
                }
            }
            return [.. merged];
        }

        public static int[][] InsertInterval(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int i = 0;
            // Add all intervals ending before newInterval starts
            while (i < intervals.Length && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }
            // Merge overlapping intervals
            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            result.Add(newInterval);
            // Add remaining intervals
            while (i < intervals.Length)
            {
                result.Add(intervals[i]);
                i++;
            }
            return [.. result];
        }

        public static int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            var result = new List<int[]>();
            int i = 0, j = 0;
            while (i < firstList.Length && j < secondList.Length)
            {
                int startMax = Math.Max(firstList[i][0], secondList[j][0]);
                int endMin = Math.Min(firstList[i][1], secondList[j][1]);
                // Check if there is an intersection
                if (startMax <= endMin)
                {
                    result.Add(new int[] { startMax, endMin });
                }
                // Move to the next interval in the list that ends first
                if (firstList[i][1] < secondList[j][1])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return [.. result];
        }

        //759. Employee Free Time
        public static int[][] EmployeeFreeTime(int[][] schedules)
        {
            int len = schedules.Length;
            if (len == 0)
            {
                return [];
            }
            Array.Sort(schedules, (a, b) => a[0].CompareTo(b[0]));
            var merged = new List<int[]>
            {
                schedules[0]
            };


            for (int i = 1; i < len; i++)
            {
                if (schedules[i][0] <= merged[^1][1])
                {
                    merged[^1][1] = Math.Max(merged[^1][1], schedules[i][1]);
                }
                else
                {
                    merged.Add(schedules[i]);
                }
            }

            var freeTime = new List<int[]>();
            for (int i = 1; i < merged.Count; i++)
            {
                freeTime.Add([merged[i - 1][1], merged[i][0]]);
            }

            return [.. freeTime];
        }
    }
}
