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
        private Node<T> current = null;
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
                current.nextNode = node;
            }
            current = node;
        }

        public int GetSize()
        {
            return Size;
        }

        public Node<T> GetFirstNode()
        {
            Node<T> firstNode = new Node<T>(head.value);
            return firstNode;
        }

        public T GetValue(int index)
        {
            if (index >= Size)
            {
                throw new ArgumentOutOfRangeException("Индекс больше количества узлов");
            }
            int i = 0;
            Node<T> node = new Node<T>(head.value, head.nextNode);
            while (i < index)
            {
                node = node.nextNode;
                i++;
            }
            return node.value;
        }

        public T SetValue(int index, T valueNew)
        {
            if (index >= Size)
            {
                throw new ArgumentOutOfRangeException("Индекс больше количества узлов");
            }
            int i = 0;
            Node<T> node = new Node<T>(head.value, head.nextNode);

            while (i < index)
            {
                node = node.nextNode;
                i++;
            }
            T valueOld = node.value;
            node.value = valueNew;
            return valueOld;
        }

        public Node<T> GetNode(int index)
        {
            if (index >= Size)
            {
                throw new ArgumentOutOfRangeException("Индекс больше количества узлов");
            }
            int i = 0;
            Node<T> node = new Node<T>(head.value, head.nextNode);
            while (i < index)
            {
                node = node.nextNode;
                i++;
            }
            return node;
        }

        public T DeleteNode(int index)
        {
            if (index >= Size)
            {
                throw new ArgumentOutOfRangeException("Индекс больше,чем количество узлов");
            }
            T valueOld = GetNode(index).value;

            if (index == 0)
            {
                head = GetNode(1);
                return valueOld;
            }

            GetNode(index - 1).nextNode = GetNode(index + 1);
            size--;
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
            if (index > Size)
            {
                throw new ArgumentOutOfRangeException("Индекс больше,чем количество узлов");
            }

            if (index == Size)
            {
                Node<T> nodeNew = new Node<T>(value, null);
                GetNode(index - 1).nextNode = nodeNew;
            }
            else if (index == 1)
            {
                Node<T> nodeNew = new Node<T>(value, GetNode(index));
                head.nextNode = nodeNew;
            }
            else if (index == 0)
            {
                InsertBegining(value);
            }
            else
            {
                Node<T> nodeNew = new Node<T>(value, GetNode(index));
                GetNode(index - 1).nextNode = nodeNew;
            }
            size++;
        }

        //public void DeleteNodeValue(T value)
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        if (GetNode(i).value.Equals(value))
        //        {
        //            DeleteNode(i);
        //            // size--;
        //        }
        //    }
        //}
    }

    class Node<T>
    {
        public Node(T value)
        {
            nextNode = null;
            this.value = value;
        }

        public Node(T value, Node<T> nextNode)
        {
            this.nextNode = nextNode;
            this.value = value;
        }

        public T value
        {
            get;
            set;
        }
        public Node<T> nextNode
        {
            get;
            set;
        }
    }
}
