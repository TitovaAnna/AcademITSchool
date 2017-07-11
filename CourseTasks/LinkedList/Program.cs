using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList.LinkedList<int> list = new LinkedList<int>();
            list.Rotate();

            list.Add(9);
            list.Add(7);
            list.Add(9);
            list.Add(1);
            list.Add(23);

            list.DeleteAfter(list.GetNode(1));

            Console.WriteLine(list.ToString());
            Console.ReadKey();

            LinkedList.LinkedList<string> listString = new LinkedList<string>();

            list.InsertBegining(56);

            Console.WriteLine(listString.ToString());
            listString.Add("anya");
            listString.Add("tema");
            listString.Add(null);
            listString.Add("misha");
            listString.Add("ksusha");
            listString.DeleteNodeValue(null);


            Console.WriteLine(listString.ToString());
            Console.ReadKey();



            //Console.WriteLine(list.GetValue(4));
            //Console.WriteLine(list.SetValue(4, 57));


            //Console.WriteLine(list.GetNode(3).Value);
            //Console.WriteLine(list.GetNode(3).NextNode.Value);
            //Console.ReadKey();

            //Console.WriteLine(list.DeleteNode(3));
            //Console.WriteLine(list.GetNode(3).Value);
            //Console.ReadKey();

            //     list.InsertBegining(3);
            list.DeleteNodeValue(9);
            //Console.WriteLine(list.GetFirstNode().Value);
            //Console.WriteLine(list.GetNode(0).Value);
            //Console.ReadKey();


            Console.WriteLine(list.ToString());

            //    Console.WriteLine(list.GetNode(4).Value);
            //   Console.WriteLine(list.GetNode(4).Value);
            //    Console.WriteLine(list.GetNode(5).Value);
            Console.ReadKey();

            Node<int> nodeNew = new Node<int>(334);
            //     list.InsertAfter(nodeNew, list.GetNode(2));


            Console.WriteLine(list.ToString());
            Console.ReadKey();

            //     list.DeleteAfter(list.GetNode(2));

            Console.WriteLine(list.ToString());

            Console.ReadKey();


            list.Copy();

            Console.WriteLine(list.ToString());
            Console.ReadKey();


            //list.DeleteFirstNode();
            //Console.WriteLine(list.GetNode(0).Value);
            //Console.WriteLine(list.GetNode(1).Value);

            //Console.WriteLine(list.GetNode(3).Value);
            //Console.WriteLine(list.GetNode(4).Value);
            Console.ReadKey();

        }
    }
}
