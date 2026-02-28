
using System.Threading.Tasks.Sources;

namespace CSharpAlgorithms;

public class Backtracking
{
    /// <summary>
    /// 79. Word Search
    /// </summary>
    /// <param name=""></param>
    /// <param name="word"></param>
    /// <returns></returns>
    public static bool WordSearch(char[][] board, string word)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        bool BfsHelper(int r, int c, int index)
        {
            if (index == word.Length) return true;

            if (r < 0 || c < 0 || r >= rows || c >= cols || board[r][c] != word[index]) return false;

            var temp = board[r][c];
            board[r][c] = '#';

            bool found = BfsHelper(r + 1, c, index + 1) || BfsHelper(r - 1, c, index + 1) || BfsHelper(r, c + 1, index + 1) || BfsHelper(r, c - 1, index + 1);
            board[r][c] = temp;
            return found;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (BfsHelper(i, j, 0)) return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Generates all possible letter combinations that the specified digit string could represent on a telephone
    /// keypad.
    /// </summary>
    /// <remarks>Each digit is mapped to its corresponding set of letters according to the classic telephone
    /// keypad layout (e.g., '2' maps to 'abc', '3' to 'def'). The order of combinations in the returned list is not
    /// guaranteed. If the input contains digits outside the range 2–9, those digits are ignored.</remarks>
    /// <param name="digits">A string containing digits from 2 to 9. Each digit maps to a set of letters as on a standard telephone keypad.
    /// Cannot be null.</param>
    /// <returns>A list of strings containing all possible letter combinations for the input digits. Returns an empty list if the
    /// input is empty.</returns>
    public static IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits)) return [];

        Dictionary<char, string> phoneMap = new()
        {
            {'2', "abc"},   // Digit 2 maps to letters a, b, c
            {'3', "def"},   // Digit 3 maps to letters d, e, f
            {'4', "ghi"},   // And so on...
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        List<string> result = [];
        BackTrackHeper(digits, 0, "", result, phoneMap);

        void BackTrackHeper(string digits, int index, string currentCombination, List<string> result, Dictionary<char, string> map)
        {
            if (index == digits.Length)
            {
                result.Add(currentCombination);
                return;
            }

            var digit = digits[index];
            var letters = map[digit];

            foreach (var letter in letters)
            {
                BackTrackHeper(digits, index + 1, currentCombination + letter, result, map);
            }
        }

        return result;
    }

    /// <summary>
    /// 78.Subsets - Generates all possible subsets of the specified integer array.
    /// </summary>
    /// <remarks>The order of subsets in the returned list is not guaranteed. This method can be used to
    /// enumerate the power set of the input array.</remarks>
    /// <param name="nums">An array of integers for which to generate subsets. Cannot be null.</param>
    /// <returns>A list of lists, where each inner list represents a subset of the input array. The list includes the empty
    /// subset and all possible combinations of the input elements.</returns>
    public static IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> result = [];
        Backtrack(0, []);
        return result;

        void Backtrack(int index, List<int> curr)
        {
            result.Add([.. curr]); // add subset at every step

            for (int i = index; i < nums.Length; i++)
            {
                if (i > index && nums[i] == nums[i - 1]) continue; // skip duplicates
                curr.Add(nums[i]);
                Backtrack(i + 1, curr);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }

    /// <summary>
    /// 22. Generate Parentheses - Generates all combinations of well-formed parentheses for a given number of pairs.
    /// </summary>
    /// <param name="n">The number of pairs of parentheses to generate. Must be greater than or equal to 0.</param>
    /// <returns>A list of strings, each representing a unique combination of well-formed parentheses. Returns an empty list if n
    /// is 0.</returns>
    public static IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = [];
        Backtrack(0,0,"");
        return result;

        void Backtrack(int open, int close, string currentString)
        {
            if(currentString.Length == 2* n)
            {
                result.Add(currentString);
                return;
            }

            if (open < n) Backtrack(open + 1, close, currentString + "(");
            if (close < open) Backtrack(open, close + 1, currentString + ")");
        }
    }
}
