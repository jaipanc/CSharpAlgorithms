namespace CSharpAlgorithms;

public class GreedyAlgorithm
{
    /// <summary>
    /// 455. Assign Cookies 
    /// Determines the maximum number of children that can be satisfied with the available cookies based on their greed factors.
    /// </summary>
    /// <remarks>Each child can receive at most one cookie, and each cookie can be assigned to at most one
    /// child. A child is satisfied if the size of the assigned cookie is greater than or equal to the child's greed
    /// factor.</remarks>
    /// <param name="greeds">An array of integers representing the minimum cookie size required to satisfy each child. Each element must be
    /// non-negative.</param>
    /// <param name="cookies">An array of integers representing the sizes of available cookies. Each element must be non-negative.</param>
    /// <returns>The maximum number of children that can be satisfied with the given cookies.</returns>
    public static int AssignCookies(int[] greeds, int[] cookies)
    {
        Array.Sort(greeds);
        Array.Sort(cookies);

        int count = 0;
        int i = 0, j = 0;
        while (i < greeds.Length && j < cookies.Length)
        {
            if (cookies[j] >= greeds[i])
            {
                count++;
                i++;
            }
            j++;
        }
        return count;
    }
}
