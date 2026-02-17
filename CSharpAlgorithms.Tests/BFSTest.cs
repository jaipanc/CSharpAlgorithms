using TreeNode = CSharpAlgorithms.DFS.Treenode;

namespace CSharpAlgorithms.Tests
{
    public class BFSTest
    {
        [Theory]
        [MemberData(nameof(LevelOrderTestData))]
        public void LevelOrderTest(TreeNode root, List<List<int>> expected)
        {
            var result = BFS.LevelOrder(root);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(FindRightNodeTestCases))]
        public void RightSideViewTest(TreeNode root, List<int> expected)
        {
            var result = BFS.RightSideView(root);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ZigzagTestData))]
        public void ZigzagLevelOrderTest(TreeNode root, IList<IList<int>> expected)
        {
            var result = BFS.ZigzagLevelOrder(root);
            Assert.Equal(expected, result);
        }

        public static TheoryData<TreeNode, IList<IList<int>>> ZigzagTestData =>
        new()
        {
            // Case 1: Example from problem
            {
                new TreeNode(3)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(20)
                    {
                        left = new TreeNode(15),
                        right = new TreeNode(7)
                    }
                },
                new List<IList<int>>
                {
                    new List<int> { 3 },
                    new List<int> { 20, 9 },
                    new List<int> { 15, 7 }
                }
            },

            // Case 2: Single node
            {
                new TreeNode(1),
                new List<IList<int>>
                {
                    new List<int> { 1 }
                }
            },

            // Case 3: Empty tree
            {
                null,
                new List<IList<int>>()
            },

            // Case 4: Two levels
            {
                new TreeNode(1)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(3)
                },
                new List<IList<int>>
                {
                    new List<int> { 1 },
                    new List<int> { 3, 2 }
                }
            },

            // Case 5: Left skewed
            {
                new TreeNode(1)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(3)
                    }
                },
                new List<IList<int>>
                {
                    new List<int> { 1 },
                    new List<int> { 2 },
                    new List<int> { 3 }
                }
            }
        };

        public static TheoryData<TreeNode, List<int>> FindRightNodeTestCases => new()
        {
        // Test case 1: Empty tree
        { null, new List<int>() },

        // Test case 2: Single node
        { new TreeNode(1), new List<int> { 1 } },

        // Test case 3: Complete binary tree with 3 nodes
        {
            new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            },
            new List<int> { 1, 3 }
        },

        // Test case 4: Incomplete binary tree
        {
            new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4)
                },
                right = new TreeNode(3)
            },
            new List<int> { 1, 3, 4 }
        },

        // Test case 5: Larger tree
        {
            new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(6)
                }
            },
            new List<int> { 1, 3, 6 }
        },

        // Test case 6: Skewed tree to the left
        {
            new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(4)
                    }
                }
            },
            new List<int> { 1, 2, 3, 4 }
        },

        // Test case 7: Skewed tree to the right
        {
            new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    right = new TreeNode(3)
                    {
                        right = new TreeNode(4)
                    }
                }
            },
            new List<int> { 1, 2, 3, 4 }
        }
        };


        public static TheoryData<TreeNode, List<List<int>>> LevelOrderTestData =>
        new TheoryData<TreeNode, List<List<int>>>
        {
            // Test case 1: Empty tree
            {
                null,
                new List<List<int>>()
            },

            // Test case 2: Single node
            {
                new TreeNode(1),
                new List<List<int>> { new() { 1 } }
            },

            // Test case 3: Complete binary tree with 3 levels
            {
                new TreeNode(3)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(20)
                    {
                        left = new TreeNode(15),
                        right = new TreeNode(7)
                    }
                },
                new List<List<int>>
                {
                    new() { 3 },
                    new() { 9, 20 },
                    new() { 15, 7 }
                }
            },

            // Test case 4: Left-skewed tree
            {
                new TreeNode(1)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(3)
                        {
                            left = new TreeNode(4)
                        }
                    }
                },
                new List<List<int>>
                {
                    new() { 1 },
                    new() { 2 },
                    new() { 3 },
                    new() { 4 }
                }
            },

            // Test case 5: Right-skewed tree
            {
                new TreeNode(1)
                {
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(3)
                        {
                            right = new TreeNode(4)
                        }
                    }
                },
                new List<List<int>>
                {
                    new() { 1 },
                    new() { 2 },
                    new() { 3 },
                    new() { 4 }
                }
            },

            // Test case 6: Perfect binary tree with 3 levels
            {
                new TreeNode(1)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(5)
                    },
                    right = new TreeNode(3)
                    {
                        left = new TreeNode(6),
                        right = new TreeNode(7)
                    }
                },
                new List<List<int>>
                {
                    new() { 1 },
                    new() { 2, 3 },
                    new() { 4, 5, 6, 7 }
                }
            }
        };
    }
}
