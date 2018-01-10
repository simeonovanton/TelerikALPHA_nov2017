using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementLinkedList
{
    public class DynamicList
    {
        private class Node
        {
            private object element;
            private Node next;

            public object Element
            {
                get { return element; }
                set { element = value; }
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public Node(object element, Node prevNode)
            {
                this.element = element;
                prevNode.next = this;
            }

            public Node(object element)
            {
                this.element = element;
                next = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Add(object item)
        {
            if (head == null)
            {   // We have empty list 
                head = new Node(item);
                tail = head;
            }
            else
            {   // We have non-empty list
                Node newNode = new Node(item, tail);
                tail = newNode;
            }
            count++;
        }

        public object RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            // Find the element at the specified index 
            int currentIndex = 0;
            Node currentNode = head;
            Node prevNode = null;
            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }
            // Remove the element
            count--;
            if (count == 0)
            {
                head = null;
            }
            else if (prevNode == null)
            {
                head = currentNode.Next;
            }
            else
            {
                prevNode.Next = currentNode.Next;
            }

            // Find last element 
            Node lastElement = null;
            if (this.head != null)
            {
                lastElement = this.head;
                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }
            tail = lastElement; 

            return currentNode.Element;
        }
    }


        class LinkedListImplement
    {
        static void Main()
        {
            DynamicList dynamicList = new DynamicList();

        }
    }
}
