namespace Leetcode15Patterns
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
    }
}
