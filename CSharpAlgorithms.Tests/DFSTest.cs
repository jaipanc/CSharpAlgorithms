using static CSharpAlgorithms.DFS;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TreeNode = CSharpAlgorithms.DFS.Treenode;
using GraphNode = CSharpAlgorithms.DFS.GraphNode;

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

        [Theory]
        [MemberData(nameof(DiameterCases))]
        public void TestDiameterOfBinaryTree(TreeNode node, int expected)
        {
            var output = DFS.DiameterOfBinaryTree(node);
            Assert.Equal(expected, output);
        }


        [Theory]
        [MemberData(nameof(GetPathSumIIData))]
        public void TestPathSumII(TreeNode root, int targetSum, int[][] expectedPaths)
        {
            var actual = DFS.PathSumII(root, targetSum);

            // Convert actual -> int[][] for easy comparison
            var actualPaths = actual.Select(p => p.ToArray()).ToArray();

            AssertPathsEqual(expectedPaths, actualPaths);
        }

        [Theory]
        [MemberData(nameof(LongestUnivaluePathTests))]
        public void LongestUnivaluePath_Works(TreeNode root, int expected)
        {
            var actual = DFS.LongestUnivaluePath(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestBuildAdjacencyListData))]
        public void TestBuildAdjacencyList(int nodes, int[][] edges, Dictionary<int, List<int>> expected)
        {
            var actual = DFS.BuildAdjacencyList(nodes, edges);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestCloneGraphData))]
        public void TestCloneGraph(GraphNode node, Dictionary<int, List<int>> expected)
        {
            var actual = DFS.CloneGraph(node);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestValidTreeData))]
        public void TestValidTree(int n, int[][] edges, bool expected)
        {
            var actual = DFS.ValidTree(n, edges);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(FloodFillTestData))]
        public void TestFloodFill(int[][] image, int sr, int sc, int color, int[][] expected)
        {
            // Act
            var result = FloodFill(image, sc, sr, color);

            // Assert
            Assert.Equivalent(expected, result);
        }

        [Theory]
        [MemberData(nameof(NumberOfIslandsTestData))]
        public void TestNumberOfIslands(char[][] grid, int expected)
        {
            var result = NumberOfIslands(grid);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SurroundedRegionsTestData))]
        public void TestSurroundedRegions(char[][] board, char[][] expected)
        {
            SurroundedRegions(board);
            Assert.Equivalent(expected, board);
        }

        public static TheoryData<char[][], char[][]> SurroundedRegionsTestData()
        {
            return new TheoryData<char[][], char[][]>
            {
                {
                     new char[][]
                     {
                            ['X','X','X','X','O'],
                            ['X','X','O','X','X'],
                            ['X','X','O','X','O'],
                            ['X','O','X','X','X'],
                            ['X','O','X','X','X']
                     },
                     new char[][]
                     {
                         ['X','X','X','X','O'],
                         ['X','X','X','X','X'],
                         ['X','X','X','X','O'],
                         ['X','O','X','X','X'],
                         ['X','O','X','X','X']
                     }
                },
                {
                    new char[][]
                    {
                        ['O','O'],
                        ['O','X']
                    },
                    new char[][]
                    {
                        ['O','O'],
                        ['O','X']
                    }
                },
                  {
                    new char[][]
                    {
                        ['X']
                    },
                    new char[][]
                    {
                        ['X']
                    }
                }
            };
        }

        public static TheoryData<char[][], int> NumberOfIslandsTestData()
        {
            return new TheoryData<char[][], int>
            {
                {
                    new char[][]{
                             ['1','1','1','1','0'],
                             ['1','1','0','1','0'],
                             ['1','1','0','0','0'],
                             ['0','0','0','0','0']
                            },1
                },
                {
                    new char[][]{
                             ['1','1','0','0','0'],
                             ['1','1','0','0','0'],
                             ['0','0','1','0','0'],
                             ['0','0','0','1','1']
                            },3
                },
            };
        }

        public static TheoryData<int[][], int, int, int, int[][]> FloodFillTestData()
        {
            return new TheoryData<int[][], int, int, int, int[][]>
        {
            // Basic fill
            {
                new int[][]
                {
                    [1,1,1],
                    [1,1,0],
                    [1,0,1]
                },
                1, 1, 2,
                new int[][]
                {
                    [2,2,2],
                    [2,2,0],
                    [2,0,1]
                }
            },

            // No-op when starting pixel already has target color
            {
                new int[][]
                {
                    [2,2,2],
                    [2,2,2]
                },
                0, 0, 2,
                new int[][]
                {
                    [2,2,2],
                    [2,2,2]
                }
            },

            // Single cell
            {
                new int[][]
                {
                    [5]
                },
                0, 0, 3,
                new int[][]
                {
                    [3]
                }
            },

            // Diagonals should NOT be filled
            {
                new int[][]
                {
                    [1,0,1],
                    [0,1,0],
                    [1,0,1]
                },
                1, 1, 2,
                new int[][]
                {
                    [1,0,1],
                    [0,2,0],
                    [1,0,1]
                }
            }
        };
        }


        public static TheoryData<int, int[][], bool> TestValidTreeData()
         {
            var data = new TheoryData<int, int[][], bool>
            {
            // --- Basic / Edge cases ---
            { 1, Array.Empty<int[]>(), true },                              // single node is a tree
            { 2, new int[][] { [0, 1] }, true },                 // one edge connects 2 nodes

            // --- Valid trees ---
            { 5, new int[][] { [0,1], [0,2], [0,3], [1,4] }, true },  // classic tree
            { 4, new int[][] { [0,1], [1,2], [2,3] }, true },               // chain

            // --- Wrong edge count (fast-fail) ---
            { 3, Array.Empty<int[]>(), false },                             // too few edges (disconnected)
            { 3, new int[][] { [0,1] }, false },                 // too few edges
            { 3, new int[][] { [0,1], [1,2], [2,0] }, false }, // too many edges (cycle)

            // --- Cycle present (may also pass edge count check in other configs) ---
            { 4, new int[][] { [0,1], [1, 2], [2, 0] }, false }, // edges=3, n-1=3 but node 3 disconnected + cycle

            // --- Disconnected (but edge count equals n-1) ---
            { 4, new int[][] { [0,1], [2, 3], [0, 1] }, false }, // duplicate keeps edges count at 3 but still disconnected

            // Another disconnected example (no duplicates), but still edges = n-1:
            // component A: 0-1-2 forms a chain (2 edges), component B: 3 alone -> need 3 edges total so add a self-loop/dup; not typical input
            // We'll instead test a clean disconnected with too few edges (already above).

            // --- Self-loop (not a tree) ---
            { 2, new int[][] { [0, 0] }, false },                 // self-loop is a cycle

            // --- Duplicate edge (not a tree, usually treated as cycle/multi-edge invalid) ---
            { 2, new int[][] { [0,1], [0,1] }, false },     // edges=2, n-1=1 -> fails edge count
            };

            return data;
        }


        public static TheoryData<GraphNode, Dictionary<int, List<int>>> TestCloneGraphData()
        {
            var data = new TheoryData<GraphNode, Dictionary<int, List<int>>>
            {
                // Case 1: null input -> empty adjacency list
                { null, [] }
            };

            // Case 2: single node with no neighbors
            var single = new GraphNode { Value = 1, Neighbors = Array.Empty<GraphNode>() };
            data.Add(single, new Dictionary<int, List<int>>
            {
                { 1, new List<int>() }
            });

            // Case 3: two-node undirected edge 1 <-> 2
            var n1 = new GraphNode { Value = 1 };
            var n2 = new GraphNode { Value = 2 };
            n1.Neighbors = [n2];
            n2.Neighbors = [n1];
            data.Add(n1, new Dictionary<int, List<int>>
                {
                    { 1, new List<int> { 2 } },
                    { 2, new List<int> { 1 } }
                });

            // Case 4: triangle 1 <-> 2 <-> 3 <-> 1
            var a = new GraphNode { Value = 1 };
            var b = new GraphNode { Value = 2 };
            var c = new GraphNode { Value = 3 };
            a.Neighbors = [b, c];
            b.Neighbors = [a, c];
            c.Neighbors = [a, b];
            data.Add(a, new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 2, 3 } },
                { 2, new List<int> { 1, 3 } },
                { 3, new List<int> { 1, 2 } }
            });

            return data;
        }


        public static TheoryData<int, int[][], Dictionary<int, List<int>>> TestBuildAdjacencyListData()
        {
            return new TheoryData<int, int[][], Dictionary<int, List<int>>>
        {
            // Case 1: Simple connected graph
            {
                3,
                new int[][]
                {
                    [0, 1],
                    [1, 2]
                },
                new Dictionary<int, List<int>>
                {
                    { 0, new List<int> { 1 } },
                    { 1, new List<int> { 0, 2 } },
                    { 2, new List<int> { 1 } }
                }
            },

            // Case 2: No edges
            {
                3,
                Array.Empty<int[]>(),
                new Dictionary<int, List<int>>
                {
                    { 0, new List<int>() },
                    { 1, new List<int>() },
                    { 2, new List<int>() }
                }
            },

            // Case 3: Single node
            {
                1,
                Array.Empty<int[]>(),
                new Dictionary<int, List<int>>
                {
                    { 0, new List<int>() }
                }
            },

            // Case 4: Disconnected graph
            {
                4,
                new int[][]
                {
                    [0, 1],
                    [2, 3]
                },
                new Dictionary<int, List<int>>
                {
                    { 0, new List<int> { 1 } },
                    { 1, new List<int> { 0 } },
                    { 2, new List<int> { 3 } },
                    { 3, new List<int> { 2 } }
                }
            }
        };
        }

        public static TheoryData<TreeNode, int> LongestUnivaluePathTests()
        {
            var data = new TheoryData<TreeNode, int>();

            // 1) null
            data.Add(null, 0);

            // 2) single node
            data.Add(new TreeNode(1), 0);

            // 3) example:
            //        5
            //       / \
            //      4   5
            //     / \   \
            //    1   1   5
            // longest univalue path: 5-5-5 => 2 edges
            data.Add(
                new TreeNode(5,
                    new TreeNode(4,
                        new TreeNode(1),
                        new TreeNode(1)),
                    new TreeNode(5,
                        null,
                        new TreeNode(5))),
                2
            );

            // 4) all same values, perfect-ish:
            //        1
            //       / \
            //      1   1
            //     / \ / \
            //    1  1 1  1
            // longest path goes leaf->root->leaf: depth 2 + depth 2 = 4 edges
            data.Add(
                new TreeNode(1,
                    new TreeNode(1, new TreeNode(1), new TreeNode(1)),
                    new TreeNode(1, new TreeNode(1), new TreeNode(1))),
                4
            );

            // 5) only one side chain:
            //    2
            //     \
            //      2
            //       \
            //        2
            //         \
            //          2
            // => 3 edges
            data.Add(
                new TreeNode(2,
                    null,
                    new TreeNode(2,
                        null,
                        new TreeNode(2,
                            null,
                            new TreeNode(2)))),
                3
            );

            // 6) best path occurs in a subtree (not through root):
            //        9
            //       / \
            //      1   1
            //     /     \
            //    1       1
            // longest univalue: left-subtree 1-1 => 1 edge, right-subtree 1-1 => 1 edge
            // but through root 9 doesn't connect; best is 1 edge (either side)
            data.Add(
                new TreeNode(9,
                    new TreeNode(1, new TreeNode(1), null),
                    new TreeNode(1, null, new TreeNode(1))),
                1
            );

            // 7) mixed values where a node connects both sides:
            //        3
            //       / \
            //      3   3
            //     /     \
            //    3       3
            // longest through root: left chain 2 edges + right chain 2 edges = 4
            data.Add(
                new TreeNode(3,
                    new TreeNode(3, new TreeNode(3), null),
                    new TreeNode(3, null, new TreeNode(3))),
                4
            );

            // 8) no equal adjacent values anywhere => 0
            data.Add(
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(3),
                        new TreeNode(4)),
                    new TreeNode(5)),
                0
            );

            return data;
        }

        public static TheoryData<TreeNode, int, int[][]> GetPathSumIIData()
        {
            var data = new TheoryData<TreeNode, int, int[][]>
            {
                // 1) null tree
                { null, 0, Array.Empty<int[]>() },

                // 2) single node matches
                { new TreeNode(5), 5, new[] { new[] { 5 } } },

                // 3) single node no match
                { new TreeNode(5), 10, Array.Empty<int[]>() }
            };

            // 4) classic example
            //         5
            //        / \
            //       4   8
            //      /   / \
            //     11  13  4
            //    / \      / \
            //   7   2    5   1
            //
            // target = 22 => [5,4,11,2] and [5,8,4,5]
            var ex =
                new TreeNode(5,
                    new TreeNode(4,
                        new TreeNode(11,
                            new TreeNode(7),
                            new TreeNode(2)),
                        null),
                    new TreeNode(8,
                        new TreeNode(13),
                        new TreeNode(4,
                            new TreeNode(5),
                            new TreeNode(1)))
                );

            data.Add(ex, 22,
            [
                [5, 4, 11, 2],
                [5, 8, 4, 5]
            ]);

            // 5) negative values example
            //   -2
            //     \
            //     -3
            // target = -5 => [-2,-3]
            var neg = new TreeNode(-2, null, new TreeNode(-3));
            data.Add(neg, -5, [[-2, -3]]);

            // 6) multiple valid paths, ensure left-to-right DFS order
            //      1
            //     / \
            //    2   2
            //   /     \
            //  3       3
            // target = 6 => [1,2,3] and [1,2,3]
            // (two distinct paths with same values)
            var dup =
                new TreeNode(1,
                    new TreeNode(2, new TreeNode(3), null),
                    new TreeNode(2, null, new TreeNode(3)));

            data.Add(dup, 6,
            [
                [1, 2, 3],
                new[] { 1, 2, 3 }
            ]);

            return data;
        }

        // ---------- Helpers ----------
        private static void AssertPathsEqual(int[][] expected, int[][] actual)
        {
            Assert.Equal(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        // Expected values are DIAMETER IN EDGES.
        // These cases are correct for Approach B:
        // - dfs(null) = -1
        // - update: maxDiameter = max(maxDiameter, L + R + 2)
        // - return: 1 + max(L, R)
        public static TheoryData<TreeNode, int> DiameterCases()
        {
            var data = new TheoryData<TreeNode, int>();

            // 1) [1,2,3,4,5] => 3
            var t1 = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3));
            data.Add(t1, 3);

            // 2) Single node [1] => 0
            var t2 = new TreeNode(1);
            data.Add(t2, 0);

            // 3) Two nodes [1,2] => 1
            var t3 = new TreeNode(1, new TreeNode(2), null);
            data.Add(t3, 1);

            // 4) Skewed chain (4 nodes) => 3
            // 1 -> 2 -> 3 -> 4
            var t4 = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3,
                        new TreeNode(4), null),
                    null),
                null);
            data.Add(t4, 3);

            // 5) Perfect balanced tree height 2 => 4
            // [1,2,3,4,5,6,7] => path 4-2-1-3-7
            var t5 = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3, new TreeNode(6), new TreeNode(7)));
            data.Add(t5, 4);

            // 6) Diameter entirely in left subtree (doesn't need root) => 4
            //        1
            //       /
            //      2
            //     / \
            //    3   4
            //   /     \
            //  5       6
            // Diameter = 4 (5-3-2-4-6)
            var t6 = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3, new TreeNode(5), null),
                    new TreeNode(4, null, new TreeNode(6))),
                null);
            data.Add(t6, 4);

            // 7) Null tree => 0 (your wrapper method should handle this)
            TreeNode t7 = null;
            data.Add(t7, 0);

            return data;
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
