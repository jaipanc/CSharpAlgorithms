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
    }
}