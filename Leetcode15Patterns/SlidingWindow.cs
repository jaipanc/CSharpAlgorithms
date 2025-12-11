namespace Leetcode15Patterns
{
    public class SlidingWindow
    {
        public static int FruitsIntoBasket(int[] fruits)
        {
            int start = 0;
            Dictionary<int, int> Basket = [];
            int mxFruit = 0;

            for (int end = 0; end < fruits.Length; end++)
            {
                if (Basket.TryGetValue(end, out int value))
                {
                    Basket[end] = value + 1;
                }
                else
                {
                    Basket[end] = 1;
                }
            }

            while(Basket.Count > 2)
            {
                var startFruit = Basket[start];
            }
        }
    }
}
