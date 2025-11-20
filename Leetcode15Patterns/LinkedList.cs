
using Microsoft.VisualBasic.FileIO;

namespace Leetcode15Patterns
{
    public class LinkedList
    {
        public class ListNode(int val = 0, ListNode? next = null)
        {
            public int val = val;
            public ListNode next = next;
        }

        public int GetLength(ListNode head)
        {
            int length = 0;
            ListNode current = head;
            while (current != null)
            {
                length++;
                current = current.next;
            }
            return length;
        }

        public ListNode DeleteNode(ListNode head, int n)
        {
            ListNode dummy = new(0, head);
            ListNode first = dummy;
            ListNode second = dummy;
            // Move first n+1 steps ahead
            for (int i = 0; i <= n; i++)
            {
                first = first.next;
            }
            // Move both pointers until first reaches the end
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }
            // Delete the nth node from the end
            second.next = second.next.next;
            return dummy.next;
        }
    }
}
