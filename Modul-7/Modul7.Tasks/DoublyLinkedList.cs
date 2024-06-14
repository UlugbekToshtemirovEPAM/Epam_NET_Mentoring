using Modul7.Tasks.DoNotChange;
using System.Collections;

namespace Modul7.Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node Prev;

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node head;
        private Node tail;
        private int length;

        public int Length => length;

        public void Add(T e)
        {
            Node newNode = new Node(e);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            length++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > length)
                throw new IndexOutOfRangeException();

            Node newNode = new Node(e);
            if (index == 0)
            {
                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
            }
            else if (index == length)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                Node current = GetNodeAt(index);
                newNode.Next = current;
                newNode.Prev = current.Prev;
                if (current.Prev != null)
                    current.Prev.Next = newNode;
                current.Prev = newNode;
            }
            length++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= length)
                throw new IndexOutOfRangeException();

            return GetNodeAt(index).Data;
        }

        public void Remove(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    RemoveNode(current);
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= length)
                throw new IndexOutOfRangeException();

            Node nodeToRemove = GetNodeAt(index);
            T removedData = nodeToRemove.Data;
            RemoveNode(nodeToRemove);
            return removedData;
        }

        private void RemoveNode(Node node)
        {
            if (node.Prev != null)
                node.Prev.Next = node.Next;
            if (node.Next != null)
                node.Next.Prev = node.Prev;

            if (node == head)
                head = node.Next;
            if (node == tail)
                tail = node.Prev;

            length--;
        }

        private Node GetNodeAt(int index)
        {
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private DoublyLinkedList<T> list;
            private Node current;
            private bool started;

            public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
            {
                this.list = list;
                this.current = null;
                this.started = false;
            }

            public T Current => current.Data;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (!started)
                {
                    current = list.head;
                    started = true;
                }
                else
                {
                    current = current?.Next;
                }
                return current != null;
            }

            public void Reset()
            {
                current = null;
                started = false;
            }

            public void Dispose()
            {
                
            }
        }
    }
}