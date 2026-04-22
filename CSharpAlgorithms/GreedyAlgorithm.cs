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

    /// <summary>
    /// 134. Gas Station - Determines the starting gas station index from which a vehicle can complete a full circuit around a circular
    /// route, given the amount of gas at each station and the cost to travel to the next station.
    /// </summary>
    /// <remarks>If there are multiple valid starting stations, the method returns the smallest index. Both
    /// input arrays must have the same length.</remarks>
    /// <param name="gas">An array where each element represents the amount of gas available at the corresponding station. The length of
    /// the array must match the length of the cost array.</param>
    /// <param name="cost">An array where each element represents the cost of gas required to travel from the corresponding station to the
    /// next station. The length of the array must match the length of the gas array.</param>
    /// <returns>The index of the starting gas station if the circuit can be completed; otherwise, -1 if it is not possible to
    /// complete the circuit.</returns>
    public static int CanCompleteCircle(int[] gas, int[] cost)
    {
        int totalGas = 0, totalCost = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            totalGas += gas[i];
            totalCost += cost[i];
        }

        if (totalCost > totalGas) return -1;

        int start = 0, fuel = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            if (fuel + gas[i] - cost[i] < 0)
            {
                // can't reach to next station
                // reset the start point from next station
                start = i + 1;
                fuel = 0;
            }
            else
            {
                fuel += gas[i] - cost[i];
            }
        }
        return start;
    }

    /// <summary>
    /// 55. Jump Game - Determines whether it is possible to reach the last index of the array by jumping according to the values in the
    /// array.
    /// </summary>
    /// <param name="nums">An array of non-negative integers where each element represents the maximum jump length from that position.
    /// Cannot be null.</param>
    /// <returns>true if the last index can be reached from the first index; otherwise, false.</returns>
    public static bool CanJump(int[] nums)
    {
        int maxReach = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach) return false;
            maxReach = Math.Max(maxReach, i + nums[i]);
        }
        return true;
    }
}
