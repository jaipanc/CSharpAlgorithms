namespace CSharpAlgorithms;

public class Trie
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = [];
        public bool isEnd = false;
    }

    /// <summary>
    /// Finds all words in the trie that start with the specified prefix.
    /// </summary>
    /// <param name="word">The prefix to search for. Only words in the trie that begin with this prefix will be returned.</param>
    /// <returns>A list of strings containing all words that start with the specified prefix. Returns an empty list if no such
    /// words are found.</returns>
    public static List<string> PrefixMatching(TrieNode node, string word)
    {
        foreach (char c in word)
        {
            if(!node.children.ContainsKey(c))
            {
                return [];
            }
            node = node.children[c];
        }

        List<string> result = [];
        DfsHelper(node, word, result);

        void DfsHelper(TrieNode currentNode, string currentWord, List<string> result)
        {
            if (currentNode.isEnd)
            {
                result.Add(currentWord);
            }

            foreach (var pair in currentNode.children)
            {
                DfsHelper(pair.Value, currentWord + pair.Key, result);
            }
        }

        return result;
    }

}

