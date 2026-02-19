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

        [Theory]
        [MemberData(nameof(WidthOfBinaryTreeTestData))]
        public void WidthOfBinaryTreeTest(TreeNode root, int expected)
        {
            var result = BFS.WidthOfBinaryTree(root);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]        // Edge case: same position
        [InlineData(1, 1, 2)]        // Simple case
        [InlineData(2, 1, 1)]        // One move away
        [InlineData(2, 2, 4)]        // Diagonal case
        [InlineData(3, 3, 2)]        // Another diagonal
        [InlineData(4, 4, 4)]        // Given example
        [InlineData(5, 5, 4)]        // Larger diagonal
        [InlineData(1, 2, 1)]        // Standard case
        [InlineData(2, 3, 3)]        // Standard case
        [InlineData(3, 2, 3)]        // Standard case
        [InlineData(0, 1, 3)]        // Near origin
        [InlineData(1, 0, 3)]        // Near origin
        [InlineData(6, 6, 4)]        // Larger board
        [InlineData(7, 7, 6)]        // Larger board
        [InlineData(8, 8, 6)]        // Even larger
        [InlineData(-1, -1, 2)]      // Negative coordinates
        [InlineData(-2, 1, 1)]       // Mixed signs
        [InlineData(1, -2, 1)]       // Mixed signs
        [InlineData(-3, -3, 2)]      // Negative diagonal
        [InlineData(100, 100, 68)]   // Large numbers (if algorithm handles it)
        [InlineData(50, 50, 34)]     // Medium large
        public void MinimumKnightMovesTest(int x, int y, int expected)
        {
            var result = BFS.MinimumKnightMoves(x, y);
            Assert.Equal(expected, result);
        }

        public static TheoryData<TreeNode, int> WidthOfBinaryTreeTestData =>
        new()
        {
            // 1) Null tree
            { null, 0 },

            // 2) Single node
            {
                new TreeNode(1),
                1
            },

            // 3) Full tree
            //        1
            //      /   \
            //     2     3
            //    / \   / \
            //   4  5  6  7
            {
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(4),
                        new TreeNode(5)),
                    new TreeNode(3,
                        new TreeNode(6),
                        new TreeNode(7))
                ),
                4
            },

            // 4) Sparse tree (classic example)
            //        1
            //      /   \
            //     3     2
            //    /       \
            //   5         9
            //
            // Width = 4 (positions count includes gaps)
            {
                new TreeNode(1,
                    new TreeNode(3,
                        new TreeNode(5),
                        null),
                    new TreeNode(2,
                        null,
                        new TreeNode(9))
                ),
                4
            },

            // 5) Left skewed tree
            //    1
            //   /
            //  2
            // /
            //3
            {
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(3),
                        null),
                    null
                ),
                1
            },

            // 6) Right skewed tree
            // 1
            //   \
            //    2
            //      \
            //       3
            {
                new TreeNode(1,
                    null,
                    new TreeNode(2,
                        null,
                        new TreeNode(3))
                ),
                1
            }
        };

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
