using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastRecentlyUsedCollection
{
    class Node <T>
    {
        public Node<T> Next;
        public Node<T> Prev;
        public Tuple<T, int> Value;

        public Node(T value, int key)
        {
            Value = Tuple.Create(value, key);
        }
    }

    class ListLRU<T>
    {
        Node<T> head;
        Node<T> tail;

        public Node<T> Add(T value, int key)
        {
            Node<T> newNode = new Node<T>(value, key);
            Add(newNode);
            return newNode;
        }

        private void Add(Node<T> newNode)
        {
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
        }

        public int Remove(Node<T> nodeToRemove)
        {
            if (nodeToRemove == head && nodeToRemove == tail)
            {
                head = tail = null;
                return nodeToRemove.Value.Item2;
            }

            if (nodeToRemove.Prev != null)
            {
                nodeToRemove.Prev.Next = nodeToRemove.Next;
            }
            else
            {
                head = nodeToRemove.Next;
            }

            if (nodeToRemove.Next != null)
            {
                nodeToRemove.Next.Prev = nodeToRemove.Prev;
            }
            else
            {
                tail = nodeToRemove.Prev;
            }

            return nodeToRemove.Value.Item2;
        }

        public T Get(Node<T> node)
        {
            Remove(node);
            node.Next = node.Prev = null;
            Add(node);
            return node.Value.Item1;
        }

        public int RemoveLastUsed()
        {
            return Remove(head);
        }

        public override string ToString()
        {
            if (head == null)
            {
                return "List is empty";
            }

            StringBuilder str = new StringBuilder();
            Node<T> ptr = head;

            while (ptr.Next != null)
            {
                str.Append(ptr.Value).Append(" = ");
                ptr = ptr.Next;
            }

            str.Append(ptr.Value);
            return str.ToString();
        }
  
    }
}
