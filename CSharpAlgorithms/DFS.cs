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
    }
}
