using TreeNode = CSharpAlgorithms.DFS.Treenode;

namespace CSharpAlgorithms.Tests
{
    public class DFSTest
    {
        [Theory]
        [MemberData(nameof(HasPathSumTestData))]
        public void TestHasPathSum(TreeNode root, int target, bool expected)
        {
            var output = DFS.HasPathSum(root, target);
            Assert.Equal(expected, output);
        }

        [Theory]
        [MemberData(nameof(MaxDepthTestData))]
        public void TestMaxDepth(TreeNode root, int expected)
        {
            var output = DFS.MaxDepth(root);
            Assert.Equal(expected, output);
        }

        public static TheoryData<TreeNode, int> MaxDepthTestData()
        {
            var data = new TheoryData<TreeNode, int>();

            var tree1 =
                new TreeNode(5,
                    new TreeNode(4,
                        new TreeNode(11, new TreeNode(7), new TreeNode(2)),
                        null),
                    new TreeNode(8,
                        new TreeNode(13),
                        new TreeNode(4, null, new TreeNode(1)))
                );

            var tree2 = new TreeNode(3, new TreeNode(9, new TreeNode(20, null)), new TreeNode(15, new TreeNode(7)));
            var tree3 = new TreeNode(1, null, new TreeNode(2));

            data.Add(tree1, 4);
            data.Add(tree2, 3);
            data.Add(tree3, 2);

            return data;
        }

        public static TheoryData<TreeNode, int, bool> HasPathSumTestData()
        {
            // Case 1: Example tree, target = 22 => true
            // Tree:
            //        5
            //       / \
            //      4   8
            //     /   / \
            //    11  13  4
            //   /  \       \
            //  7    2       1
            var data = new TheoryData<TreeNode, int, bool>();

            // Case 1: Example tree, target = 22 => true
            var tree1 =
                new TreeNode(5,
                    new TreeNode(4,
                        new TreeNode(11, new TreeNode(7), new TreeNode(2)),
                        null),
                    new TreeNode(8,
                        new TreeNode(13),
                        new TreeNode(4, null, new TreeNode(1)))
                );

            data.Add(tree1, 22, true);  // 5→4→11→2
            data.Add(tree1, 26, true);  // 5→8→13
            data.Add(tree1, 27, true);

            // Case 2: Single node
            var single = new TreeNode(7);
            data.Add(single, 7, true);
            data.Add(single, 10, false);

            // Case 3: Null tree
            data.Add(null, 0, false);

            // Case 4: Negative values
            var negTree = new TreeNode(-2, null, new TreeNode(-3));
            data.Add(negTree, -5, true);
            data.Add(negTree, -2, false);

            return data;
        }
    }
}
