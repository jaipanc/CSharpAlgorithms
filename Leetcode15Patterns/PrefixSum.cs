namespace Leetcode15Patterns
{
    static public class PrefixSum
    {
        /// <summary>
        /// Find the sum of elements between indices a and b (inclusive) in the given array using Prefix Sum technique.
        /// </summary>
        /// <param name="nums">Input Array</param>
        /// <param name="a">First Index</param>
        /// <param name="b">Second Index</param>
        /// <returns></returns>
        public static int CalculatePrefixSum(int[] nums, int a, int b)
        {
            int n = nums.Length;
            int[] prefixSums = new int[n + 1];
            prefixSums[0] = 0;
            // Time Complexity: O(n) to build the prefix sums , for subarray O(1) , Space Complexity: O(n) for the prefix sums array
            for (int i = 0; i < n; i++)
            {
                prefixSums[i + 1] = prefixSums[i] + nums[i];
            }
            return prefixSums[b + 1] - prefixSums[a];
        }

        // Subarray Sum Equals K
        public static int SubarraySumEqualsK(int[] nums, int k)
        {
            int count = 0;
            Dictionary<int, int> prefixMap = new()
            {
                [0] = 1// Base case: one way to have a prefix sum of 0
            };
            int currentPrefixSum = 0;

            foreach (var n in nums)
            {
                currentPrefixSum += n;
                if (prefixMap.TryGetValue(currentPrefixSum - k, out int foundValue ))
                {
                    count += foundValue;
                }

                prefixMap.TryAdd(currentPrefixSum, 0); //Add new key if it does not exist
                prefixMap[currentPrefixSum]++;// now at this we are sure that the key is added if it was not there , increament works for both cases even if key existed before.

            }
            return count;
        }

        // Count Vowels in String with given queries in formart of substring array
        public static int[] CountVowels(string word, int[][] queries)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var prefixCount = new int[word.Length + 1];

            for (int i = 0; i < word.Length; i++)
            {
                bool isVowel = vowels.Contains(word[i]);
                prefixCount[i + 1] = prefixCount[i] + (isVowel ? 1 : 0); // prefixCount[i] will be zeo by default
            }

            var result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                int numVowels = prefixCount[right + 1] - prefixCount[left];
                result[i] = numVowels;
            }

            return result;
        }

        // LC-2559 Count Vowel Strings in Ranges
        public static int[] VowelStrings(string[] words, int[][] queries)
        {
            char[] vowels = ['a', 'e', 'i', 'o', 'u'];
            var prefixSum = new int[words.Length + 1];

            for (int i = 0; i < words.Length; i++)
            {
                bool isVowel = vowels.Contains(words[i][0]) && vowels.Contains(words[i][^1]);
                prefixSum[i + 1] = prefixSum[i] + (isVowel ? 1 : 0);
            }

            var result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                int vowelCounts = prefixSum[right + 1] - prefixSum[left];
                result[i] = vowelCounts;
            }

            return result;
        }
    }
}
