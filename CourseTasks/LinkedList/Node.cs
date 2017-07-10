using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        public Node(T value)
        {
            NextNode = null;
            this.Value = value;
        }

        public Node(T value, Node<T> nextNode)
        {
            this.NextNode = nextNode;
            this.Value = value;
        }

        public T Value
        {
            get;
            set;
        }
        public Node<T> NextNode
        {
            get;
            set;
        }
    }
}
