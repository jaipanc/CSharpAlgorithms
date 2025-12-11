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
    }
}
