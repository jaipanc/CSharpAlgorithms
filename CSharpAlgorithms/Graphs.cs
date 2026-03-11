namespace CSharpAlgorithms;

public class Graphs
{
    /// <summary>
    /// 207. Course Schedule
    /// Determines whether it is possible to complete all courses given the specified prerequisites.
    /// </summary>
    /// <remarks>Use this method to check if a valid ordering exists for completing all courses based on the
    /// provided prerequisites. This is useful for scheduling or planning course completion in academic or training
    /// scenarios.</remarks>
    /// <param name="numCourses">The total number of courses to be considered. Must be a non-negative integer.</param>
    /// <param name="prerequisites">An array of prerequisite pairs, where each pair specifies a course and its prerequisite. Each element is an
    /// array of two integers: [course, prerequisite].</param>
    /// <returns>true if all courses can be completed without encountering cyclic dependencies; otherwise, false.</returns>
    public static bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] graph = new List<int>[numCourses];
        int[] indegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = [];
        }

        foreach (var p in prerequisites)
        {
            int course = p[0];
            int prereq = p[1];
            graph[prereq].Add(course);
            indegree[course]++;
        }

        Queue<int> queue = [];
        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        int completed = 0;
        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            completed++;

            foreach (var next in graph[course])
            {
                indegree[next]--;

                if (indegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return completed == numCourses;
    }
}

