using TrieNode =  CSharpAlgorithms.Trie.TrieNode;
namespace CSharpAlgorithms.Tests;

public class TrieTest
{
    [Theory]
    [MemberData(nameof(PrefixTestData))]
    public void PrefixMatching_Should_Return_Correct_Words(string[] words, string prefix, string[] expected)
    {
        // Arrange
        var root = BuildTrie(words);

        // Act
        var result = Trie.PrefixMatching(root, prefix);

        // Assert
        Assert.Equivalent(expected, result);
    }

    public static TheoryData<string[], string, string[]> PrefixTestData => new()
    {
        // Basic matches
        { ["apple", "app", "apex"], "ap", ["apple", "app", "apex"] },

        // Exact word match + longer words
        { ["cat", "car", "cart"], "car", ["car", "cart"] },

        // No match
        { ["dog", "deer"], "ca", [] },

        // Single word
        { ["hello"], "he", ["hello"] },

        // Prefix is full word but no extensions
        { ["bat"], "bat", ["bat"] },

        // Multiple branches
        { ["a", "ab", "abc", "abd"], "a", ["a", "ab", "abc", "abd"] },

        // Deep branch
        { ["flow", "flower", "flight"], "fl", ["flow", "flower", "flight"] }
    };

    private static TrieNode BuildTrie(IEnumerable<string> words)
    {
        TrieNode root = new();

        foreach (var word in words)
        {
            var node = root;
            foreach (char c in word)
            {
                if (!node.children.ContainsKey(c))
                    node.children[c] = new TrieNode();

                node = node.children[c];
            }
            node.isEnd = true;
        }

        return root;
    }
}
