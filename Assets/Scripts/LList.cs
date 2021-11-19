using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class LList<T> : IDynamicList<T>
    {

        public class ListNode
        {
            public T member;
            public ListNode NextNode;

            public ListNode(T t)
            {
                member = t;
                NextNode = null;
            }

        }
        public ListNode head;
        public ListNode tail;
        private int count;

        public LList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public T this[int index]
        {
            get
            {
                int i = 0;
                ListNode current = head;
                while (current != null)
                {
                    if (i == index)
                    {
                        return current.member;
                    }
                    i++;
                    current = current.NextNode;

                }
                return default(T);
            }
            set
            {
                int i = 0;
                ListNode current = head;
                while (current != null)
                {
                    if (i == index)
                    {
                        current.member = value;
                    }
                    i++;
                    current = current.NextNode;

                }

            }
        }

        public int Count => count;

        public void Add(T item)
        {

            if (count == 0)
            {
                ListNode temp = new ListNode(item);
                head = temp;
                tail = temp;
                count++;
            }
            else
            {
                ListNode temp = new ListNode(item);
                tail.NextNode = temp;
                tail = temp;
                count++;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            ListNode current = head;
            while (current != null)
            {
                if (item.Equals(current.member))
                {
                    return true;
                }
                current = current.NextNode;
            }
            return false;
        }

        public void CopyTo(T[] target, int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            ListNode current = head;
            for (int i = 0, k = 0; i < count; i++, current = current.NextNode)
            {
                if (i >= index)
                {
                    target[k] = current.member;
                    k++;
                }
            }
        }

        public int IndexOf(T item)
        {
            int i = 0;
            ListNode current = head;
            while (current != null)
            {
                if (item.Equals(current.member))
                {
                    return i;
                }
                i++;
                current = current.NextNode;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            int i = 0;
            ListNode current = head;
            ListNode newn = new ListNode(item);
            if (index == 0)
            {
                newn.NextNode = head;
                head = newn;

                count++;
                return;
            }
            while (current != null)
            {
                if (i == index - 1)
                {

                    if (current.NextNode == null)
                    {
                        current.NextNode = newn;
                        tail = newn;
                        count++;
                        return;
                    }

                    newn.NextNode = current.NextNode;
                    current.NextNode = newn;

                    count++;
                    return;
                }
                i++;
                current = current.NextNode;
            }

        }


        public bool Remove(T item)
        {

            if (item.Equals(head.member))
            {
                head = head.NextNode;
                count--;
                return true;
            }
            ListNode current = head;
            while (current != null)
            {
                if (item.Equals(current.NextNode.member))
                {
                    current.NextNode = current.NextNode.NextNode;
                    if (current.NextNode == null)
                    {
                        tail = current;
                    }
                    count--;
                    return true;
                }
                current = current.NextNode;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            int i = 0;
            if (index == 0)
            {
                head = head.NextNode;
                count--;
                return;
            }
            ListNode current = head;
            while (current != null)
            {
                if (i == index - 1)
                {
                    current.NextNode = current.NextNode.NextNode;
                    if (current.NextNode == null)
                    {
                        tail = current;
                    }
                    count--;
                    return;
                }
                i++;
                current = current.NextNode;
            }

        }

    }


}
