namespace CSharpAlgorithms
{
    public class StackPattern
    {
        public static bool IsValid(string s)
        {
            var bag = new Stack<char>();
            var mapping = new Dictionary<char, char> { { ')', '(' }, { ']', '[' }, { '}', '{' } };

            foreach (var c in s)
            {
                // If the current character is a closing bracket i.e. any of the defined keys in Dictionary.    
                if (mapping.ContainsKey(c))
                {
                    //it checks if it is the corresponding closing bracket for the bracket at the top of the stack.
                    if (bag.Count == 0 || bag.Peek() != mapping[c])
                    {
                        // If it is not, the input string is invalid.
                        return false;
                    }
                    // If it is, the bracket is popped from the stack, and the iteration continues.
                    bag.Pop();
                }
                else
                {
                    //If the current character is an opening bracket, it is pushed onto the stack.
                    bag.Push(c);
                }
            }
            return bag.Count == 0;
        }

        //394. Decode String
        public static string DecodeString(string s)
        {
            const char OpeningBracket = '[';
            const char ClosingBracket = ']';
            var strStack = new Stack<string>();
            var numStack = new Stack<int>();
            var currString = string.Empty;
            var currNumber = 0;
            foreach (char c in s)
            {
                if (c.Equals(OpeningBracket))
                {
                    strStack.Push(currString);
                    numStack.Push(currNumber);
                    currString = string.Empty;
                    currNumber = 0;
                }
                else if (c.Equals(ClosingBracket))
                {
                    var num = numStack.Pop();
                    var str = strStack.Pop();
                    currString = str + string.Concat(Enumerable.Repeat(currString, num));
                }
                else if (Char.IsDigit(c))
                {
                    currNumber = currNumber * 10 + (c - '0');
                }
                else
                {
                    currString += c;
                }
            }
            return currString;
        }

        //Monotonic stack 
        public static int[] NextGreaterNumber(int[] nums)
        {
            var result = new int[nums.Length];
            Array.Fill(result, -1);
            var stack = new Stack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count != 0 && nums[i] > nums[stack.Peek()])
                {
                    var index = stack.Pop();
                    result[index] = nums[i];
                }
                stack.Push(i);
            }
            return result;
        }

        //Monotonic stack 
        public static int[] NextGreaterNumber(int[] num1, int[] num2)
        {
            var result = new int[num1.Length];
            Array.Fill(result, -1);
            var stack = new Stack<int>();
            var map = new Dictionary<int, int>();

            foreach (var current in num2)
            {
                while (stack.Count > 0 && current > stack.Peek())
                {
                    map[stack.Pop()] = current;
                }
                stack.Push(current);
            }

            for (int i = 0; i < num1.Length; i++)
            {
                if (map.TryGetValue(num1[i], out int value))
                {
                    result[i] = value;
                }
            }
            return result;
        }

        // Monotonic Decreasing Stack - 739. Daily Temperatures
        public static int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            var stack = new Stack<int>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    var index = stack.Pop();
                    result[index] = i - index;
                }
                stack.Push(i);
            }
            return result;
        }

        /// <summary>
        /// 32. Longest Valid Parentheses
        /// Finds the length of the longest substring of well-formed parentheses in the specified string.
        /// </summary>
        /// <remarks>A valid substring consists of properly matched opening and closing parentheses. This
        /// method ignores any characters other than '(' and ')'.</remarks>
        /// <param name="s">The input string to evaluate for valid parentheses substrings. May be empty but cannot be null.</param>
        /// <returns>The length of the longest contiguous substring containing valid, well-formed parentheses. Returns 0 if no
        /// such substring exists.</returns>
        public static int LongestValidParentheses(string s)
        {
            int maxLength = 0;
            var stack = new Stack<int>();
            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (ch == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if(stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    maxLength = Math.Max(maxLength, i - stack.Peek());
                }
            }
            return maxLength;
        }

        /// <summary>
        /// 84. Largest Rectangle in Histogram
        /// Calculates the area of the largest rectangle that can be formed within a histogram represented by the
        /// specified bar heights.
        /// </summary>
        /// <param name="heights">An array of non-negative integers representing the heights of the histogram's bars. Each element corresponds
        /// to the height of a bar at that position. Cannot be null.</param>
        /// <returns>The area of the largest rectangle that can be formed within the histogram. Returns 0 if the array is empty.</returns>
        public static int LargestRectangleArea(int[] heights)
        {
            int maxArea = 0;
            var stack = new Stack<int>();
            int i = 0;

            while (i < heights.Length)
            {
                if(stack.Count == 0 || heights[i] >= heights[stack.Peek()])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    int top = stack.Pop();
                    int right = i - 1;
                    int left = stack.Count == 0 ? -1 : stack.Peek();
                    int area = heights[top] * (right - left);
                    maxArea = Math.Max(maxArea, area);
                }
            }

            while (stack.Count > 0)
            {
                int top = stack.Pop();
                int right = i - 1;
                int left = stack.Count == 0 ? i : stack.Peek();
                int area = heights[top] * (right - left);
                maxArea = Math.Max(maxArea, area);
            }
            return maxArea;
        }
    }
}
