using System.Globalization;

namespace Leetcode15Patterns
{
    public class SlidingWindow
    {
        public static int FruitsIntoBasket(int[] fruits)
        {
            int start = 0;
            Dictionary<int, int> Basket = [];
            int maxFruitCount = 0;

            for (int end = 0; end < fruits.Length; end++)
            {
                Basket.TryAdd(fruits[end], 0);
                Basket[fruits[end]]++;

                while (Basket.Count > 2)
                {
                    Basket[fruits[start]]--;
                    if (Basket[fruits[start]] == 0)
                    {
                        Basket.Remove(fruits[start]);
                    }
                    start++;
                }
                maxFruitCount = Math.Max(maxFruitCount, end - start + 1);
            }

            return maxFruitCount;
        }

        // #3 : Longest Substring Without Repeating Characters
        public static int LongestUniqueSubString(string s)
        {
            int start = 0;
            Dictionary<char, int> KeyMap = [];
            int maxCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                KeyMap.TryAdd(s[i], 0);
                KeyMap[s[i]]++;

                while (KeyMap[s[i]] > 1)
                {
                    KeyMap[s[start]]--;
                    if (KeyMap[s[start]] == 0)
                    {
                        KeyMap.Remove(s[start]);
                    }
                    start++;
                }
                maxCount = Math.Max(maxCount, i - start + 1);
            }
            return maxCount;
        }

        //424. Longest Repeating Character Replacement
        public static int CharacterReplacement(string s, int k)
        {
            int maxFrequency = 0;
            int maxLength = 0;
            int start = 0;
            Dictionary<char, int> CharCount = [];

            for (int end = 0; end < s.Length; end++)
            {
                CharCount.TryAdd(s[end], 0);
                CharCount[s[end]]++;
                maxFrequency = Math.Max(maxFrequency, CharCount[s[end]]);

                while ((end - start + 1) - maxFrequency > k)
                {
                    CharCount[s[start]]--;
                    if (CharCount[s[start]] == 0)
                    {
                        CharCount.Remove(s[start]);
                    }
                    start++;
                }

                maxLength = Math.Max(maxLength, end - start + 1);
            }
            return maxLength;
        }

        // Maximum Sum of Subarrays of Size K
        public static int MaxSumSubArray(int[] nums, int k)
        {
            int start = 0;
            int windowSum = 0;
            int maxSum = 0;

            for (int end = 0; end < nums.Length; end++)
            {
                windowSum += nums[end];
                int windowSize = end - start + 1;
                if (windowSize == k)
                {
                    maxSum = Math.Max(maxSum, windowSum);
                    windowSum -= nums[start];
                    start++;
                }
            }
            return maxSum;
        }

        // 2461. Maximum Sum of Distinct Subarrays With Length K
        public static int MaximumSumOfDistinctSubArray(int[] nums, int k)
        {
            int start = 0;
            int currentSum = 0;
            int maxSum = 0;
            Dictionary<int, int> NumMap = [];

            for (int end = 0; end < nums.Length; end++)
            {
                currentSum += nums[end];
                NumMap.TryAdd(nums[end],0);
                NumMap[nums[end]]++;

                int windowSize = end - start + 1;

                if (windowSize == k)
                {
                    if (NumMap.Count == k)
                    {
                        maxSum = Math.Max(maxSum, currentSum);
                    }

                    currentSum -= nums[start];
                    NumMap[nums[start]]--;
                    if (NumMap[nums[start]] == 0)
                    {
                        NumMap.Remove(nums[start]);
                    }
                    start++;
                }
            }

            return maxSum;
        }


        /// <summary>
        /// 1423. Maximum Points You Can Obtain from Cards
        /// Given an array of integers representing the value of cards.
        /// write a function to calculate the maximum score you can achieve by selecting exactly k cards from either the beginning or the end of the array.
        /// </summary>
        /// <param name="cards">int array</param>
        /// <param name="k">number of cards to consider to find out the max score</param>
        /// <returns>int value indicating the max score</returns>
        public static int MaxScoreFromGivenCards(int[] cards, int k)
        {
            int arrayLength = cards.Length;            
            int TotalArraySum = 0;
            foreach (int item in cards)
            {
                TotalArraySum += item;
            }

            if (k >= arrayLength)
            {
                return TotalArraySum;
            }
            int start = 0;
            int currentSum = 0;
            int cardsWindow = arrayLength - k;
            int maxScore = 0;

            for (int end = 0; end < arrayLength; end++)
            {
                currentSum += cards[end];
                int currentWindow = end - start + 1;
                if (currentWindow == cardsWindow)
                {
                    maxScore = Math.Max(maxScore, TotalArraySum - currentSum);
                    currentSum -= cards[start];
                    start++;
                }
            }
            return maxScore;
        }
    }
}