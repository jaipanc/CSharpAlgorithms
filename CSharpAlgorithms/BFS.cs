using TreeNode = CSharpAlgorithms.DFS.Treenode;

namespace CSharpAlgorithms
{
    public class BFS
    {
        /// <summary>
        /// 102. Binary Tree Level Order Traversal
        /// </summary>
        /// <param name="root">Binary Tree</param>
        /// <returns></returns>
        public static List<List<int>> LevelOrder(TreeNode root)
        {
            if (root is null) return [];

            List<List<int>> result = [];
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var currentLevel = queue.Count;
                List<int> currList = [];

                for (int i = 0; i < currentLevel; i++)
                {
                    var curr = queue.Dequeue();
                    currList.Add(curr.val);

                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }
                }
                result.Add(currList);
            }
            return result;
        }

        /// <summary>
        /// 199. Binary Tree Right Side View
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<int> RightSideView(TreeNode root)
        {
            if (root is null) return [];
            Queue<TreeNode> queue = [];
            List<int> nodes = [];
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelCount = queue.Count;

                for (int i = 0; i < levelCount; i++)
                {
                    var node = queue.Dequeue();
                    if (i == levelCount - 1)
                    {
                        nodes.Add(node.val);
                    }

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return nodes;
        }
    }
}
