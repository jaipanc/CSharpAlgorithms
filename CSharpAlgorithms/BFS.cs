using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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

        /// <summary>
        /// 103. Binary Tree Zigzag Level Order Traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root is null) return [];

            List<IList<int>> result = [];
            Queue<TreeNode> queue = [];
            queue.Enqueue(root);
            bool leftToRight = true;

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;
                LinkedList<int> levelList = [];

                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();

                    if (leftToRight) 
                        levelList.AddLast(node.val);
                    else 
                        levelList.AddFirst(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add([.. levelList]);
                leftToRight = !leftToRight;
            }
            return result;
        }

        /// <summary>
        /// 662. Maximum Width of Binary Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int WidthOfBinaryTree(TreeNode root)
        {
            if (root is null) return 0;

            Queue<(TreeNode node, long pos)> queue = [];
            queue.Enqueue((root, 0));
            int maxWidth = 0;

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;
                long leftPos = queue.Peek().pos;
                long rightPos = -1;

                for (int i = 0; i < levelSize; i++)
                {
                    var (node, pos) = queue.Dequeue();
                    if (i == levelSize - 1)
                    {
                        rightPos = pos;
                    }

                    if (node.left != null) queue.Enqueue((node.left, pos * 2));
                    if (node.right != null) queue.Enqueue((node.right, pos * 2 + 1));
                }
                maxWidth = Math.Max(maxWidth, (int)(rightPos - leftPos + 1));
            }
            return maxWidth;
        }

        /// <summary>
        /// 1197. Minimum Knight Moves
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int MinimumKnightMoves(int x, int y)
        {
            int[][] directions =
            [
                [2,1],[2,-1],[-2,1],[-2,-1],
                [1,2],[1,-2],[-1,2],[-1,-2]
            ];

            HashSet<string> visited = ["0,0"];
            Queue<int[]> queue = [];
            queue.Enqueue([0, 0, 0]);

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                int cx = curr[0], cy = curr[1], moves = curr[2];

                if (x == cx && y == cy) return moves;

                foreach (var dir in directions)
                {
                    int nx = cx + dir[0], ny = cy + dir[1]; string pos = $"{nx},{ny}";

                    if (!visited.Contains(pos))
                    {
                        visited.Add(pos);
                        queue.Enqueue([nx, ny, moves + 1]);
                    }
                }
            }
            return -1;
        }
    }
}
