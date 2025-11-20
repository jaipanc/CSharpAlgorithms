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
    }
}
