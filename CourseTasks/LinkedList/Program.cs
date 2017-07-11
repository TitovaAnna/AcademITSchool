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

            //      list.InsertBegining(56);
            //    Console.WriteLine(list.GetValue(0));
            //    Console.ReadKey();

            list.Add(9);
            list.Add(7);
            list.Add(9);
            list.Add(1);
            list.Add(23);

            //    list.DeleteNode(3);

            LinkedList.LinkedList<string> listString = new LinkedList<string>();

            //      list.InsertBegining(56);
            //    Console.WriteLine(list.GetValue(0));
            //    Console.ReadKey();

            listString.Add("anya");
            listString.Add("tema");
            listString.Add(null);
            listString.Add("misha");
            listString.Add("ksusha");
            listString.DeleteNodeValue(null);

            //    list.DeleteNode(3);
            list.InsertAfter(58, 7);
            Console.WriteLine(listString.GetNode(0).Value);
            Console.WriteLine(listString.GetNode(1).Value);
            Console.WriteLine(listString.GetNode(2).Value);
            Console.WriteLine(listString.GetNode(3).Value);




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


            Console.WriteLine(list.GetNode(0).Value);
            Console.WriteLine(list.GetNode(1).Value);
            Console.WriteLine(list.GetNode(2).Value);
            Console.WriteLine(list.GetNode(3).Value);
            //   Console.WriteLine(list.GetNode(4).Value);
            //    Console.WriteLine(list.GetNode(5).Value);
            Console.ReadKey();

            Node<int> nodeNew = new Node<int>(334);
            //     list.InsertAfter(nodeNew, list.GetNode(2));

            Console.WriteLine(list.GetNode(0).Value);
            Console.WriteLine(list.GetNode(1).Value);
            Console.WriteLine(list.GetNode(2).Value);
            Console.WriteLine(list.GetNode(3).Value);
            Console.ReadKey();

            //     list.DeleteAfter(list.GetNode(2));

            Console.WriteLine(list.GetNode(0).Value);
            Console.WriteLine(list.GetNode(1).Value);
            Console.WriteLine(list.GetNode(2).Value);
            Console.WriteLine(list.GetNode(3).Value);
            Console.WriteLine(list.GetNode(4).Value);
            Console.ReadKey();

            list.Rotate();
            list.Copy();
            Console.WriteLine(list.GetNode(0).Value);
            Console.WriteLine(list.GetNode(1).Value);
            Console.WriteLine(list.GetNode(2).Value);
            Console.WriteLine(list.GetNode(3).Value);
            Console.WriteLine(list.GetNode(4).Value);
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
