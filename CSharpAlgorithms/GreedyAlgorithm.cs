using System.Diagnostics.CodeAnalysis;

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

    /// <summary>
    /// 121. Best Time to Buy and Sell Stock
    /// Calculates the maximum profit that can be achieved from a single buy and sell operation on a sequence of stock prices.
    /// </summary>
    /// <remarks>The method assumes that only one buy and one sell operation are allowed, and the buy must
    /// occur before the sell. If prices decrease or remain constant, the result will be 0.</remarks>
    /// <param name="prices">An array of integers representing the stock price on each day. The array must not be null.</param>
    /// <returns>The maximum profit that can be achieved. Returns 0 if no profit is possible or if the array is empty.</returns>
    public static int BuySellStock(int[] prices)
    {
        if (prices.Length == 0) return 0;

        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
        }
        return maxProfit; 
    }
}
