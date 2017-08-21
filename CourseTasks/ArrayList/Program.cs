using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList.ArrayList<string> list = new ArrayList<string>(6);
            list.Add("Ann");
            list.Add("Ann1");
            list.Add("Ann2");
            list.Add("Ann3");
            list.Add("Ann4");
            list.Add("Ann5");

            Console.WriteLine(list);
            Console.WriteLine(list.Count());
            Console.ReadKey();

            //     list.RemoveAt(2);

            Console.WriteLine(list.Contains("Ann2"));
            Console.Write(list.Count);

            Console.ReadKey();

            string[] array = new string[9];

            list.CopyTo(array, 3);

            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i]);
            Console.ReadKey();

            foreach (string s in list)
            {
                Console.WriteLine(s);
                Console.ReadKey();

            }
        }
    }
}
