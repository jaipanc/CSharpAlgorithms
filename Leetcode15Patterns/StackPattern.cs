using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
    }
}
