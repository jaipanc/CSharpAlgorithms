namespace CSharpAlgorithms.Tests;

public class BacktrackingTest
{
    [Theory]
    [MemberData(nameof(WordSearchTestCases))]
    public void TestWordSearch(char[][] board, string word, bool exptected)
    {
        var result = Backtracking.WordSearch(board, word);
        Assert.Equal(exptected, result);
    }

    [Theory]
    [MemberData(nameof(LetterCombinationsTestCases))]
    public void TestLetterCombinations(string digits, IList<string> expected)
    {
        var result = Backtracking.LetterCombinations(digits);
        Assert.Equivalent(expected, result);
    }

    [Theory]
    [MemberData(nameof(SubsetsTestData))]
    public void TestSubsets(int[] nums, IList<IList<int>> expected)
    {
        var result = Backtracking.Subsets(nums);
        Assert.Equivalent(expected, result, true);
    }

    [Theory]
    [MemberData(nameof(GenerateParenthesisTestData))]
    public void TestGenerateParenthesis(int n, IList<string> expeceted)
    {
        var result = Backtracking.GenerateParenthesis(n);
        Assert.Equivalent(expeceted, result);
    }

    [Theory]
    [MemberData(nameof(CombinationSumTestData))]
    public void TestCombinationSum(int[] canadidates, int target, IList<IList<int>> expected)
    {
        var result = Backtracking.CombinationSum(canadidates, target);
        Assert.Equivalent(expected, result);
    }

    public static TheoryData<int[], int, IList<IList<int>>> CombinationSumTestData => new()
    {
        {
            [2,3,6,7],7,[[2,2,3],[7]]
        },
        {
            [2,3,5],8,[[2,2,2,2],[2,3,3],[3,5]]
        },
        {
            [2],1,[]
        },
        {
            [1],2,[[1,1]]
        }
    };


    public static TheoryData<int, IList<string>> GenerateParenthesisTestData => new()
    {
        {
            1,["()"]
        },
        {
            2,["(())","()()"]
        },
        {
            3,["((()))","(()())","(())()","()(())","()()()"]
        },
        {
            4, 
            [
        "(((())))",
        "((()()))",
        "((())())",
        "((()))()",
        "(()(()))",
        "(()()())",
        "(()())()",
        "(())(())",
        "(())()()",
        "()((()))",
        "()(()())",
        "()(())()",
        "()()(())",
        "()()()()"
            ]
        },
        {
            5,[
        "((((()))))",
        "(((()())))",
        "(((())()))",
        "(((()))())",
        "(((())))()",
        "((()(())))",
        "((()()()))",
        "((()())())",
        "((()()))()",
        "((())(()))",
        "((())()())",
        "((())())()",
        "((()))(())",
        "((()))()()",
        "(()((())))",
        "(()(()()))",
        "(()(())())",
        "(()(()))()",
        "(()()(()))",
        "(()()()())",
        "(()()())()",
        "(()())(())",
        "(()())()()",
        "(())((()))",
        "(())(()())",
        "(())(())()",
        "(())()(())",
        "(())()()()",
        "()(((())))",
        "()((()()))",
        "()((())())",
        "()((()))()",
        "()(()(()))",
        "()(()()())",
        "()(()())()",
        "()(())(())",
        "()(())()()",
        "()()((()))",
        "()()(()())",
        "()()(())()",
        "()()()(())",
        "()()()()()"
            ]
        }
    };

    public static TheoryData<int[], IList<IList<int>>> SubsetsTestData => new()
    {
        // Empty array
        { Array.Empty<int>(), new List<IList<int>> { new List<int> { } } },

        // Single element
        { new int[] { 1 }, new List<IList<int>> { new List<int> { }, new List<int> { 1 } } },

        // Two elements
        { new int[] { 1, 2 }, new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 1, 2 }
            }
        },

        // Three elements
        { new int[] { 1, 2, 3 }, new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3 }
            }
        },

        // Negative numbers
        { new int[] { -1, 2 }, new List<IList<int>>
            {
                new List<int> { },
                new List<int> { -1 },
                new List<int> { 2 },
                new List<int> { -1, 2 }
            }
        },

        // Duplicate elements
        { new int[] { 1, 2, 2 }, new List<IList<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 1, 2 },
                new List<int> { 2, 2 },
                new List<int> { 1, 2, 2 }
            }
        }
    };

    public static TheoryData<string, IList<string>> LetterCombinationsTestCases => new()
    {
        // Test case 1: Empty string
        { "", [] },

        // Test case 2: Single digit
        { "2", ["a", "b", "c"] },

        // Test case 3: Two digits (example from problem)
        { "23", ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"] },

        // Test case 4: Three digits
        { "234", ["adg", "adh", "adi", "aeg", "aeh", "aei", "afg", "afh", "afi",
                 "bdg", "bdh", "bdi", "beg", "beh", "bei", "bfg", "bfh", "bfi",
                 "cdg", "cdh", "cdi", "ceg", "ceh", "cei", "cfg", "cfh", "cfi"] },

        // Test case 5: Digit with 4 letters (7)
        { "7", ["p", "q", "r", "s"] },

        // Test case 6: Multiple digits including 7 and 9
        { "79", ["pw", "px", "py", "pz", "qw", "qx", "qy", "qz",
                 "rw", "rx", "ry", "rz", "sw", "sx", "sy", "sz"] },

        // Test case 7: All same digit
        { "22", ["aa", "ab", "ac", "ba", "bb", "bc", "ca", "cb", "cc"] },

        // Test case 8: Longer combination
        { "35", ["dj", "dk", "dl", "ej", "ek", "el", "fj", "fk", "fl"] }
    };

    public static TheoryData<char[][], string, bool> WordSearchTestCases()
    {
        var testCases = new TheoryData<char[][], string, bool>
        {
            // Test Case 1: Basic successful case - ABCCED
            {
            [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']],
                "ABCCED",
                true
            },

            // Test Case 2: Another successful case - SEE
            {
            [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']],
                "SEE",
                true
            },

            // Test Case 3: Failed case - ABCB
            {
            [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']],
                "ABCB",
                false
            },

            // Test Case 4: Single cell success
            {
            [['A']],
                "A",
                true
            },

            // Test Case 5: Single cell failure
            {
            [['A']],
                "B",
                false
            },

            // Test Case 6: Word longer than board
            {
            [['A', 'B'], ['C', 'D']],
                "ABCDE",
                false
            },

            // Test Case 7: Reusing cells should fail
            {
            [['A', 'A'], ['A', 'A']],
                "AAAAA",
                false
            },

            // Test Case 8: Diagonal movement not allowed
            {
            [['A', 'B', 'C'], ['D', 'E', 'F'], ['G', 'H', 'I']],
                "ABEI",
                false
            },

            // Test Case 9: Valid path with turns
            {
            [['A', 'B', 'C'], ['D', 'E', 'F'], ['G', 'H', 'I']],
                "ABEDGHI",
                true
            },

            // Test Case 10: Complex successful case
            {
            [['S', 'E', 'E', 'S'], ['E', 'S', 'E', 'E'], ['S', 'E', 'E', 'S']],
                "SEES",
                true
            }
        };

        return testCases;
    }
}
