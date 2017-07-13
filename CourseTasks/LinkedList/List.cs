using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T>
    {
        private Node<T> head = null;
        private Node<T> lastNode = null;
        private int size = 0;

        public int Size
        {
            get
            {
                return size;
            }
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            size++;
            if (head == null)
            {
                head = node;
            }
            else
            {
                lastNode.NextNode = node;
            }
            lastNode = node;
        }

        public Node<T> GetFirstNode()
        {
            return head;
        }

        public T GetValue(int index)
        {
            return GetNode(index).Value;
        }

        public T SetValue(int index, T valueNew)
        {
            Node<T> node = GetNode(index);
            T valueOld = node.Value;
            node.Value = valueNew;
            return valueOld;
        }

        public Node<T> GetNode(int index)
        {
            if ((index >= Size) || (index < 0))
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений");
            }
            int i = 0;
            Node<T> node = head;
            while (i < index)
            {
                node = node.NextNode;
                i++;
            }
            return node;
        }

        public T DeleteNode(int index)
        {
            if ((index >= Size) || (index < 0))
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений");
            }
            if (index == 0)
            {
                T valueHeadOld = head.Value;
                head = head.NextNode;
                size--;
                return valueHeadOld;
            }
            Node<T> nodePrevious = GetNode(index - 1);
            Node<T> nodeDelete = nodePrevious.NextNode;
            nodePrevious.NextNode = nodeDelete.NextNode;
            if (index == size - 1)
            {
                lastNode = nodePrevious;
            }
            size--;
            return nodeDelete.Value;
        }

        public void InsertBegining(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
                lastNode = head;
            }
            else
            {
                head = new Node<T>(value, head);
            }
            size++;
        }

        public void Insert(int index, T value)
        {
            if ((index > size) || (index < 0))
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений");
            }

            if (index == 0)
            {
                InsertBegining(value);
                return;
            }

            if (index == size)
            {
                lastNode.NextNode = new Node<T>(value, null);
            }
            else
            {
                Node<T> nodePrevious = GetNode(index - 1);
                nodePrevious.NextNode = new Node<T>(value, nodePrevious.NextNode);
            }
            size++;
        }

        public bool DeleteNodeValue(T value)
        {
            Node<T> node = head;
            int i = 0;
            while (i < Size)
            {
                if (Equals(node.Value, value))
                {
                    DeleteNode(i);
                    return true;
                }
                i++;
                node = node.NextNode;
            }
            return false;
        }

        public T DeleteFirstNode()
        {
            if (head == null)
            {
                throw new InvalidOperationException("В списке нет элементов");
            }
            T valueNode = head.Value;
            DeleteNode(0);
            return valueNode;
        }

        public void InsertAfter(T valueNew, Node<T> nodePrevious)
        {
            Node<T> node = new Node<T>(valueNew, nodePrevious.NextNode);
            if (nodePrevious == lastNode)
            {
                lastNode = node;
            }
            nodePrevious.NextNode = node;
            size++;
        }

        public void DeleteAfter(Node<T> node)
        {
            if (node == lastNode)
            {
                return;
            }
            if (node == lastNode)
            {
                lastNode = node;
            }
            node.NextNode = node.NextNode.NextNode;
            size--;
        }

        public void Rotate()
        {
            if (head == null)
            {
                return;
            }
            int i = 0;
            Node<T> node = head;
            Node<T> nodeTempPrevious = head;
            Node<T> nodeTempNext = head.NextNode;
            lastNode = head;
            while (i < size)
            {
                if (i == size - 1)
                {
                    head.NextNode = null;
                    head = node;
                    break;
                }
                else
                {
                    nodeTempPrevious = node;
                    node = nodeTempNext;
                    nodeTempNext = node.NextNode;
                    node.NextNode = nodeTempPrevious;
                    i++;
                }
            }
        }

        public LinkedList<T> Copy()
        {
            LinkedList<T> list = new LinkedList<T>();
            int i = 0;
            Node<T> node = head;
            while (i < size)
            {
                list.Add(node.Value);
                node = node.NextNode;
                i++;
            }
            return list;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            Node<T> node = head;
            while (i < size)
            {
                sb.Append(node.Value);
                sb.Append(Environment.NewLine);
                node = node.NextNode;
                i++;
            }
            return sb.ToString();
        }
    }
}
