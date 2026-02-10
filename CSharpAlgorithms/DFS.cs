using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static CSharpAlgorithms.DFS;

namespace CSharpAlgorithms
{
    public class DFS
    {
        /// <summary>
        /// Binary Tree Node
        /// </summary>
        public class Treenode
        {
            public int val;
            public Treenode left;
            public Treenode right;

            public Treenode(int val = 0, Treenode left = null, Treenode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class GraphNode
        {
            public int Value;
            public int Id;
            public GraphNode[] Neighbors;
        }

        /// <summary>
        /// Given the root of a binary tree and an integer targetSum return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
        /// </summary>
        /// <param name="root">binary tree</param>
        /// <param name="target">target sum</param>
        /// <returns>true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.</returns>
        public static bool HasPathSum(Treenode root, int target)
        {
            if (root is null)
            {
                return false;
            }

            if (root.left is null && root.right is null)
            {
                return target == root.val;
            }

            int remaining = target - root.val;

            return HasPathSum(root.left, remaining) || HasPathSum(root.right, remaining);
        }

        /// <summary>
        /// Given the root of a binary tree, return its maximum depth.
        /// </summary>
        /// <param name="node">Binary Tree</param>
        /// <returns></returns>
        public static int MaxDepth(Treenode node)
        {
            if (node is null)
            {
                return 0;
            }

            int left = MaxDepth(node.left);
            int right = MaxDepth(node.right);
            return Math.Max(left, right) + 1;
        }

        /// <summary>
        /// 1448. Count Good Nodes in Binary Tree
        /// Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
        /// </summary>
        /// <param name="root">Binary Tree</param>
        /// <returns></returns>
        public static int GoodNodes(Treenode root)
        {
            return DfsHelper(root, int.MinValue);
            static int DfsHelper(Treenode node, int maxValue)
            {
                if (node is null)
                {
                    return 0;
                }

                var count = 0;
                if (node.val >= maxValue)
                {
                    count++;
                    maxValue = node.val;
                }

                int left = DfsHelper(node.left, maxValue);
                int right = DfsHelper(node.right, maxValue);

                return left + right + count;
            }
        }

        /// <summary>
        /// Given the root of a binary tree, determine if it is a valid binary search tree (BST).
        /// </summary>
        /// <param name="node">Binary Search Tree</param>
        /// <returns></returns>
        public static bool ValidateBinarySearchTree(Treenode node) => ValidateHelper(node, long.MinValue, long.MaxValue);

        static bool ValidateHelper(Treenode node, long min, long max)
        {
            if (node is null)
            {
                return true;
            }

            if (node.val <= min || node.val >= max)
            {
                return false;
            }

            return ValidateHelper(node.left, min, node.val) && ValidateHelper(node.right, node.val, max);
        }

        /// <summary>
        /// Given the root of a binary tree, return the sum of every tree node's tilt.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int FindTitl(Treenode node)
        {
            int totalTilt = 0;
            TiltHelper(node);
            return totalTilt;

            int TiltHelper(Treenode root)
            {
                if (root is null)
                {
                    return 0;
                }

                int leftSum = TiltHelper(root.left);
                int rightSum = TiltHelper(root.right);

                totalTilt += Math.Abs(leftSum - rightSum);

                return leftSum + rightSum + root.val;
            }
        }

        /// <summary>
        /// 543. Diameter of Binary Tree
        /// </summary>
        /// <param name="root">Binary Tree</param>
        /// <returns>Diameter value</returns>
        public static int DiameterOfBinaryTree(Treenode root)
        {
            int maxDiameter = 0;
            HelperDFS(root);
            return maxDiameter;

            // Two different approaches here 
            // 1. Heights as Edges ( leaf node itself height considered as 0 )
                // Return -1 if node is null
                // Diameter = l + r + 2
            // 2. Heights as Nodes ( leaf node itself height considered as 1 )
                // Return 0 if node is null
                // Diameter = l + r
            int HelperDFS(Treenode node)
            {
                if (node is null)
                    return -1;

                int left = HelperDFS(node.left);
                int right = HelperDFS(node.right);

                maxDiameter = Math.Max(maxDiameter, left + right + 2);

                return Math.Max(left, right) + 1;
            }
        }

        /// <summary>
        /// Given the root of a binary tree and an integer targetSum, 
        /// return all root-to-leaf paths where the sum of the node values in the path equals targetSum. 
        /// Each path should be returned as a list of the node values, not node references.
        /// </summary>
        /// <param name="root">Binary Tree</param>
        /// <param name="targetSum">Expected Sum</param>
        /// <returns>List of Paths</returns>
        public static IList<IList<int>> PathSumII(Treenode root, int targetSum)
        {
            var path = new List<int>();
            var result = new List<IList<int>>();
            HelperPathSum(root, targetSum, path, result);
            return result;

            void HelperPathSum(Treenode node, int remainingSum, List<int> path, List<IList<int>> result)
            {
                if (node == null)
                    return;

                path.Add(node.val);
                remainingSum -= node.val;

                if (node.left == null && node.right == null && remainingSum == 0)
                {
                    result.Add([.. path]);
                }

                HelperPathSum(node.left, remainingSum, path, result);
                HelperPathSum(node.right, remainingSum, path, result);

                path.RemoveAt(path.Count - 1);
            }
        }

        /// <summary>
        /// 687. Longest Univalue Path
        /// Given the root of a binary tree, return the length of the longest path, where each node in the path has the same value. 
        /// This path may or may not pass through the root.
        /// </summary>
        /// <param name="root">Binary Tree</param>
        /// <returns></returns>
        public static int LongestUnivaluePath(Treenode root)
        {
            int bestPath = 0;
            HelperLongestUnivaluePath(root);
            return bestPath;

            int HelperLongestUnivaluePath(Treenode node)
            {
                if (node is null)
                    return 0;

                // At each node we will calculate following 
                // 1. Maximum path length from left and right which satisfies the condition of value equal to its parent i.e. Math.Max(leftPath,rightPath)
                // 2. Path value through this node i.e. leftPath + rightPath
                int leftDown = HelperLongestUnivaluePath(node.left);
                int rightDown = HelperLongestUnivaluePath(node.right);

                int leftPath = 0;
                int rightPath = 0;

                if (node.left != null && node.left.val == node.val)
                {
                    leftPath = leftDown + 1;
                }

                if (node.right != null && node.right.val == node.val)
                {
                    rightPath = rightDown + 1;
                }

                bestPath = Math.Max(bestPath, leftPath + rightPath);

                return Math.Max(leftPath , rightPath);
            }
        }

        /// <summary>
        /// Given an integer n which represents the number of nodes in a graph, and a list of edges edges, where edges[i] = [ui, vi] represents a bidirectional edge between nodes ui and vi, 
        /// write a function to return the adjacency list representation of the graph as a dictionary. 
        /// The keys of the dictionary should be the nodes, and the values should be a list of the nodes each node is connected to
        /// </summary>
        /// <param name="nodes">number of nodes</param>
        /// <param name="edges">edges between nodes</param>
        /// <returns>adjacency list representation of the graph as a dictionary</returns>
        public static Dictionary<int, List<int>> BuildAdjacencyList(int nodes, int[][] edges)
        {
            Dictionary<int, List<int>> adjList = [];
            for (int i = 0; i < nodes; i++)
            {
                adjList[i] = [];
            }

            foreach (var edge in edges)
            {
                var u = edge[0];
                var v = edge[1];
                adjList[u].Add(v);
                adjList[v].Add(u);
            }
            return adjList;
        }

        /// <summary>
        /// Given a reference to a variable node which is part of an undirected, connected graph, write a function to return a copy of the graph as an adjacency list in dictionary form. 
        /// The keys of the adjacency list are the values of the nodes, and the values are the neighbors of the nodes.
        /// </summary>
        /// <param name="node">Int Graph Node</param>
        /// <returns>Adj List in Dictionary Form.</returns>
        public static Dictionary<int, List<int>> CloneGraph(GraphNode node)
        {
            Dictionary<int, List<int>> adjList = [];
            if (node != null)
            {
                DFSHelper(node, adjList);
            }
            return adjList;

            void DFSHelper(GraphNode root, Dictionary<int, List<int>> list)
            {
                if (list.ContainsKey(root.Value)) return;

                List<int> neighboursList = [];

                foreach (var n in root.Neighbors)
                {
                    neighboursList.Add(n.Value);
                }

                list[root.Value] = neighboursList;

                foreach (var n in root.Neighbors)
                {
                    DFSHelper(n, list);
                }
            }
        }

        /// <summary>
        /// You are given an integer n and a list of undirected edges where each entry in the list is a pair of integers representing an edge between nodes 1 and n. 
        /// You have to write a function to check whether these edges make up a valid tree.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="egdes"></param>
        /// <returns></returns>
        public static bool ValidTree(int n, int[][] egdes)
        {
            if (egdes.Length != n - 1) return false;

            var adjList = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                adjList[i] = [];
            }

            foreach (var edge in egdes)
            {
                adjList[edge[0]].Add(edge[1]);
                adjList[edge[1]].Add(edge[0]);
            }

            bool[] visited = new bool[n];

            bool HasCycle(int node, int parent)
            {
                visited[node] = true;

                foreach (var nei in adjList[node])
                {
                    if (!visited[nei])
                    {
                        if (HasCycle(nei, node)) return true;
                    }
                    else if (nei != parent)
                    {
                        return true;
                    }
                }
                return false;
            }

            if (HasCycle(0, -1)) return false;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i]) return false;
            }

            return true;
        }

        /// <summary>
        /// 733. Flood Fill
        /// You are given an image represented by an m x n grid of integers image, where image[i][j] represents the pixel value of the image. 
        /// You are also given three integers sr, sc, and color. Your task is to perform a flood fill on the image starting from the pixel image[sr][sc].
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sc"></param>
        /// <param name="sr"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int[][] FloodFill(int[][] image, int sc, int sr, int color)
        {
            int rows = image.Length;
            int cols = image[0].Length;
            int originalColor = image[sr][sc];

            if (originalColor == color)
            {
                return image;
            }
            FloodFillDFSHelper(image, sr, sc, originalColor);
            return image;

            void FloodFillDFSHelper(int[][] image, int r, int c, int originalColor)
            {
                if (image[r][c] == originalColor)
                {
                    image[r][c] = color;

                    if (r >= 1) FloodFillDFSHelper(image, r - 1, c, originalColor);
                    if (r + 1 < rows) FloodFillDFSHelper(image, r + 1, c, originalColor);
                    if (c >= 1) FloodFillDFSHelper(image, r, c - 1, originalColor);
                    if (c + 1 < cols) FloodFillDFSHelper(image, r, c + 1, originalColor);
                }
                return;
            }
        }
    }
}
