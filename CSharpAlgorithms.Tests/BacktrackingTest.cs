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
