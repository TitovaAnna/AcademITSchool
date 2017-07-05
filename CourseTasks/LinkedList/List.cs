using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class List
    {

    }

    class Node<T>
    {
     //   private Node<T> nextNode;
        public Node(T node)
        {
            nextNode = null;
            this.node = node;
        }
        public T node
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
