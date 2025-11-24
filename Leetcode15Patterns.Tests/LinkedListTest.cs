namespace Leetcode15Patterns.Tests
{
    public class LinkedListTest
    {
        [Fact]
        public void TestDeleteNode()
        {
            // Arrange
            var linkedList = new LinkedList();
            var head = new LinkedList.ListNode(1,
                        new LinkedList.ListNode(2,
                        new LinkedList.ListNode(3,
                        new LinkedList.ListNode(4,
                        new LinkedList.ListNode(5)))));
            int n = 2;
            // Act
            var newHead = linkedList.DeleteNode(head, n);
            // Assert
            var expectedValues = new List<int> { 1, 2, 3, 5 };
            var current = newHead;
            foreach (var expectedValue in expectedValues)
            {
                Assert.NotNull(current);
                Assert.Equal(expectedValue, current.val);
                current = current.next;
            }
            Assert.Null(current); // Ensure the list ends correctly
        }

        [Fact]
        public void TestGetLength()
        {
            // Arrange
            var linkedList = new LinkedList();
            var head = new LinkedList.ListNode(1,
                        new LinkedList.ListNode(2,
                        new LinkedList.ListNode(3,
                        new LinkedList.ListNode(4,
                        new LinkedList.ListNode(5)))));
            // Act
            int length = linkedList.GetLength(head);
            // Assert
            Assert.Equal(5, length);
        }

        [Fact]
        public void TestPrintList()
        {
            // Arrange
            var linkedList = new LinkedList();
            var head = new LinkedList.ListNode(1,
                        new LinkedList.ListNode(2,
                        new LinkedList.ListNode(3)));
            using var sw = new StringWriter();
            Console.SetOut(sw);
            // Act
            linkedList.PrintList(head);
            // Assert
            var expectedOutput = "1 -> 2 -> 3 -> null" + Environment.NewLine;
            Assert.Equal(expectedOutput, sw.ToString());
        }

        [Fact]
        public void TestHasCycle()
        {
            // Arrange
            var linkedList = new LinkedList();
            var head = new LinkedList.ListNode(3)
            {
                next = new LinkedList.ListNode(2)
            };
            head.next.next = new LinkedList.ListNode(0)
            {
                next = new LinkedList.ListNode(-4)
            };
            head.next.next.next.next = head.next; // Create a cycle
            // Act
            bool hasCycle = linkedList.HasCycle(head);
            // Assert
            Assert.True(hasCycle);
        }
    }
}
