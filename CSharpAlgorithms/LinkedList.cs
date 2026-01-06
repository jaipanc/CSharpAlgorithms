namespace CSharpAlgorithms
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

        public void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public void PrintListRecursive(ListNode head)
        {
            if (head == null)
            {
                Console.WriteLine("null");
                return;
            }
            Console.Write(head.val + " -> ");
            PrintListRecursive(head.next);
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) return true;
            }
            return false;
        }

        // 234. Palindrome Linked List
        public static bool isPalindrome(ListNode head)
        {
            List<int> list = [];
            var curr = head;
            while (curr != null)
            {
                list.Add(curr.val);
                curr = curr.next;
            }

            var left = 0;
            var right = list.Count - 1;

            while (left < right)
            {
                if (list[left] != list[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new(0);
            ListNode current = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }
            if (l1 != null) current.next = l1;
            if (l2 != null) current.next = l2;
            return dummy.next;
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode nextTemp = current.next;
                current.next = prev;
                prev = current;
                current = nextTemp;
            }
            return prev;
        }

        public ListNode GetMiddleNode(ListNode head)
        {
            if (head == null) return null;
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new(0, head);
            ListNode current = dummy;
            while (current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return dummy.next;
        }
    }
}
