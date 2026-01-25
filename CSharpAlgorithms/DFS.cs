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
    }
}
