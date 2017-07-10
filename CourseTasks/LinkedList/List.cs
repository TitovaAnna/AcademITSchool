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
            T valueOld = GetNode(index).Value;
            size--;
            if (index == 0)
            {
                head = GetNode(1);
                return valueOld;
            }
            GetNode(index - 1).NextNode = GetNode(index + 1);
            return valueOld;
        }

        public void InsertBegining(T value)
        {
            Node<T> headNew = new Node<T>(value, head);
            head = headNew;
            size++;
        }

        public void Insert(int index, T value)
        {
            if ((index >= Size) || (index < 0))
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений");
            }

            if (index == Size)
            {
                Node<T> nodeNew = new Node<T>(value, null);
                GetNode(index - 1).NextNode = nodeNew;
            }
            else if (index == 1)
            {
                Node<T> nodeNew = new Node<T>(value, GetNode(index));
                head.NextNode = nodeNew;
            }
            else if (index == 0)
            {
                InsertBegining(value);
            }
            else
            {
                Node<T> nodeNew = new Node<T>(value, GetNode(index));
                GetNode(index - 1).NextNode = nodeNew;
            }
            size++;
        }

        public void DeleteNodeValue(T value)
        {
            Node<T> node = head;
            int i = 0;
            while (i < Size)
            {
                if (node.Value.Equals(value))
                {
                    DeleteNode(i);
                }
                else
                {
                    i++;
                }
                node = node.NextNode;
            }
        }

        public T DeleteFirstNode()
        {
            T valueNode = head.Value;
            DeleteNode(0);
            return valueNode;
        }

        public void InsertAfter(Node<T> nodeNew, Node<T> nodePevious)
        {
            nodeNew.NextNode = nodePevious.NextNode;
            nodePevious.NextNode = nodeNew;
            size++;
        }

        public void DeleteAfter(Node<T> node)
        {
            node.NextNode = node.NextNode.NextNode;
            size--;
        }

        public void Rotation()
        {
            int i = 0;
            Node<T> node = head;
            Node<T> nodeTempPrevious = head;
            Node<T> nodeTempNext = head.NextNode;
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
    }
}
