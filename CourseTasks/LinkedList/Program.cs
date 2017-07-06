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
            list.Add(9);
            list.Add(7);
            list.Add(9);
            list.Add(1);
            list.Add(23);

            Console.WriteLine(list.GetValue(4));
            Console.WriteLine(list.SetValue(4, 57));
            Console.WriteLine(list.GetValue(4));
            Console.ReadKey();

            Console.WriteLine(list.GetNode(3).value);
            Console.WriteLine(list.GetNode(3).nextNode.value);
            Console.ReadKey();

            Console.WriteLine(list.DeleteNode(3));
            Console.WriteLine(list.GetNode(3).value);
            Console.ReadKey();

            list.InsertBegining(3);
            Console.WriteLine(list.GetFirstNode().value);
            Console.WriteLine(list.GetNode(0).value);
            Console.ReadKey();

            Console.WriteLine(list.GetNode(0).value);
            Console.WriteLine(list.GetNode(1).value);
            Console.WriteLine(list.GetNode(2).value);
            Console.WriteLine(list.GetNode(3).value);
            Console.ReadKey();


        }
    }
}
