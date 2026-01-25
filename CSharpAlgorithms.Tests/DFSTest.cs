using static CSharpAlgorithms.DFS;
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

        [Theory]
        [MemberData(nameof(GoodNodesTestData))]
        public void TestGoodNodes(TreeNode root, int expected)
        {
            var output = DFS.GoodNodes(root);
            Assert.Equal(expected, output);
        }

        [Theory]
        [MemberData(nameof(ValidateBSTTestData))]
        public void TestValidateBinarySearchTree(TreeNode node, bool expected)
        {
            var output = DFS.ValidateBinarySearchTree(node);
            Assert.Equal(expected, output);
        }

        [Theory]
        [MemberData(nameof(TiltCases))]
        public void TestFindTitl(TreeNode node, int expected)
        {
            var output = DFS.FindTitl(node);
            Assert.Equal(expected, output);
        }

        public static TheoryData<TreeNode, int> TiltCases()
        {
            var data = new TheoryData<TreeNode, int>();

            // Case 1: null tree -> tilt = 0
            data.Add(null, 0);

            // Case 2: single node -> tilt = 0
            data.Add(new TreeNode(5), 0);

            // Case 3:
            //     1
            //    / \
            //   2   3
            // tilt = |2-3| + 0 + 0 = 1
            data.Add(
                new TreeNode(1, new TreeNode(2), new TreeNode(3)),
                1
            );

            // Case 4 (LeetCode common example):
            //        4
            //      /   \
            //     2     9
            //    / \     \
            //   3   5     7
            // tilts: 3:0,5:0,2:|3-5|=2,7:0,9:|0-7|=7,4:|10-16|=6 => total 15
            data.Add(
                new TreeNode(4,
                    new TreeNode(2, new TreeNode(3), new TreeNode(5)),
                    new TreeNode(9, null, new TreeNode(7))
                ),
                15
            );

            // Case 5: skewed left
            //   1
            //  /
            // 2
            /// 
            //3
            // Node3 tilt 0, Node2 tilt |3-0|=3, Node1 tilt |5-0|=5 => total 8
            data.Add(
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(3),
                        null
                    ),
                    null
                ),
                8
            );

            return data;
        }

        public static TheoryData<Treenode, bool> ValidateBSTTestData()
        {
            var data = new TheoryData<Treenode, bool>
        {
        // Standard convention: empty tree is a valid BST
        { null, true },

        // single node
        { new Treenode(1), true },

        // valid: [2,1,3]
        { new Treenode(2) { left = new Treenode(1), right = new Treenode(3) }, true },

        // invalid: [5,1,4,null,null,3,6]
        { new Treenode(5)
            {
                left = new Treenode(1),
                right = new Treenode(4)
                {
                    left = new Treenode(3),
                    right = new Treenode(6)
                }
            }, false
        },

        // invalid deep violation: [10,5,15,null,null,6,20]
        { new Treenode(10)
            {
                left = new Treenode(5),
                right = new Treenode(15)
                {
                    left = new Treenode(6),
                    right = new Treenode(20)
                }
            }, false
        },

        // duplicates invalid under strict BST
        { new Treenode(2) { left = new Treenode(2) }, false },
        { new Treenode(2) { right = new Treenode(2) }, false },

        // valid with negatives
        { new Treenode(0) { left = new Treenode(-1), right = new Treenode(1) }, true },

        // valid skew increasing
        { new Treenode(1)
            {
                right = new Treenode(2)
                {
                    right = new Treenode(3)
                    {
                        right = new Treenode(4)
                    }
                }
            }, true
        },

        // valid skew decreasing
        { new Treenode(4)
            {
                left = new Treenode(3)
                {
                    left = new Treenode(2)
                    {
                        left = new Treenode(1)
                    }
                }
            }, true
        },

        // boundary values valid
        { new Treenode(int.MinValue)
            {
                right = new Treenode(int.MaxValue)
            }, true
        },

        // invalid deep boundary (violates ancestor constraint)
        { new Treenode(8)
            {
                left = new Treenode(3)
                {
                    right = new Treenode(9) // 9 is in left subtree of 8, should be < 8
                },
                right = new Treenode(10)
            }, false
        },
        };

            return data;
        }


        public static TheoryData<TreeNode, int> GoodNodesTestData()
        {
            var data = new TheoryData<TreeNode, int>
        {
            // Input: [3,1,4,3,null,1,5]  Output: 4
            { new TreeNode(3)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(3)
                    },
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(1),
                        right = new TreeNode(5)
                    }
                }, 4
            },

            // Input: [3,3,null,4,2]  Output: 3
            { new TreeNode(3)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(2)
                    }
                }, 3
            },

            // Input: [1]  Output: 1
            { new TreeNode(1), 1 },
        };

            return data;
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
